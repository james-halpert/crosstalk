using System;
using System.Collections.Generic;

namespace SimpleCalculator
{
    class Program
    {
        private static int _horizontalOffset = 65;
        private static int _verticalOffset = 17;

        static void Main(string[] args)
        {
            bool Exit = false;

            while (!Exit)
            {
                DisplayUI();
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.A:
                        Console.Clear();
                        Add();
                        break;
                    case ConsoleKey.S:
                        Console.Clear();
                        Subtract();
                        break;
                    case ConsoleKey.M:
                        Console.Clear();
                        Multiply();
                        break;
                    case ConsoleKey.D:
                        Console.Clear();
                        Divide();
                        break;
                    case ConsoleKey.E:
                        Exit = true;
                        break;
                }
            }
        }

        static void DisplayUI()
        {

            Console.SetCursorPosition(_horizontalOffset, _verticalOffset);
            Console.WriteLine("Simple Calculator");
            Console.SetCursorPosition(_horizontalOffset, _verticalOffset + 2);
            Console.WriteLine("Please Select an Operation:");
            Console.SetCursorPosition(_horizontalOffset, _verticalOffset + 3);
            Console.WriteLine("(A)dd");
            Console.SetCursorPosition(_horizontalOffset, _verticalOffset + 4);
            Console.WriteLine("(S)ubtract");
            Console.SetCursorPosition(_horizontalOffset, _verticalOffset + 5);
            Console.WriteLine("(M)ultiply");
            Console.SetCursorPosition(_horizontalOffset, _verticalOffset + 6);
            Console.WriteLine("(D)ivide");
            Console.SetCursorPosition(_horizontalOffset, _verticalOffset + 7);
            Console.WriteLine("(E)xit");
            Console.SetCursorPosition(_horizontalOffset, _verticalOffset + 9);
        }

        static void DisplayInputUI(string message)
        {
            Console.SetCursorPosition(_horizontalOffset, _verticalOffset);
            Console.WriteLine(message);
            Console.SetCursorPosition(_horizontalOffset, _verticalOffset + 1);
            Console.WriteLine("Any non-numeric characters will be ignored.");
            Console.SetCursorPosition(_horizontalOffset, _verticalOffset + 2);
        }

        static void DisplayAnswerUI(string message, float answer)
        {
            Console.SetCursorPosition(_horizontalOffset, _verticalOffset + 3);
            Console.WriteLine($"{message} {answer}");
            Console.SetCursorPosition(_horizontalOffset, _verticalOffset + 4);
            Console.WriteLine("Press Enter to continue.");

            // No need for a blinking cursor to prompt the user to coninue.
            Console.CursorVisible = false;
            Console.ReadLine();
            Console.CursorVisible = true;
            Console.Clear();
        }

        static List<float> ParseInput()
        {
            List<float> parsedInput = new List<float>();

            // Obtain an array of strings separated by whitespace.
            string[] input = Console.ReadLine().Split(' ');

            // Iterate through array, parse to float, add to List<float>.
            if (input.Length != 0)
            {
                foreach (string s in input)
                {
                    try
                    {
                        parsedInput.Add(float.Parse(s));
                    }
                    // System.FormatException is thrown by Float.Parse on non-numeric strings.
                    // This is a cheap (read: hack) way to deal with that.
                    catch (Exception e)
                    {
                    }
                }
            }
            return parsedInput;
        }

        static void Add()
        {
            List<float> input = new List<float>();
            float answer = 0;

            DisplayInputUI("Please enter any number of addends separated by white spaces and then hit enter for sum.");
            input = ParseInput();

            foreach(float f in input)
            {
                answer += f;
            }

            DisplayAnswerUI("The sum of those addens is:", answer);
        }
        
        static void Subtract()
        {
            bool invalid = false;
            float minuend;
            List<float> input = new List<float>();

            while (true)
            {

                Console.Clear();
                if (invalid)
                {
                    Console.SetCursorPosition(_horizontalOffset, _verticalOffset - 1);
                    Console.WriteLine("Invalid number entered");
                    invalid = false;
                }

                DisplayInputUI("Please enter the number to subtract from.");

                try
                {
                    minuend = float.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception e)
                {
                    invalid = true;
                }
            }

            Console.Clear();
            DisplayInputUI("Please enter in any number of numbers to subtract from the first.");
            input = ParseInput();

            foreach(float f in input)
            {
                minuend -= f;
            }

            DisplayAnswerUI("The difference of those numbers is:", minuend);
        }

        static void Multiply()
        {
            List<float> input = new List<float>();
            // Setting the answer to 1 causes an issue when no valid factors are entered.
            // Answer is displayed as "1" in that instance.
            float answer = 1;

            DisplayInputUI("Please enter any number of factors separated by white spaces and then hit enter for product.");
            input = ParseInput();

            foreach(float f in input)
            {
                answer *= f;
            }

            DisplayAnswerUI("The product of those factors is:", answer);
        }

        static void Divide()
        {
            bool invalid = false;
            float dividend;
            List<float> input = new List<float>();

            while (true)
            {

                Console.Clear();
                if (invalid)
                {
                    Console.SetCursorPosition(_horizontalOffset, _verticalOffset - 1);
                    Console.WriteLine("Invalid number entered");
                    invalid = false;
                }
                Console.SetCursorPosition(_horizontalOffset, _verticalOffset);
                Console.WriteLine("Please enter the dividend.");
                Console.SetCursorPosition(_horizontalOffset, _verticalOffset + 1);
                Console.WriteLine("Any non-numeric characters will be ignored.");
                Console.SetCursorPosition(_horizontalOffset, _verticalOffset + 2);

                DisplayInputUI("Please enter the dividend.");

                try
                {
                    dividend = float.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception e)
                {
                    invalid = true;
                }
            }

            Console.Clear();
            DisplayInputUI("Please enter in any number of divisors to sequentially divide the dividend by.");
            input = ParseInput();
            
            foreach(float f in input)
            {
                // Avoid division by 0.
                if(f != 0)
                {
                    dividend /= f;
                }
            }

            DisplayAnswerUI("The quotient of those divisors is:", dividend);
        }
    }
}
