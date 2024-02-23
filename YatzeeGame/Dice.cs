using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YahtzeeGame
{
    public class Dice
    {
        public int Sides { get; set; }



        public int DiceRoll(int Sides)
        {
            Random Roll = new Random();
            int RandomRoll = Roll.Next(1, Sides + 1);
            return RandomRoll;
        }
    }
}