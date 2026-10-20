using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace numble
{
    internal class Program
    {
        static int[] Mechanics(int[] Inputter, List<string> HistoryInput)
        {
            int counter = 6;
            while (counter != 0)
            {
                Console.Clear();
                if (HistoryInput.Count != 0)
                {
                    Console.WriteLine("History guesses");
                    foreach (string i in HistoryInput)
                    {
                        Console.WriteLine(i);
                    }
                }
                Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
                Console.WriteLine($"Attempt amount: {counter}");
                Console.Write("Input 1: ");
                string input = Console.ReadLine();

                if (!int.TryParse(input, out int number))
                {
                    Console.WriteLine("Please enter a valid number!");
                    Console.ReadKey();
                    continue;
                }

                if (number < 1 || number > 6)
                {
                    Console.WriteLine("Please input number between 1-6");
                    Console.ReadKey();
                    continue;
                }

                Inputter[0] = number;

                Console.Write("Input 2: ");
                string input2 = Console.ReadLine();

                if (!int.TryParse(input2, out int number2))
                {
                    Console.WriteLine("Please enter a valid number!");
                    Console.ReadKey();
                    continue;
                }
                if (number2 < 1 || number2 > 6)
                {
                    Console.WriteLine("Please input number between 1-6");
                    Console.ReadKey();
                    continue;
                }
                if (number == number2)
                {
                    Console.WriteLine("You must have 3 distinct numbers");
                    Console.ReadKey();
                    continue;
                }

                Inputter[1] = number2;

                Console.Write("Input 3: ");
                string input3 = Console.ReadLine();

                if (!int.TryParse(input3, out int number3))
                {
                    Console.WriteLine("Please enter a valid number!");
                    Console.ReadKey();
                    continue;
                }
                if (number3 < 1 || number3 > 6)
                {
                    Console.WriteLine("Please input number between 1-6");
                    Console.ReadKey();
                    continue;
                }
                if (number3 == number2 || number3 == number)
                {
                    Console.WriteLine("You must have 3 distinct numbers");
                    Console.ReadKey();
                    continue;
                }
                Inputter[2] = number3;

                counter--;
                checker(Inputter, HistoryInput);
            }
            return Inputter;
        }
        static void checker(int[] Inputter, List<string> HistoryInput)
        {
            int correct_position = 0;
            int correct_digit = 0;
            int[] RealNumberOfTheDay = { 2, 5, 3 };

            // checks if the digit is right
            for (int i = 0; i < 3; i++)
            {
                if (Inputter[i] == RealNumberOfTheDay[i])
                {
                    correct_position++;
                    correct_digit++;
                }
                else
                {
                    for (int j = 0; j < 3; j++)
                    {//checks if position is correct
                        if (Inputter[i] == RealNumberOfTheDay[j])
                        {
                            correct_digit++;
                        }
                    }
                }
            }

            if (correct_position == 3)
            {
                Console.Clear();
                Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
                Console.WriteLine("you guessed the correct number");
                Console.WriteLine("Congratulations, you win !!!");
                Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
                Console.ReadKey();
                Environment.Exit(0);
            }

            Console.WriteLine($"Correct Posiion:{correct_position} ");
            Console.WriteLine($"Correct digit: {correct_digit} ");

            Console.ReadKey();

            string digit = string.Join("", Inputter);
            string history = $"Number: {digit} = correct position: {correct_position}, correct digit: {correct_digit}";

            HistoryInput.Add(history);

            correct_position = 0;
            correct_digit = 0;

        }
        static void Main(string[] args)
        {
            int[] Inputter = new int[3];
            List<string> HistoryInput = new List<string>();
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
            Console.WriteLine("Welcome to Numble!\n");
            Console.WriteLine("Guess the 3-digit number within 6 attempts.\n");
            Console.WriteLine("- Each digit must be between 1 and 6.");
            Console.WriteLine("- All three digits must be distinct.");
            Console.WriteLine("- After each guess, you'll be told how many digits are correct and how many are in the correct position.");
            Console.WriteLine("- Use the feedback and your guess history to figure out the secret number\n");


            Console.WriteLine("Press any key continue");

            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");

            Console.ReadKey();
            Console.Clear();

            Mechanics(Inputter, HistoryInput);
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
            Console.WriteLine("You lost !!!");
            Console.WriteLine("Restart the game to re-try");
            Console.WriteLine("Press any key leave");
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}
