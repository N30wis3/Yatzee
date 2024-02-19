using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YahtzeeGame
{
    public class Player
    {
        public string Name { get; set; }

        public int ID { get; set; }

        public int Points { get; set; }

        public Player(string name = "Bob", int id = 0, int points = 0)
        {
            Name = name;
            ID = id;
            Points = points;
        }
        public void ScoreBoard()
        {
            Dictionary<string, int> Kombinationer = new Dictionary<string, int>();

            Kombinationer.Add("1'ere", 0);
            Kombinationer.Add("2'ere", 0);
            Kombinationer.Add("3'ere", 0);
            Kombinationer.Add("4'ere", 0);
            Kombinationer.Add("5'ere", 0);
            Kombinationer.Add("6'ere", 0);
            Kombinationer.Add("1 par", 0);
            Kombinationer.Add("2 par", 0);
            Kombinationer.Add("3 ens", 0);
            Kombinationer.Add("4 ens", 0);
            Kombinationer.Add("Lille straight", 0);
            Kombinationer.Add("Stor straight", 0);
            Kombinationer.Add("Hus", 0);
            Kombinationer.Add("Chance", 0);
            Kombinationer.Add("Yatzy", 0);
        }
    }
}
