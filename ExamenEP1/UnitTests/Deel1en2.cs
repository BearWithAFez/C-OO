using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogicInterface;
using LogicImplementation;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.IO;
using System.Reflection;

namespace UnitTests
{
    [TestClass]
    public class Deel1en2
    {
 
        private string GUIProject = "ChainGUI.exe";
        private string LogicInterfaceName = "LogicInterface.dll";
        private string LogicImplementationName = "LogicImplementation.dll";

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


        [TestMethod]
        public void UnitTestsAreFunctional()
        {
            //Dummy: 1 point for making unit tests work
        }

        [TestMethod]
        public void TestIfProjectsExists()
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            //Assert.IsTrue(File.Exists(path+@"\"+GUIProject), "project \"ChainGUI\" not found.");
            Assert.IsTrue(File.Exists(path + @"\" + LogicInterfaceName), "project \"LogicInterface\" not found.");
            Assert.IsTrue(File.Exists(path + @"\" + LogicImplementationName), "project \"LogicImplementation\" not found.");
        }

        [TestMethod]
        public void TestIfLogicInterfaceExists()
        {
            Type x = GetTypeByName("IChainChecker");
            Assert.IsNotNull(x, "\"IChainChecker\" not declared.");
        }

        [TestMethod]
        public void TestInterfaceProperties()
        {
            Type x = GetTypeByName("IChainChecker");
            CheckProperty(x, "ControlNumber", new Type[] { typeof(long) });
            CheckProperty(x, "ElapsedTime", new Type[] { typeof(TimeSpan) });
            CheckProperty(x, "PercentageCompleted", new Type[] { typeof(int), typeof(Int32) });
            CheckProperty(x, "ChainLengthDictionary", new Type[] { typeof(ConcurrentDictionary<int, long> )});
        }

        [TestMethod]
        public void TestInterfaceMethods()
        {
            Type x = GetTypeByName("IChainChecker");
            CheckMethod(x, "Start", new Type[] { typeof(void) },new Type[] { });
            CheckMethod(x, "Abort", new Type[] { typeof(void) }, new Type[] { });
            CheckMethod(x, "GetChainLength", new Type[] { typeof(int) }, new Type[] { typeof(long) });
        }

        [TestMethod]
        public void TestInterfaceEvents()
        {
            Type x = GetTypeByName("IChainChecker");
            CheckEvent(x, "ProgressChanged", new Type[] { typeof(Action) });
            CheckEvent(x, "CalculationFinished", new Type[] { typeof(Action) });            
        }

    }
}
