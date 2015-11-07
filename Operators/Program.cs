using System;

namespace Operators
{
    class Program
    {
        private const int FARMER_PUZZLE = 1;
        private const int CALCULATOR = 2;
        private const int FACTORIAL_CALC = 3;
        private const int GUESS_NUMBER = 4;

        static void Main(string[] args)
        {
            long a;
            Console.WriteLine(@"Please,  type the number:
            1. Farmer, wolf, goat and cabbage puzzle
            2. Console calculator
            3. Factirial calculation
            4. Guess the number
            ");

            a = long.Parse(Console.ReadLine());
            switch (a)
            {
                case FARMER_PUZZLE:
                    FarmerPuzzle();
                    break;
                case CALCULATOR:
                    Calculator();
                    break;
                case FACTORIAL_CALC:
                    FactorialCalc();
                    break;
                case GUESS_NUMBER:
                    GuessTheNumber();
                    break;
                default:
                    Console.WriteLine("Exit");
                    break;
            }
            Console.WriteLine("Press any key");
            Console.ReadLine();
        }

        private static bool FarmerPuzzle()
        {
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine(FarmerMessages.ask);

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Please,  type numbers by step");
                    
            bool allowNextOption = true;
            string[] correctResults = { "3827183", "3817283" };
            string inputData = "";
            while (allowNextOption)
            {
                inputData += Console.ReadLine();
                bool isCorrectPart = false;
                for (int index = 0; index <= correctResults.Length - 1; index++)
                {
                    string currentAnswer = correctResults[index];
                    if (inputData.Length > currentAnswer.Length)
                    {
                        DrawError("To long answer");
                        return false;
                    }

                    string controlString = currentAnswer.Substring(0, inputData.Length);
                    if (controlString == inputData)
                    {
                        isCorrectPart = true;
                        if (currentAnswer.Length == inputData.Length)
                        {
                            DrawSuccess("Success");
                            return true;
                        }
                        continue;
                    }
                }

                if (isCorrectPart)
                {
                    DrawAlert("Please,  type next number");
                }
                else
                {
                    DrawError("Failure");
                    return false;
                }
            }

            return true;
        }     

        private static void Calculator()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Console Calculator");
            Console.WriteLine(' ');
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"Select the arithmetic operation:
1. Multiplication 
2. Divide 
3. Addition 
4. Subtraction
5. Exponentiation ");
            Console.ForegroundColor = ConsoleColor.Red;
            string q = Console.ReadLine();
            double a, b;

            DrawAlert("Type the first value");
            a = double.Parse(Console.ReadLine());

            DrawAlert("Type the second value");
            b = double.Parse(Console.ReadLine());

            string answer = "Wrond operation"; 
            if (q == "1")
            {
                answer = "The result of the multiplication = " + (a * b);
            }
            if (q == "2")
            {
                answer = "The result of the division = " + (a / b);
            }
            if (q == "3")
            {
                answer = "The result of the addition = " + (a + b);
            }
            if (q == "4")
            {
                answer = "The result of the subtraction = " + (a - b);
            }
            if (q == "5")
            {
                answer = "The result of a number raised to a power = " + Math.Pow(a, b);
            }

            DrawSuccess(answer);
        }

        private static void FactorialCalc()
        {
            int inputData;
            int factorial = 1;

            DrawAlert("Type the number");
            inputData = int.Parse(Console.ReadLine());

            for (var integer = inputData; integer > 1; integer--)
            {
                factorial = factorial * integer;
            }

            DrawSuccess("Factorial  = " + factorial);
        }

        private static void GuessTheNumber()
        {
            int from = 10;
            int to = 99;
            Random rnd = new Random();
            int targetNumber = rnd.Next(from, to);
            DrawAlert("Enter your guess from " + from + " to " + to + ":");

            int inputValue;
            bool allowNextOption = true;
            while (allowNextOption)
            {
                inputValue = int.Parse(Console.ReadLine());
                if (inputValue.Equals(targetNumber))
                {
                    DrawSuccess(inputValue + " is right! Congratulations.");
                    return;
                }
                else if (inputValue > targetNumber)
                {
                    DrawAlert(inputValue + " - Too high!");
                }
                else if (inputValue < targetNumber)
                {
                    DrawAlert(inputValue + " - Too low!");
                }
                DrawAlert("Enter your guess from " + from + " to " + to + ":");
            }
        }

        private static void DrawError(string message = "")
        {
            message = message.Length <= 0 ? "System error. Try later." : message;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
        }

        private static void DrawSuccess(string message = "")
        {
            message = message.Length <= 0 ? "OK" : message;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
        }

        private static void DrawAlert(string message = "")
        {
            message = message.Length <= 0 ? "Try next variant" : message;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.Blue;
        }
    }
}
