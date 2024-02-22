using System;
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
        public int Sum { get; set; }

        public ScoreBoard (string player)
        {
            Player = player;
        }

        public void UdregnSum()
        {
            int sum = 0;
            if (Etere != null && Etere != "-")
            {
                sum += Convert.ToInt32(Etere);
            }            
            
            if (Toere != null && Toere != "-")
            {
                sum += Convert.ToInt32(Toere);
            }            
            
            if (Treere != null && Treere != "-")
            {
                sum += Convert.ToInt32(Treere);
            }            
            
            if (Fireere != null && Fireere != "-")
            {
                sum += Convert.ToInt32(Etere);
            }            
            
            if (Femere != null && Femere != "-")
            {
                sum += Convert.ToInt32(Femere);
            }            
            
            if (Seksere != null && Seksere != "-")
            {
                sum += Convert.ToInt32(Seksere);
            }            
            
            if (EtPar != null && EtPar != "-")
            {
                sum += Convert.ToInt32(EtPar);
            }            
            
            if (ToPar != null && ToPar != "-")
            {
                sum += Convert.ToInt32(ToPar);
            }            
            
            if (TreEns != null && TreEns != "-")
            {
                sum += Convert.ToInt32(TreEns);
            }            
            
            if (FireEns != null && FireEns != "-")
            {
                sum += Convert.ToInt32(FireEns);
            }            
            
            if (LilleStraight != null && LilleStraight != "-")
            {
                sum += Convert.ToInt32(LilleStraight);
            }            
            
            if (StorStraight != null && StorStraight != "-")
            {
                sum += Convert.ToInt32(StorStraight);
            }            
            
            if (Hus != null && Hus != "-")
            {
                sum += Convert.ToInt32(Hus);
            }            
            
            if (Chance != null && Chance != "-")
            {
                sum += Convert.ToInt32(Chance);
            }            
            
            if (Yatzy != null && Yatzy != "-")
            {
                sum += Convert.ToInt32(Yatzy);
            }
            Sum = sum;
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
            UdregnSum();
            Score += "Sum: " + Sum;

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
                Toere = (x * 2).ToString();
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
                Treere = (x * 3).ToString();
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
                Fireere = (x * 4).ToString();
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
                Femere = (x * 5).ToString();
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
                Seksere = (x * 6).ToString();
            }
            else { Seksere = "-"; }
        }

        public void EtParTjek (List<int> Rolls)
        {
            List<int> ParEt = new List<int> ();
            int x = 0;
            foreach (int number in Rolls)
            {
                if (number == x && !ParEt.Contains(number))
                {
                    ParEt.Add(number);
                }
                x = number;
            }
            if (ParEt.Count > 1)
            {
                while (EtPar == null) 
                {
                    Console.WriteLine("Du rollede mere end 1 par et. Vælg en: ");
                    try
                    {
                        Console.WriteLine("1. " + ParEt[0] + "\n2. " + ParEt[1]);
                        int ParVælger = Convert.ToInt32(Console.ReadLine());
                        switch (ParVælger)
                        {
                            case 1:
                                EtPar = (ParEt[0] * 2).ToString(); break;
                            case 2:
                                EtPar = (ParEt[1] * 2).ToString(); break;
                            default:
                                Console.WriteLine("Ugyldigt input"); 
                                break;
                        }
                    } catch
                    {
                        Console.WriteLine("Ugyldigt input");
                    }
                }
            } else if (ParEt.Count == 1)
            {
                EtPar = (ParEt[0] * 2).ToString();
            }
            else
            {
                EtPar = "-";
            }
        }


        public void ToParTjek(List<int> Rolls)
        {
            List<int> ParTo = new List<int>();
            int x = 0;
            foreach (int number in Rolls)
            {
                if (number == x && !ParTo.Contains(number))
                {
                    ParTo.Add(number);
                }
                x = number;
            }
            if (ParTo.Count > 1)
            {
                ToPar = ((ParTo[0] * 2) + (ParTo[1] * 2)).ToString(); 
            }
            else
            {
                ToPar = "-";
            }
        }

        public void TreEnsTjek(List<int> Rolls)
        {
            int x = 0;
            for (int i = 0; i < Rolls.Count - 2; i++)
            {
                if (Rolls[i] == Rolls[i + 1] && Rolls[i] == Rolls[i + 2])
                {
                    x = Rolls[i];
                }
            }
            if (x != 0)
            {
                TreEns = (x * 3).ToString();
            } else { TreEns = "-"; }
        }

        public void FireEnsTjek(List<int> Rolls)
        {
            int x = 0;
            for (int i = 0; i < Rolls.Count - 3; i++)
            {
                if (Rolls[i] == Rolls[i + 1] && Rolls[i] == Rolls[i + 2] && Rolls[i] == Rolls[i + 3])
                {
                    x = Rolls[i];
                }
            }
            if (x != 0)
            {
                FireEns = (x * 4).ToString();
            }
            else { FireEns = "-"; }
        }

        public void LilleStraightTjek(List<int> Rolls)
        {
            List<int> x = new List<int>();
            for (int i = 0; i < Rolls.Count - 3; i++)
            {
                if (Rolls[i + 3] - Rolls[i + 2] == 1 && Rolls[i + 2] - Rolls[i + 1] == 1 && Rolls[i + 1] - Rolls[i] == 1)
                {
                    x.Add(Rolls[i]);
                    x.Add(Rolls[i + 1]);
                    x.Add(Rolls[i + 2]);
                    x.Add(Rolls[i + 3]);
                }
            }
            if (x.Count != 0)
            {
                LilleStraight = (x[0] + x[1] + x[2] + x[3]).ToString();
            }
            else { LilleStraight = "-"; }
        }        
        
        public void StorStraightTjek(List<int> Rolls)
        {
            List<int> x = new List<int>();
            if (Rolls[4] - Rolls[3] == 1 && Rolls[3] - Rolls[2] == 1 && Rolls[2] - Rolls[1] == 1 && Rolls[1] - Rolls[0] == 1)
            {
                x.Add(Rolls[0]);
                x.Add(Rolls[1]);
                x.Add(Rolls[2]);
                x.Add(Rolls[3]);
                x.Add(Rolls[4]);
            }
            if (x.Count != 0)
            {
                StorStraight = (x[0] + x[1] + x[2] + x[3]).ToString();
            }
            else { StorStraight = "-"; }
        }

        public void HusTjek(List<int> Rolls)
        {
            int x = 0;
            int y = 0;
            for (int i = 0; i < 5; i++)
            {
                if (Rolls[i] == Rolls[0])
                {
                    x++;
                } else if (Rolls[i] == Rolls[4])
                {
                    y++;
                }
            }
            if (x == 3 && y == 2)
            {
                Hus = ((x * 3) + (y * 2)).ToString();
            }else if (x == 2 && y == 3)
            {
                Hus = ((x * 2) + (y * 3)).ToString();
            }
            else
            {
                Hus = "-";
            }
            
        }

        public void ChanceValg(List<int> Rolls)
        {
            while (Chance == null)
            {
                Console.WriteLine("(1.)Streg eller (2.)Indsæt værdi");
                string valg = Console.ReadLine();
                switch (valg)
                {
                    case "1" or "1." or "Streg" or "streg":
                        Chance = "-";
                        break;
                    case "2" or "2." or "ind" or "Ind" or "indsæt" or "Indsæt" or "indsæt værdi" or "Indsæt værdi":
                        Chance = (Rolls[0] + Rolls[1] + Rolls[2] + Rolls[3] + Rolls[4]).ToString();
                        break;
                    default:
                        Console.WriteLine("Ugyldig værdi");
                        break;
                }
            }
        }

        public void YatzyTjek(List<int> Rolls)
        {
            if (Rolls[0] == Rolls[1] && Rolls[0] == Rolls[2] && Rolls[0] == Rolls[3] && Rolls[0] == Rolls[4])
            {
                Yatzy = "50";
            } else
            {
                Yatzy = "-";
            }
        }
    }
}
