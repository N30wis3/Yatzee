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
            bool GameIsOn = false;
            bool Yahtzee = true;


            int AntalSpillere = 0;
            int RollSelector = 0;

            List<int> Rolls = new List<int>();
            List<int> SavedRolls = new List<int>();

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
            //Skab alle variabler, lister og så videre ^



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
                        GameIsOn = true;
                    }
                    catch 
                    { 
                        Console.WriteLine("Ugyldigt antal spillere"); 
                    }
                }
                while (GameIsOn == true)
                {
                    //Kontrol over rul
                    for (int i = 1; i <= 3; i++)
                    {
                        //Tilføjer 5 tilfældige værdier til listen Rolls
                        Rolls.Add(Dice1.DiceRoll(Dice1.Sides));
                        Rolls.Add(Dice2.DiceRoll(Dice2.Sides));
                        Rolls.Add(Dice3.DiceRoll(Dice3.Sides));
                        Rolls.Add(Dice4.DiceRoll(Dice4.Sides));
                        Rolls.Add(Dice5.DiceRoll(Dice5.Sides));

                        Console.WriteLine("Dit rul: ");
                        //Printer de fem værdier
                        foreach (int Roll in Rolls)
                        {
                            Console.Write(Roll + " ");
                        }
                        Console.WriteLine("\n");
                        Console.WriteLine("Hvad vil du gemme?");
                        RollSelector = Convert.ToInt32(Console.ReadLine());
                        while (RollSelector != 0 || Rolls.Count > 0)
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
                                }
                            }
                            catch { Console.WriteLine("fejl"); }
                        }
                       
                        
                    }
                    

                    if (Console.ReadLine() == "done")
                    {
                        StartPhase = true;
                        GameIsOn = false;
                    }
                }
            }
        }
    }
}
