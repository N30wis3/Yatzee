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
        static void ScoreBoard(ref List<int> Rolls, ref List<Player> players, ref int PlayerTurn)
        {
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
        }
    }
}
