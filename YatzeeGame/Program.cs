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
            int tur = 0;


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
                    tur++;
                    for (int i = 0; i <= 5; i++)
                    {
                        Console.WriteLine("\n"); 
                    }
                    Console.WriteLine(ScoreBoards[PlayerTurn].PrintScore());
                    Console.WriteLine("Spiller: " + Players[PlayerTurn].Name);
                    RulMedTerningerne(ref Dice1, ref Dice2, ref Dice3, ref Dice4, ref Dice5, ref Players, ref PlayerTurn, ref ScoreBoards);
                }
                if (tur == (15 * AntalSpillere))
                {
                    Yahtzee = false;
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

                Console.WriteLine("Vil du rolle om");
                
                bool ValidSvar = false;
                while (ValidSvar == false) 
                {
                    string OmRul = Console.ReadLine();
                    switch (OmRul)
                    {
                        case "Yes" or "yes" or "Y" or "y" or "Ja" or "ja" or "J" or "j" or "1" or "2" or "3" or "4" or "5" or "6":
                            Console.WriteLine("\n\nHvad vil du gemme?\n");
                            foreach (int Roll in Rolls)
                            {
                                Console.Write(Roll + " ");
                            }
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
                                    }
                                    else if (RollSelector == 0)
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
                            ValidSvar = true;
                            break;
                        case "No" or "no" or "Nej" or "nej" or "N" or "n" or "" or " ":
                            i = 0;
                            ValidSvar = true;
                            break;


                    }
                }
                

                
                
                
            }
            Rolls.Sort();
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
                    case "1" or "1'ere" or "1ere" or "1 ere":
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

                    case "2" or "2'ere" or "2ere" or "3 ere":
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

                    case "3" or "3'ere" or "3ere" or "3 ere":
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

                    case "4" or "4'ere" or "4ere" or "4 ere":
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

                    case "5" or "5'ere" or "5ere" or "5 ere":
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

                    case "6" or "6'ere" or "6ere" or "6 ere":
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
                    
                    case "7" or "Et par" or "et par" or "EtPar" or "etpar" or "1 par" or "1 Par" or "1p" or "1P" or "1 p" or "1 P":
                        if (ScoreBoards[PlayerTurn].EtPar == null)
                        {
                            ScoreBoards[PlayerTurn].EtParTjek(Rolls);
                            GyldigtValg = true;
                        }
                        else
                        {
                            Console.WriteLine("Dit valg er ugyldigt, prøv et andet");
                        }
                        break;
                    
                    case "8" or "To par" or "to par" or "2 par" or "ToPar" or "Topar" or "topar" or "2 p" or "2 P" or "2p" or "2P":
                        if (ScoreBoards[PlayerTurn].ToPar == null)
                        {
                            ScoreBoards[PlayerTurn].ToParTjek(Rolls);
                            GyldigtValg = true;
                        }
                        else
                    {
                        Console.WriteLine("Dit valg er ugyldigt, prøv et andet");
                    }
                    break;
                       
                    case "9":
                        if (ScoreBoards[PlayerTurn].TreEns == null)
                        {
                            ScoreBoards[PlayerTurn].TreEnsTjek(Rolls);
                            GyldigtValg = true;
                        }
                        else
                        {
                            Console.WriteLine("Dit valg er ugyldigt, prøv et andet");
                        }
                        break;

                    case "10":
                        if (ScoreBoards[PlayerTurn].FireEns == null)
                        {
                            ScoreBoards[PlayerTurn].FireEnsTjek(Rolls);
                            GyldigtValg = true;
                        }
                        else
                        {
                            Console.WriteLine("Dit valg er ugyldigt, prøv et andet");
                        }
                        break;

                    case "11":
                        if (ScoreBoards[PlayerTurn].LilleStraight == null)
                        {
                            ScoreBoards[PlayerTurn].LilleStraightTjek(Rolls);
                            GyldigtValg = true;
                        }
                        else
                        {
                            Console.WriteLine("Dit valg er ugyldigt, prøv et andet");
                        }
                        break;

                    case "12":
                        if (ScoreBoards[PlayerTurn].StorStraight == null)
                        {
                            ScoreBoards[PlayerTurn].StorStraightTjek(Rolls);
                            GyldigtValg = true;
                        }
                        else
                        {
                            Console.WriteLine("Dit valg er ugyldigt, prøv et andet");
                        }
                        break;

                    case "13":
                        if (ScoreBoards[PlayerTurn].Hus == null)
                        {
                            ScoreBoards[PlayerTurn].HusTjek(Rolls);
                            GyldigtValg = true;
                        }
                        else
                        {
                            Console.WriteLine("Dit valg er ugyldigt, prøv et andet");
                        }
                        break;

                    case "14":
                        if (ScoreBoards[PlayerTurn].Chance == null)
                        {
                            ScoreBoards[PlayerTurn].ChanceValg(Rolls);
                            GyldigtValg = true;
                        }
                        else
                        {
                            Console.WriteLine("Dit valg er ugyldigt, prøv et andet");
                        }
                        break;

                    case "15":
                        if (ScoreBoards[PlayerTurn].Yatzy == null)
                        {
                            ScoreBoards[PlayerTurn].YatzyTjek(Rolls);
                            GyldigtValg = true;
                        }
                        else
                        {
                            Console.WriteLine("Dit valg er ugyldigt, prøv et andet");
                        }
                        break;
                
                    default:
                        Console.WriteLine("Retard");
                        break;
                        }
            }
        }
    }
}
