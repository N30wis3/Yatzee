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

            List<Player> Players = new List<Player>();

            Player Dicksen = new Player();


            Dicksen.ScoreBoard();

            Dictionary<int, string> Kombinationer = new Dictionary<int, string>();

            Kombinationer.Add(1, "1'ere");
            Kombinationer.Add(2, "2'ere");
            Kombinationer.Add(3, "3'ere");
            Kombinationer.Add(4, "4'ere");
            Kombinationer.Add(5, "5'ere");
            Kombinationer.Add(6, "6'ere");
            Kombinationer.Add(7, "1 par");
            Kombinationer.Add(8, "2 par");
            Kombinationer.Add(9, "3 ens");
            Kombinationer.Add(10, "4 ens");
            Kombinationer.Add(11, "Lille straight");
            Kombinationer.Add(12, "Stor straight");
            Kombinationer.Add(13, "Hus");
            Kombinationer.Add(14, "Chance");
            Kombinationer.Add(15, "Yatzy");



            while (Yahtzee == true) 
            {
                while (StartPhase == true)
                {
                    Console.WriteLine("Indtast spillere");
                    try
                    {
                        AntalSpillere = Convert.ToInt32(Console.ReadLine());
                        if (AntalSpillere < 2)
                        {
                            AntalSpillere = 2;
                        } else if (AntalSpillere > 10)
                        {
                            AntalSpillere = 10;
                        }
                        StartPhase = false;

                        for (int i = 0; i < AntalSpillere; i++)
                        {
                            Console.WriteLine("Spiller " + (i + 1) + " navn: ");
                            Players.Add(new Player(Console.ReadLine(), i)) ;
                        }
                    }
                    catch 
                    { 
                        Console.WriteLine("Ugyldigt antal spillere"); 
                    }

                    for (int i = 0; i <= 25; i++) 
                    {
                        Console.WriteLine("\n");
                    }
                }
                for (int PlayerTurn = 0; PlayerTurn < AntalSpillere; PlayerTurn++)
                {
                    Console.WriteLine("Spiller: " + Players[PlayerTurn].Name);
                    RulMedTerningerne(ref Dice1, ref Dice2, ref Dice3, ref Dice4, ref Dice5, ref Players, ref PlayerTurn);
                }
                
            }
        }

        static void RulMedTerningerne(ref Dice Dice1, ref Dice Dice2, ref Dice Dice3, ref Dice Dice4, ref Dice Dice5, ref List<Player> players, ref int PlayerTurn)
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

                    Console.WriteLine("Skriv 0 for at slå igen\n\n\n");
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
                            Console.WriteLine("\n\n");
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
            Console.WriteLine("\n\n");
            ScoreBoard(ref Rolls, ref players, ref PlayerTurn);

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


        static void ScoreBoard(ref List<int> Rolls, ref List<Player> players, ref int PlayerTurn)
        {
            
        }
    }
}
