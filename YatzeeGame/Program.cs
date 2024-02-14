namespace YahtzeeGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //GameState er true når spillet skal køre og false når det er slukket
            bool GameState = true;
            Random dick = new Random();
            int x = 0;
            Console.WriteLine("Start");
            while (GameState == true) 
            {
                x++;
                Console.WriteLine(x + " An lemon");
                
                if (dick.Next(0, 101) == 42)
                {
                    Console.WriteLine("din mor");
                    GameState = false;
                }
            }
        }
    }
}
