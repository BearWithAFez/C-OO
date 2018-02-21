using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicInterface;
using GlobalTools;

namespace LogicImplementation
{
    public class MD5CollisionCalculator : IMD5CollisionCalculator
    {
        public int NrOfWorkerTasks
        {
            get; set;
        } = 1;

        public event Action<string> CollisionFound;
        private void CollisionFoundHandler(string collision)
        {
            if (CollisionFound != null) CollisionFound(collision);
        }
        public event Action<decimal> ProgressChanged;
        private void ProgressChangedHandler(decimal progress)
        {
            if (ProgressChanged != null) ProgressChanged(progress);
        }

        public void Abort()
        {
            //
        }

        public void Close()
        {
            //
        }

        public void StartCalculatingMD5Collision(string hash, int passwordLength)
        {
            var generator = new PasswordGenerator(passwordLength);
            int count = 0;
            foreach (var password in generator)
            {
                Console.WriteLine($"{password}");
                count++;

                if (MD5Calculator.GetHash(password) == hash)
                {
                    CollisionFoundHandler(password);
                    break;
                }
                ProgressChangedHandler(count);
            }
        }
    }
}
