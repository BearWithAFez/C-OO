using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackendInterface;

namespace BackendImplementation
{
    public class Worker : IWorker
    {
        public event Action<string> CollisionFound;
        public event Action<ulong> ProgressChanged;
        public event Action Stalled;

        public void Abort()
        {
            throw new NotImplementedException();
        }

        public void GetCollisions(string hash, ConcurrentQueue<string> buffer)
        {
            throw new NotImplementedException();
        }
    }
}
