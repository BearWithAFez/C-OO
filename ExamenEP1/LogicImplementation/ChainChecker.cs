using LogicInterface;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LogicImplementation
{
    public class ChainChecker : IChainChecker
    {
        private const long MAX = 10000;
        private bool status = false;
        private object obj = new object();
        private long done = 0;

        public ConcurrentDictionary<int, long> ChainLengthDictionary
        {
            get;
            private set;
        }

        public long ControlNumber
        {
            get;
            private set;
        }

        public TimeSpan ElapsedTime
        {
            get; private set;
        }

        public int PercentageCompleted
        {
            get
            {
                return (int)(done * 100 / MAX);
            }
        }

        public event Action CalculationFinished;
        public event Action ProgressChanged;

        public void Abort()
        {
            if (status)
            {
                status = false;
            }
        }

        public int GetChainLength(long number)
        {
            int steps = 0;
            while (number != 89 && number != 1)
            {
                long _number = number;
                number = 0;
                while (_number > 9)
                {
                    number += (long)Math.Pow(_number % 10, 2);
                    _number /= 10;
                }
                number += (long)Math.Pow(_number % 10, 2);
                steps++;
            }
            if (number == 1) { return -1; }
            return steps;
        }

        public void Start()
        {
            status = true;
            ElapsedTime = new TimeSpan();
            ControlNumber = 0;
            ChainLengthDictionary = new ConcurrentDictionary<int, long>();

            for (long i = 1; (i < MAX) && (status); i++)
            {
                if (GetChainLength(i) != -1)
                {
                    ChainLengthDictionary.AddOrUpdate(GetChainLength(i), 1, (a, b) => { return ChainLengthDictionary[GetChainLength(i)] + 1; });
                }
                long _done;
                lock (obj)
                {
                    _done = done;
                    done = i;
                }
                if (ProgressChanged != null)
                {
                    ProgressChanged();
                }
            }
            if (status)
            {
                if (ProgressChanged != null)
                {
                    ProgressChanged();
                }
                if (CalculationFinished != null)
                {
                    long maxje = 0;
                    foreach (var item in ChainLengthDictionary)
                    {
                        maxje = (item.Value > maxje) ? item.Value : maxje;
                    }
                    ControlNumber = maxje % 97;
                    CalculationFinished();
                }
            }


            //Task.Run(() =>
            //{
            //    for (long i = 1; (i < MAX) && (status); i++)
            //    {
            //        if (GetChainLength(i) != -1)
            //        {
            //            ChainLengthDictionary.AddOrUpdate(GetChainLength(i), 1, (a, b) => { return ChainLengthDictionary[GetChainLength(i)] + 1; });
            //        }
            //        long _done;
            //        lock (obj)
            //        {
            //            _done = done;
            //            done = i;
            //        }
            //        if (ProgressChanged != null)
            //        {
            //            ProgressChanged();
            //        }
            //    }
            //    if (status)
            //    {
            //        if (ProgressChanged != null)
            //        {
            //            ProgressChanged();
            //        }
            //        if (CalculationFinished != null)
            //        {
            //            long maxje = 0;
            //            foreach (var item in ChainLengthDictionary)
            //            {
            //                maxje = (item.Value > maxje) ? item.Value : maxje;
            //            }
            //            ControlNumber = maxje % 97;
            //            CalculationFinished();
            //        }
            //    }
            //});
        }
    }
}
