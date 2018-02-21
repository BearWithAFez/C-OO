using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogicInterface;
using LogicImplementation;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Diagnostics;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace UnitTests
{
    [TestClass]
    public class Deel3
    {
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            // load all assemblies in the bin-directory for auto detection
            // of interface,  implementations and class/struct definitions
            // loads alls assemblies in the same directory
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var di = new DirectoryInfo(path);
            var debug = di.GetFiles("*.*");
            foreach (var file in di.GetFiles("*.dll"))
            {
                try
                {
                    var nextAssembly = Assembly.LoadFile(file.FullName);
                }
                catch (BadImageFormatException)
                {
                    // Not a .net assembly  - ignore
                }
            }
        }

        private Type GetTypeByName(string typeName)
        {
            var foundClass = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                              from type in assembly.GetTypes()
                              where type.Name == typeName
                              select type).FirstOrDefault();
            return (Type)foundClass;
        }

        private void CheckProperty(Type t, string propName, Type[] propTypes)
        {
            var props = t.GetProperties();
            var prop = props.Where(p => p.Name == propName).FirstOrDefault();
            Assert.IsNotNull(prop, $" - {t.GetType().Name} has no public {propName} property");
            Assert.IsTrue(Array.Exists(propTypes, p => p.Name == prop.PropertyType.Name),
                              $"- {typeof(object).Name}: property {propName} is a {prop.PropertyType.Name}");
        }

        private void CheckMethod(Type t, string methodName, Type[] returnTypes, Type[] parameterTypes)
        {
            var methods = t.GetMethods();
            // check if method exists with right signature
            var method = methods.Where(m =>
            {
                if (m.Name != methodName) return false;
                var parameters = m.GetParameters();
                if ((parameterTypes == null || parameterTypes.Length == 0)) return parameters.Length == 0;
                if (parameters.Length != parameterTypes.Length) return false;
                for (int i = 0; i < parameterTypes.Length; i++)
                {
                    // if (parameters[i].ParameterType != parameterTypes[i])
                    if (!parameters[i].ParameterType.IsAssignableFrom(parameterTypes[i]))
                        return false;
                }
                return true;
            }).FirstOrDefault();
            Assert.IsNotNull(method, $" - {t.FullName} has no public {methodName} method with the right signature");

            // check returnType
            Assert.IsTrue(Array.Exists(returnTypes, r => r.Name == method.ReturnType.Name),
                              $"- {typeof(object).Name}: method {methodName} returns a {method.ReturnType.Name}");
        }

        private void CheckEvent(Type t, string eventName, Type[] eventTypes)
        {
            var events = t.GetEvents();
            var @event = events.Where(p => p.Name == eventName).FirstOrDefault();
            Assert.IsNotNull(@event, $" - {t.GetType().Name} has no {eventName} event");
            Assert.IsTrue(Array.Exists(eventTypes, p => p.Name == @event.EventHandlerType.Name),
                              $"- {typeof(object).Name}: event {eventName} is a {@event.EventHandlerType.Name}");
        }

        private object getInterfaceImplementation(Type wantedInterface)
        {
            Type unknownClass = null;
            foreach (var asm in AppDomain.CurrentDomain.GetAssemblies())
            {
                unknownClass = new List<Type>(asm.GetTypes()).Where(x => wantedInterface.IsAssignableFrom(x) && !x.IsInterface).FirstOrDefault();
                if (unknownClass != null) break;
            }
            if (unknownClass == null) return null;
            return Activator.CreateInstance(unknownClass);
        }
        private Type getInterfaceImplementatingClass(Type wantedInterface)
        {
            Type unknownClass = null;
            foreach (var asm in AppDomain.CurrentDomain.GetAssemblies())
            {
                unknownClass = new List<Type>(asm.GetTypes()).Where(x => wantedInterface.IsAssignableFrom(x) && !x.IsInterface).FirstOrDefault();
                if (unknownClass != null) break;
            }
            if (unknownClass == null) return null;
            return (Type)unknownClass;
        }


        [TestMethod]
        public void TestIfImplementsInterface()
        {
            Assert.IsTrue(typeof(ChainChecker) == getInterfaceImplementatingClass(typeof(IChainChecker)));
        }

        /*
           te testen:
           
           - progress used... (threading context)
        */


        [TestMethod]
        public void TestTaskStartedEvent()
        {
            bool eventsChangedFired = false;
            var logic = new ChainChecker();
            try
            {
                logic.ProgressChanged += () => { eventsChangedFired = true; };
                logic.CalculationFinished += () => {; };
                var startTime = DateTime.Now;
                logic.Start();
                var time = DateTime.Now;
                Assert.IsTrue((time - startTime).Ticks < TimeSpan.TicksPerMillisecond * 100, "ChainChecker: calling Start does not return immediately");
                Thread.Sleep(100);
                Assert.IsTrue(eventsChangedFired, "ChainChecker: background task does not call events, is it started?");
            }
            finally
            {
                logic?.Abort();
            }



        }

        [TestMethod]
        public void TestProgressChanged()
        {
            long count = 0;
            int eventsChangedFired = 0;
            DateTime previousTime = DateTime.Now;
            DateTime startTime = DateTime.Now;
            TimeSpan elapsedTime;
            var logic = new ChainChecker();
            string errorString = string.Empty;
            long eventInterval = 0;
            try
            {
                logic.ProgressChanged += () =>
                {
                    eventsChangedFired++;
                    if (errorString == string.Empty)
                    {
                        //Assert.IsTrue(logic.NumbersProcessed > count, $"ProgressChanged event: NumbersProcessed has not increased!");
                        count = logic.PercentageCompleted;
                        elapsedTime = DateTime.Now - startTime;
                        //Assert.IsTrue(Math.Abs(elapsedTime.Ticks - logic.ElapsedTime.Ticks) < TimeSpan.TicksPerMillisecond * 5,
                        if (!(Math.Abs(elapsedTime.Ticks - logic.ElapsedTime.Ticks) < TimeSpan.TicksPerMillisecond * 5))
                        {
                            errorString = $"ProgressChanged event: Elapsed time not correct: expected: {elapsedTime.Ticks / TimeSpan.TicksPerMillisecond} msec, was {logic.ElapsedTime.Ticks / TimeSpan.TicksPerMillisecond} msec!";
                        }
                        else
                        {
                            if (eventsChangedFired != 1)
                            {
                                elapsedTime = DateTime.Now - previousTime;
                                eventInterval = (eventInterval * (eventsChangedFired - 2) + elapsedTime.Ticks) / (eventsChangedFired - 1);
                            }
                        }
                    }
                    previousTime = DateTime.Now;
                };
                logic.CalculationFinished += () => {; };
                logic.Start();
                TimeSpan x;
                while (((x = (DateTime.Now - startTime)).Ticks < 300 * TimeSpan.TicksPerMillisecond) && (eventsChangedFired < 4))
                {
                    Thread.Sleep(10);
                }
                Assert.IsTrue(errorString == string.Empty, errorString);
                Assert.IsTrue(Math.Abs(eventInterval / TimeSpan.TicksPerMillisecond - 50) <= 15, $"ProgressChanged event: time interval not ~ 20 msec (was: {eventInterval / TimeSpan.TicksPerMillisecond } msec average)!");
                Assert.IsTrue(eventsChangedFired >= 2, "ChainChecker: background task does not call 'ProgessChanged' event!");
            }
            finally
            {
                logic?.Abort();
            }
        }


        [TestMethod]
        public void TestChainlengthDictionaryUpdated()
        {
            long count = 0;
            int eventsChangedFired = 0;
            DateTime previousTime = DateTime.Now;
            DateTime startTime = DateTime.Now;
            TimeSpan elapsedTime;
            var logic = new ChainChecker();
            string errorString = string.Empty;

            try
            {

                logic.ProgressChanged += () =>
                {
                    eventsChangedFired++;
                };
                logic.CalculationFinished += () => {; };
                logic.Start();
                TimeSpan x;
                while (((x = (DateTime.Now - startTime)).Ticks < 150 * TimeSpan.TicksPerMillisecond) && (eventsChangedFired < 3))
                {
                    Thread.Sleep(10);
                }
                Assert.IsTrue(logic.ChainLengthDictionary.Count > 0, "ChainChecker: 'ProgessChanged' does not update ChainLengthDictionary");
                Assert.IsTrue(eventsChangedFired >= 2, "ChainChecker: background task does not call 'ProgessChanged' event!");
            }
            finally
            {
                logic?.Abort();
            }
        }



        [TestMethod]

        public void TestGetChainLength()
        {
            Dictionary<long, int> testValues = new Dictionary<long, int>
            {
                { 44,-1},
                { 85, 1},
                { 89, 0 },
                { 1,-1},
                { 145,7}
            };


            var logic = new ChainChecker();

            foreach (var item in testValues)
            {
                var length = logic.GetChainLength(item.Key);
                Assert.IsTrue(length == item.Value, $"'GetChainLength' fails: returns {length} where {item.Value} was expected!");
            }
        }

        [TestMethod]
        public void TestAbort()
        {
            bool eventsChangedFired;
            var logic = new ChainChecker();
            logic.ProgressChanged += () => { eventsChangedFired = true; };
            logic.CalculationFinished += () => {; };
            logic.Start();
            logic.Abort();
            Thread.Sleep(20);
            eventsChangedFired = false;
            Thread.Sleep(100);
            Assert.IsTrue(!eventsChangedFired, "ChainChecker: Abort does not halt background task within 20 msec!");
        }

    }
}
