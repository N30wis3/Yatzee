﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YahtzeeGame
{
    internal class ScoreBoard
    {
        public string Player {  get; set; }
        public string Etere { get; set; }
        public string Toere { get; set; }
        public string Treere { get; set; }
        public string Fireere { get; set; }
        public string Femere { get; set; }
        public string Seksere { get; set; }
        public string EtPar { get; set; }
        public string ToPar { get; set; }
        public string TreEns { get; set; }
        public string FireEns { get; set; }
        public string LilleStraight { get; set; }
        public string StorStraight { get; set; }
        public string Hus { get; set; }
        public string Chance { get; set; }
        public string Yatzy { get; set; }

        public ScoreBoard (string player)
        {
            Player = player;
        }

        public string PrintScore()
        {
            string Score = "";
            Score += "Navn: " + Player + "\n";
            Score += "1. " + "1'ere: " + Etere + "\n";
            Score += "2. " + "2'ere: " + Toere + "\n";
            Score += "3. " + "3'ere: " + Treere + "\n";
            Score += "4. " + "4'ere: " + Fireere + "\n";
            Score += "5. " + "5'ere: " + Femere + "\n";
            Score += "6. " + "6'ere: " + Seksere + "\n";
            Score += "7. " + "1 Par: " + EtPar + "\n";
            Score += "8. " + "2 Par: " + ToPar + "\n";
            Score += "9. " + "3 Ens: " + TreEns + "\n";
            Score += "10. " + "4 Ens: " + FireEns + "\n";
            Score += "11. " + "Lille Straight: " + LilleStraight + "\n";
            Score += "12. " + "Stor Straight: " + StorStraight + "\n";
            Score += "13. " + "Hus: " + Hus + "\n";
            Score += "14. " + "Chance: " + Chance + "\n";
            Score += "15. " + "YATZY: " + Yatzy + "\n";

            return Score;
        }

        //Tjekkere
        //1
        public void EterTjek(List<int> Rolls) 
        {
            int x = 0;
            foreach (int number in Rolls) 
            {
                if (number == 1)
                {
                    x++;
                }
            }
            if (x > 0)
            {
                Etere = x.ToString();
            }
            else { Etere = "-"; }
        }
        //2
        public void ToerTjek(List<int> Rolls)
        {
            int x = 0;
            foreach (int number in Rolls)
            {
                if (number == 2)
                {
                    x++;
                }
            }
            if (x > 0)
            {
                Toere = x.ToString();
            }
            else { Toere = "-"; }
        }

        public void TreerTjek(List<int> Rolls)
        {
            int x = 0;
            foreach (int number in Rolls)
            {
                if (number == 3)
                {
                    x++;
                }
            }
            if (x > 0)
            {
                Treere = x.ToString();
            }
            else { Treere = "-"; }
        }

        public void FireTjek(List<int> Rolls)
        {
            int x = 0;
            foreach (int number in Rolls)
            {
                if (number == 4)
                {
                    x++;
                }
            }
            if (x > 0)
            {
                Fireere = x.ToString();
            }
            else { Fireere = "-"; }
        }

        public void FemmerTjek(List<int> Rolls)
        {
            int x = 0;
            foreach (int number in Rolls)
            {
                if (number == 5)
                {
                    x++;
                }
            }
            if (x > 0)
            {
                Femere = x.ToString();
            }
            else { Femere = "-"; }
        }

        public void SekserTjek(List<int> Rolls)
        {
            int x = 0;
            foreach (int number  in Rolls)
            {
                if (number == 6)
                {
                    x++;
                }
            }
            if (x > 0)
            {
                Seksere = x.ToString();
            }
            else { Seksere = "-"; }
        }

        public void EtParTjek (List<int> Rolls)
        {
            int x = 0;
            int y = 0;
            for (int i = 0;  i < Rolls.Count - 1; i++)
            {
                if (Rolls[i] == Rolls[i + 1])
                {
                    x = Rolls[i];
                    i = Rolls.Count;
                }
            }
            for (int i = 0; x < Rolls.Count - 1; x++)
            {
                if (Rolls[i] == Rolls[i + 1] && Rolls[i] != x)
                {
                    y = Rolls[i];
                    i = Rolls.Count;
                }
            }
            while (EtPar == null)
            {
                if (x != 0 && y != 0)
                {
                    Console.WriteLine("Vælg:\n" + "1. " + x.ToString() + " || " + "2. " + y.ToString());
                    while (EtPar == null)
                    {
                        try
                        {
                            int valg = Convert.ToInt32(Console.ReadLine());
                            switch (valg)
                            {
                                case 1:
                                    EtPar = (x * 2).ToString();
                                    break;
                                case 2:
                                    EtPar = (y * 2).ToString();
                                    break;
                                default:
                                    Console.WriteLine("Fejl");
                                    break;
                            }
                        }
                        catch { Console.WriteLine("Fejl"); }
                    }
                }
                else if (x != 0)
                {
                    EtPar = (x * 2).ToString();
                }
                else
                {
                    EtPar = "-";
                }
            }
        }
    }
}
