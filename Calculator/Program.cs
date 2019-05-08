using System;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            //Game1();
            Game2();
        }

        private static void Game2()
        {
            for(int currentWinCount = 0; currentWinCount < 75; currentWinCount++)
            {
                var calc = new Calc();
                var result = calc.JasonAlg(0.33d, 0d, currentWinCount, 75d);
                Console.WriteLine(currentWinCount + " : " + result);
            }
            Console.ReadLine();
        }

        private static void Game1()
        {
            bool keepPlaying = true;
            while (keepPlaying)
            {
                Console.WriteLine("We're executing the algorithm y = width(x^power) + max");
                Console.WriteLine("We'll put a floor on y of min probability");
                var min = GetValueWithPrompt("Enter min probability: ");
                var max = GetValueWithPrompt("Enter max probability: ");
                var count = GetValueWithPrompt("Enter prior win count: ");
                var maxWinCount = GetValueWithPrompt("Enter max win count before permanent min return: ");
                var calc = new Calc();

                var result = calc.JasonAlg(max, min, count, maxWinCount);

                Console.WriteLine("Your result: " + result);

                Console.WriteLine("Again? y or n");
                var playAgain = Console.ReadLine();
                if (playAgain.ToLower() != "y")
                {
                    keepPlaying = false;
                }
            }
        }

        private static double GetValueWithPrompt(string prompt)
        {
            Console.WriteLine(prompt);
            string foo = Console.ReadLine();

            double.TryParse(foo, out double count);

            return count;
        }
    }
}
