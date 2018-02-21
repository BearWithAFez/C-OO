using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace LogicInterface
{
    public interface IChainChecker
    {
        //props
        ConcurrentDictionary<int, long> ChainLengthDictionary { get; }
        long ControlNumber { get; }
        TimeSpan ElapsedTime { get; }
        int PercentageCompleted { get; }

        //meth
        void Abort();
        int GetChainLength(long number);
        void Start();

        //events
        event Action CalculationFinished;
        event Action ProgressChanged;
    }
}
