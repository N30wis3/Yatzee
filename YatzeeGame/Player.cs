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

        public Player(string name = "Bob", int id = 0)
        {
            Name = name;
            ID = id;
        }
    }
}