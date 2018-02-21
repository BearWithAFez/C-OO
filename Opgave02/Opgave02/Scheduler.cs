using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opgave02
{
    public class Scheduler
    {
        private bool scheduleOk = false;

        public Scheduler()
        {
            this.Sessions = new List<Session>();
            this.Participants = new List<Participant>();
            this.SessionPersonSchedule = new Dictionary<Session, List<Participant>>();
        }


        public bool CalculateSchedule()
        {
            SessionPersonSchedule = new Dictionary<Session, List<Participant>>();

            int[,] TijdelijkSchema = new int[Sessions.Count, Participants.Count];
            int[] LegeRuimtes = new int[Sessions.Count];
            for (int i = 0; i < LegeRuimtes.Length; i++)
            {
                LegeRuimtes[i] = Sessions[i].MaxParticipants;
            }

            //Start met zoeken naar een oplossing
            if (Participants.Count > 0 && Sessions.Count > 0) recursieMethode(0, TijdelijkSchema, LegeRuimtes);

            //als er oplossingen zijn print dan de laatst opgeslagen
            if (scheduleOk)
            {
                PrintDictionary();
                return true;
            }
            return false;
        }

        public void recursieMethode(int participantNummer, int[,] TijdelijkSchema, int[] VrijePlaatsen)
        {
            if (participantNummer == Participants.Count)
            {
                zetInDictionary(TijdelijkSchema);
                scheduleOk = true;
            }
            else
            {
                for (int VoorkeurNr = 0; VoorkeurNr < Participants[participantNummer].Preferences.Count; VoorkeurNr++)
                {
                    if (VrijePlaatsen[Participants[participantNummer].Preferences[VoorkeurNr] - 1] > 0)
                    {
                        //smijt hem erin
                        TijdelijkSchema = zetInTijdelijk(participantNummer, Participants[participantNummer].Preferences[VoorkeurNr] - 1, TijdelijkSchema);
                        VrijePlaatsen[Participants[participantNummer].Preferences[VoorkeurNr] - 1]--;
                        //volgende participant doen
                        recursieMethode(participantNummer + 1, TijdelijkSchema, VrijePlaatsen);
                        //smijt hem eruit (backtracking)
                        TijdelijkSchema = zetUitTijdelijk(participantNummer, Participants[participantNummer].Preferences[VoorkeurNr] - 1, TijdelijkSchema);
                        VrijePlaatsen[Participants[participantNummer].Preferences[VoorkeurNr] - 1]++;
                    }
                }
            }

        }

        public void zetInDictionary(int[,] TijdelijkSchema)
        {
            //empty de Dictionary
            SessionPersonSchedule.Clear();
            List<Participant> subLijst = new List<Participant>();

            for (int i = 0; i < TijdelijkSchema.GetLength(0); i++)
            {
                //maak de LEGE participants LIST
                subLijst = new List<Participant>();
                subLijst.Clear();

                //vul de participants LIST
                for (int j = 0; j < TijdelijkSchema.GetLength(1); j++)
                {
                    if (TijdelijkSchema[i, j] != 0) subLijst.Add(Participants[TijdelijkSchema[i, j] - 1]);
                }

                //voeg de SESSION en LIST samen in de DICTIONARY
                this.SessionPersonSchedule.Add(Sessions[i], subLijst);
            }
        }

        public void PrintDictionary()
        {
            if (this.SessionPersonSchedule.Count != 0)
            {
                foreach (KeyValuePair<Session, List<Participant>> kvp in this.SessionPersonSchedule)
                {
                    Console.WriteLine("{0}: ({1}) ", kvp.Key.Name, kvp.Key.MaxParticipants);
                    foreach (var Participant in kvp.Value) Console.WriteLine("\t{0}", Participant.Name);
                    Console.WriteLine("");
                }
            }
        }

        public int[,] zetInTijdelijk(int participantNummer, int SessieNr, int[,] TijdelijkSchema)
        {
            Boolean gedaan = false;
            for (int i = 0; !gedaan; i++)
            {
                if (TijdelijkSchema[SessieNr, i] == 0)
                {
                    TijdelijkSchema[SessieNr, i] = participantNummer;
                    gedaan = true;
                }
            }
            return TijdelijkSchema;
        }

        public int[,] zetUitTijdelijk(int participantNummer, int SessieNr, int[,] TijdelijkSchema)
        {
            Boolean gedaan = false;
            for (int i = 0; !gedaan; i++)
            {
                if (TijdelijkSchema[SessieNr, i] == participantNummer)
                {
                    TijdelijkSchema[SessieNr, i] = 0;
                    gedaan = true;
                }
            }
            return TijdelijkSchema;
        }

        // lijst van deelnemers met voorkeuren voor sessies opslaan
        public List<Participant> Participants
        {
            get;
            set;
        }

        // lijst van beschikbare sessies opslaan
        public List<Session> Sessions
        {
            get;
            set;
            
        }

        // plaatsen van personen bij een sessie doe je door deze methode aan de lijst toe te voegen die hoort bij de bewuste sessie
        public Dictionary<Session, List<Participant>> SessionPersonSchedule
        {
            get;
            set;

        }
    }
}
