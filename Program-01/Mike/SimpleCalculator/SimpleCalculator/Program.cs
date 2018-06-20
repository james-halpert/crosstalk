using System;

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

        static void Add()
        {
            string[] input;
            float answer = 0;

            Console.SetCursorPosition(_horizontalOffset, _verticalOffset);
            Console.WriteLine("Please enter any number of addends separated by white spaces and then hit enter for sum.");
            Console.SetCursorPosition(_horizontalOffset, _verticalOffset + 1);
            Console.WriteLine("Any non-numeric characters will be ignored.");
            Console.SetCursorPosition(_horizontalOffset, _verticalOffset + 2);

            // Obtain an array of strings separated by whitespace.
            input = Console.ReadLine().Split(' ');
            
            foreach(string s in input)
            {
                try
                {
                    answer += float.Parse(s);
                }
                // System.FormatException is thrown by Float.Parse on non-numeric strings. 
                // This is a cheap (read: hack) way to deal with that.
                catch (Exception e)
                {
                }
            }

            Console.SetCursorPosition(_horizontalOffset, _verticalOffset + 3);
            Console.WriteLine($"The sum of those addens is: {answer}");
            Console.SetCursorPosition(_horizontalOffset, _verticalOffset + 4);
            Console.WriteLine("Press Enter to continue.");
            // No need for a blinking cursor to prompt the user to coninue.
            Console.CursorVisible = false;
            Console.ReadLine();
            Console.CursorVisible = true;
            Console.Clear();
        }
        
        static void Subtract()
        {
            bool invalid = false;
            float minuend;
            string[] subtrahend;

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
                Console.WriteLine("Please enter the number to subtract from.");
                Console.SetCursorPosition(_horizontalOffset, _verticalOffset + 1);
                Console.WriteLine("Any non-numeric characters will be ignored.");
                Console.SetCursorPosition(_horizontalOffset, _verticalOffset + 2);

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

            Console.SetCursorPosition(_horizontalOffset, _verticalOffset + 2);
            Console.WriteLine("Please enter in any number of numbers to subtract from the first.");
            Console.SetCursorPosition(_horizontalOffset, _verticalOffset + 3);
            Console.WriteLine("Any non-numeric characters will be ignored.");
            Console.SetCursorPosition(_horizontalOffset, _verticalOffset + 4);
            // Obtain an array of strings separated by whitespace.
            subtrahend = Console.ReadLine().Split(' ');
            
            foreach(string s in subtrahend)
            {
                try
                {
                    minuend -= float.Parse(s);
                }
                // System.FormatException is thrown by Float.Parse on non-numeric strings. 
                // This is a cheap (read: hack) way to deal with that.
                catch (Exception e)
                {
                }
            }

            Console.SetCursorPosition(_horizontalOffset, _verticalOffset + 5);
            Console.WriteLine($"The difference of those numbers is: {minuend}");
            Console.SetCursorPosition(_horizontalOffset, _verticalOffset + 6);
            Console.WriteLine("Press Enter to continue.");
            // No need for a blinking cursor to prompt the user to coninue.
            Console.CursorVisible = false;
            Console.ReadLine();
            Console.CursorVisible = true;
            Console.Clear();
        }

        static void Multiply()
        {
            string[] input;
            // Setting the answer to 1 causes an issue when no valid factors are entered.
            // Answer is displayed as "1" in that instance.
            float answer = 1;

            Console.SetCursorPosition(_horizontalOffset, _verticalOffset);
            Console.WriteLine("Please enter any number of factors separated by white spaces and then hit enter for product.");
            Console.SetCursorPosition(_horizontalOffset, _verticalOffset + 1);
            Console.WriteLine("Any non-numeric characters will be ignored.");
            Console.SetCursorPosition(_horizontalOffset, _verticalOffset + 2);

            // Obtain an array of strings separated by whitespace.
            input = Console.ReadLine().Split(' ');
            
            foreach(string s in input)
            {
                try
                {
                    answer *= float.Parse(s);
                }
                // System.FormatException is thrown by Float.Parse on non-numeric strings. 
                // This is a cheap (read: hack) way to deal with that.
                catch (Exception e)
                {
                }
            }

            Console.SetCursorPosition(_horizontalOffset, _verticalOffset + 3);
            Console.WriteLine($"The product of those factors is: {answer}");
            Console.SetCursorPosition(_horizontalOffset, _verticalOffset + 4);
            Console.WriteLine("Press Enter to continue.");
            // No need for a blinking cursor to prompt the user to coninue.
            Console.CursorVisible = false;
            Console.ReadLine();
            Console.CursorVisible = true;
            Console.Clear();
        }

        static void Divide()
        {
            bool invalid = false;
            float dividend;
            string[] divisor;

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

            Console.SetCursorPosition(_horizontalOffset, _verticalOffset + 2);
            Console.WriteLine("Please enter in any number of divisors to sequentially divide the dividend by.");
            Console.SetCursorPosition(_horizontalOffset, _verticalOffset + 3);
            Console.WriteLine("Any non-numeric characters will be ignored.");
            Console.SetCursorPosition(_horizontalOffset, _verticalOffset + 4);
            // Obtain an array of strings separated by whitespace.
            divisor = Console.ReadLine().Split(' ');
            
            foreach(string s in divisor)
            {
                try
                {
                    // Avoid division by 0.
                    if(float.Parse(s) != 0)
                    {
                        dividend /= float.Parse(s);
                    }
                }
                // System.FormatException is thrown by Float.Parse on non-numeric strings. 
                // This is a cheap (read: hack) way to deal with that.
                catch (Exception e)
                {
                }
            }

            Console.SetCursorPosition(_horizontalOffset, _verticalOffset + 5);
            Console.WriteLine($"The quotient of those divisors is: {dividend}");
            Console.SetCursorPosition(_horizontalOffset, _verticalOffset + 6);
            Console.WriteLine("Press Enter to continue.");
            // No need for a blinking cursor to prompt the user to coninue.
            Console.CursorVisible = false;
            Console.ReadLine();
            Console.CursorVisible = true;
            Console.Clear();
        }
    }
}
