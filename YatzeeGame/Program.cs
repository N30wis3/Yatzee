using System.Linq;
using System.Net.Mime;
using YahtzeeGame;

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


            //Skab alle variabler ^

            List<Player> Players = new List<Player>();
            List<ScoreBoard> ScoreBoards = new List<ScoreBoard>();


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
                            string x = Console.ReadLine();
                            Players.Add(new Player(x, i));
                            ScoreBoards.Add(new ScoreBoard(x));
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
                    RulMedTerningerne(ref Dice1, ref Dice2, ref Dice3, ref Dice4, ref Dice5, ref Players, ref PlayerTurn, ref ScoreBoards);
                }
                
            }
        }

        static void RulMedTerningerne(ref Dice Dice1, ref Dice Dice2, ref Dice Dice3, ref Dice Dice4, ref Dice Dice5, ref List<Player> players, ref int PlayerTurn, ref List<ScoreBoard> ScoreBoards)
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
            ScoreChoice(ref Rolls, ref players, ref PlayerTurn, ref ScoreBoards);

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


        static void ScoreChoice(ref List<int> Rolls, ref List<Player> players, ref int PlayerTurn, ref List<ScoreBoard> ScoreBoards)
        {
            Console.WriteLine(ScoreBoards[PlayerTurn].PrintScore());
            Console.Write("Vælg en: ");
            bool GyldigtValg = false;
            while (GyldigtValg == false)
            {
                string x = Console.ReadLine();

                switch (x)
                {
                    //Basalt
                    case "1":
                        if (ScoreBoards[PlayerTurn].Etere == null)
                        {
                            ScoreBoards[PlayerTurn].EterTjek(Rolls);
                            GyldigtValg = true;
                        }
                        else
                        {
                            Console.WriteLine("Dit valg er ugyldigt, prøv et andet");
                        }
                        break;

                    case "2":
                        if (ScoreBoards[PlayerTurn].Toere == null)
                        {
                            ScoreBoards[PlayerTurn].ToerTjek(Rolls);
                            GyldigtValg = true;
                        }
                        else
                        {
                            Console.WriteLine("Dit valg er ugyldigt, prøv et andet");
                        }
                        break;

                    case "3":
                        if (ScoreBoards[PlayerTurn].Treere == null)
                        {
                            ScoreBoards[PlayerTurn].TreerTjek(Rolls);
                            GyldigtValg = true;
                        }
                        else
                        {
                            Console.WriteLine("Dit valg er ugyldigt, prøv et andet");
                        }
                        break;

                    case "4":
                        if (ScoreBoards[PlayerTurn].Fireere == null)
                        {
                            ScoreBoards[PlayerTurn].FireTjek(Rolls);
                            GyldigtValg = true;
                        }
                        else
                        {
                            Console.WriteLine("Dit valg er ugyldigt, prøv et andet");
                        }
                        break;

                    case "5":
                        if (ScoreBoards[PlayerTurn].Femere == null)
                        {
                            ScoreBoards[PlayerTurn].FemmerTjek(Rolls);
                            GyldigtValg = true;
                        }
                        else
                        {
                            Console.WriteLine("Dit valg er ugyldigt, prøv et andet");
                        }
                        break;

                    case "6":
                        if (ScoreBoards[PlayerTurn].Seksere == null)
                        {
                            ScoreBoards[PlayerTurn].SekserTjek(Rolls);
                            GyldigtValg = true;
                        }
                        else
                        {
                            Console.WriteLine("Dit valg er ugyldigt, prøv et andet");
                        }
                        break;
                    //Kompliceret
                    /*
                case "7":
                    if (ScoreBoards[PlayerTurn]. == null)
                    {
                        ScoreBoards[PlayerTurn].(Rolls);
                        GyldigtValg = true;
                    }
                        else
                        {
                            Console.WriteLine("Dit valg er ugyldigt, prøv et andet");
                        }
                        break;

                case "8":
                    if (ScoreBoards[PlayerTurn]. == null)
                    {
                        ScoreBoards[PlayerTurn].(Rolls);
                        GyldigtValg = true;
                    }
                        else
                        {
                            Console.WriteLine("Dit valg er ugyldigt, prøv et andet");
                        }
                        break;

                case "9":
                    if (ScoreBoards[PlayerTurn]. == null)
                    {
                        ScoreBoards[PlayerTurn].(Rolls);
                        GyldigtValg = true;
                    }
                        else
                        {
                            Console.WriteLine("Dit valg er ugyldigt, prøv et andet");
                        }
                        break;

                case "10":
                    if (ScoreBoards[PlayerTurn]. == null)
                    {
                        ScoreBoards[PlayerTurn].(Rolls);
                        GyldigtValg = true;
                    }
                        else
                        {
                            Console.WriteLine("Dit valg er ugyldigt, prøv et andet");
                        }
                        break;

                case "11":
                    if (ScoreBoards[PlayerTurn]. == null)
                    {
                        ScoreBoards[PlayerTurn].(Rolls);
                        GyldigtValg = true;
                    }
                        else
                        {
                            Console.WriteLine("Dit valg er ugyldigt, prøv et andet");
                        }
                        break;

                case "12":
                    if (ScoreBoards[PlayerTurn]. == null)
                    {
                        ScoreBoards[PlayerTurn].(Rolls);
                        GyldigtValg = true;
                    }
                        else
                        {
                            Console.WriteLine("Dit valg er ugyldigt, prøv et andet");
                        }
                        break;

                case "13":
                    if (ScoreBoards[PlayerTurn]. == null)
                    {
                        ScoreBoards[PlayerTurn].(Rolls);
                        GyldigtValg = true;
                    }
                        else
                        {
                            Console.WriteLine("Dit valg er ugyldigt, prøv et andet");
                        }
                        break;

                case "14":
                    if (ScoreBoards[PlayerTurn]. == null)
                    {
                        ScoreBoards[PlayerTurn].(Rolls);
                        GyldigtValg = true;
                    }
                        else
                        {
                            Console.WriteLine("Dit valg er ugyldigt, prøv et andet");
                        }
                        break;

                case "15":
                    if (ScoreBoards[PlayerTurn]. == null)
                    {
                        ScoreBoards[PlayerTurn].(Rolls);
                        GyldigtValg = true;
                    }
                        else
                        {
                            Console.WriteLine("Dit valg er ugyldigt, prøv et andet");
                        }
                        break;
                    */
                    default:
                        Console.WriteLine("Retard");
                        break;
                }
            

            }
        }
    }
}
