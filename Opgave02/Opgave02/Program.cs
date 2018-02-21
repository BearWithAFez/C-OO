using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opgave02
{
    class Program
    {
        static void Main(string[] args)
        {

            Scheduler attempt = new Scheduler();

            attempt.Participants = new List<Participant>();
            attempt.Sessions = new List<Session>();

            ////test Code
            //attempt.Participants = new List<Participant>
            //    {
            //        new Participant("Annelies",new List<int> {4,2,3 }),
            //        new Participant("Bob",new List<int> {1,4,2 }),
            //        new Participant("Corwin",new List<int> {1,2,4 }),
            //        new Participant("Dwight",new List<int> {1,4,3 }),
            //        new Participant("Emilio",new List<int> {3,2,1 }),
            //        new Participant("Fleur",new List<int> {2,4,3 }),
            //        new Participant("Gert",new List<int> {2,1,3 }),
            //        new Participant("Herbert",new List<int> {4,2,3 }),
            //        new Participant("Ivan",new List<int> {1,3,4 }),
            //        new Participant("Johan",new List<int> {1,4,2 })
            //    };
            //attempt.Sessions = new List<Session>
            //    {
            //        new Session("1-Wist je dat",3),
            //        new Session("2-je hoofd tegen de muur slaan",4),
            //        new Session("3-verbrandt 150 cal/uur.",4),
            //        new Session("4-nog een reden om C# te doen",4)
            //    };

            attempt.CalculateSchedule();

            //einde programma
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
