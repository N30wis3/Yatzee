using System.Linq;
using System.Net.Mime;

namespace YahtzeeGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Skab alle variabler, lister og så videre V
            bool StartPhase = true;
            bool Yahtzee = true;


            int AntalSpillere = 0;

            //Lav 5 terninger
            Dice Dice1 = new Dice();
            Dice Dice2 = new Dice();
            Dice Dice3 = new Dice();
            Dice Dice4 = new Dice();
            Dice Dice5 = new Dice();

            Dice1.Sides = 6;
            Dice2.Sides = 6;
            Dice3.Sides = 6;
            Dice4.Sides = 6;
            Dice5.Sides = 6;
            //Skab alle variabler





            while (Yahtzee == true) 
            {
                while (StartPhase == true)
                {
                    Console.WriteLine("Indtast spillere");
                    try
                    {
                        AntalSpillere = Convert.ToInt32(Console.ReadLine());
                        if (AntalSpillere < 1)
                        {
                            AntalSpillere = 1;
                        } else if (AntalSpillere > 10)
                        {
                            AntalSpillere = 10;
                        }
                        StartPhase = false;
                    }
                    catch 
                    { 
                        Console.WriteLine("Ugyldigt antal spillere"); 
                    }
                }
                RulMedTerningerne(ref Dice1, ref Dice2, ref Dice3, ref Dice4, ref Dice5);
            }
        }

        static void RulMedTerningerne(ref Dice Dice1, ref Dice Dice2, ref Dice Dice3, ref Dice Dice4, ref Dice Dice5)
        {
            int RollSelector = 0;

            List<int> Rolls = new List<int>();
            List<int> SavedRolls = new List<int>();

            //Tilføjer 5 tilfældige værdier til listen Rolls
            Rolls.Add(Dice1.DiceRoll(Dice1.Sides));
            Rolls.Add(Dice2.DiceRoll(Dice2.Sides));
            Rolls.Add(Dice3.DiceRoll(Dice3.Sides));
            Rolls.Add(Dice4.DiceRoll(Dice4.Sides));
            Rolls.Add(Dice5.DiceRoll(Dice5.Sides));

            

            //Kontrol over rul
            for (int i = 2; i > 0; i--)
            {
                Rolls.Sort();
                Console.WriteLine("\n\nDit rul: ");
                //Printer de fem værdier
                foreach (int Roll in Rolls)
                {
                    Console.Write(Roll + " ");
                }

                Console.WriteLine("\nDu har " + i + " Kast tilbage\n");
                Console.WriteLine("Hvad vil du gemme?\n");
                
                while (Rolls.Count > 0)
                {

                    Console.WriteLine("Skriv 0 for at slå igen");
                    try
                    {
                        RollSelector = Convert.ToInt32(Console.ReadLine());
                        if (Rolls.Contains(RollSelector))
                        {
                            SavedRolls.Add(RollSelector);
                            Rolls.Remove(RollSelector);
                            Console.WriteLine("Terninger der skal omrulles");
                            foreach (int Roll in Rolls)
                            {
                                Console.Write(Roll + " ");
                            }
                            Console.WriteLine("\n");
                            Console.WriteLine("Terninger du har gemt");
                            foreach (int SavedRoll in SavedRolls)
                            {
                                Console.Write(SavedRoll + " ");
                            }
                            Console.WriteLine("\n");
                        } else if (RollSelector == 0)
                        {
                            break;
                        }
                    }
                    catch { Console.WriteLine("fejl"); }
                }
                Rerolls(ref Rolls, ref Dice1);
                foreach (int SavedRoll in SavedRolls)
                {
                    Rolls.Add(SavedRoll);
                }
                SavedRolls.Clear();
            }
            Console.WriteLine("Dit endelige rul var: ");
            foreach (int Roll in Rolls) { Console.Write(Roll + " "); }


        }


        static void Rerolls(ref List<int> Rolls, ref Dice Dice1)
        {
            List<int> NewRanRoll = new List<int>();
            for (int i = 0; i < Rolls.Count; i++)
            {
                NewRanRoll.Add(Dice1.DiceRoll(Dice1.Sides));
            }
            Rolls.Clear();
            Rolls = NewRanRoll;
        }
    }
}
