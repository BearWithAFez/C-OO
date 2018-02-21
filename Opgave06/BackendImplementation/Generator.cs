using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackendInterface;
using GlobalTools;

namespace BackendImplementation
{
    public class Generator : IGenerator
    {
        public event Action GeneratorFinished;
        public event Action<ulong> ProgressChanged;
        public event Action Stalled;

        private string password;

        public void Abort()
        {
            throw new NotImplementedException();
        }

        public void Close()
        {
            throw new NotImplementedException();
        }

        public ulong MaxCount()
        {
            throw new NotImplementedException();
        }

        public ConcurrentQueue<string> Start(int passWordLength, int maxQueueLength)
        {
            ConcurrentQueue<string> returnable = new ConcurrentQueue<string>();
            PasswordGenerator gen = new PasswordGenerator(passWordLength);
            foreach (var password in gen)
            {
                returnable.Enqueue(password);
                //if (returnable.Count == maxQueueLength) return returnable;
            }

             return returnable;
        }
    }
}
