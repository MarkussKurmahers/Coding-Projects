using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography.X509Certificates;
using System.Transactions;

namespace calc
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 0;
            int n = 0;
            int x = 0;
            int y = 1;
            string a = "";
            float n1 = 0.0f;
            float n2 = 0.0f;
            float n3 = 0.0f; 
            string UserInput = ""; 
            float result = 0; // Values I use through the code to control it
            Console.WriteLine("Hello and welcome to your MarkussCORP calculations! Remember, if you will do a function with just one number, the first number will only matter!");
            Console.WriteLine("You can input 'pi'= 3.141592653 or 'e' = 2.718281828 .");


            while (i != 1) // While loop which Loops the entire program 
            {
                while (n != 1) // While loop controls if the user wants to use the result and functions with only 1 number neccessary
                {
                    x = 0;
                    y = 1;
                    int o = 0;
                    Console.WriteLine("Input your number");
                    while (o != 1) // While loop checks, what the user has input
                    {
                        a = Console.ReadLine(); // User input
                        if (CheckInput(a)) // Checks if the input is usable 
                        {
                            if (CheckPi(a)) // Checks if the user input is pi
                            {
                                float pi = 3.141592653f;
                                n1 = pi;
                            }
                            else if (CheckE(a)) // Checks if the user input is e
                            {
                                float e = 2.718281828f;
                                n1 = e;
                            }
                            else // Parses the string into float, if not pi or e
                            {
                                n1 = float.Parse(a);
                            }
                            o = 1;
                        }
                        else // If it has something other than the numbers we need, it loops back to ask for number again
                        {
                            o = 0;
                            Console.WriteLine("Input a NUMBER");
                        }
                    }
                    Console.WriteLine("'+' to add");
                    Console.WriteLine("'-' to substract");
                    Console.WriteLine("'x' to multiply");
                    Console.WriteLine("'/' to divide");
                    Console.WriteLine("'xy' raise the number to the power of y");
                    Console.WriteLine("'sqrx' to obtain square root of the number");
                    Console.WriteLine("'x!' to obtain the factorial of the number");
                    Console.WriteLine("'1/x' to obtain inverse of the number");
                    Console.WriteLine("'log' to obtain logarithm with the base of 10");
                    Console.WriteLine("'ln' to obtain logarithm of your chosen number");
                    UserInput = Console.ReadLine(); // Tells the user all of the options and asks to input one of them
                    while (!CheckFunc(UserInput)) // Checks, if the user has input a function
                    {
                        Console.WriteLine("Input a correct function");
                        UserInput = Console.ReadLine();
                    }
                    if (UserInput == "sqrx") // Checks which function the user has input, finds the right one and does it
                    {
                        n3 = Resultofsqrroot(n1);
                        result = n3;
                        Console.WriteLine(n3);
                        x = 1;
                    }
                    else if (UserInput == "x!")
                    {
                        n3 = Resultoffactorial(n1);
                        result = n3;
                        Console.WriteLine(n3);
                        x = 1;
                    }
                    else if (UserInput == "1/x")
                    {
                        n3 = Resultofinverse(n1);
                        result = n3;
                        Console.WriteLine(n3);
                        x = 1;
                    }
                    else if (UserInput == "log")
                    {
                        n3 = Resultoflog(n1);
                        result = n3;
                        Console.WriteLine(n3);
                        x = 1;
                    }
                    else if (UserInput == "ln")
                    {
                        n3 = Resultofln(n1);
                        result = n3;
                        Console.WriteLine(n3);
                        x = 1;
                    }
                    n = 1; // Makes sure the loop ends
                }
                while (x != 1) // Controls the second number input
                {
                    while (y != 1) // Controls if it needs to give out the options, depends on the user choosing to use or not use the result
                    {
                        Console.WriteLine("'+' to add");
                        Console.WriteLine("'-' to substract");
                        Console.WriteLine("'x' to multiply");
                        Console.WriteLine("'/' to divide");
                        Console.WriteLine("'xy' raise the number to the power of y");
                        Console.WriteLine("'sqrx' to obtain square root of the number");
                        Console.WriteLine("'x!' to obtain the factorial of the number");
                        Console.WriteLine("'1/x' to obtain inverse of the number");
                        Console.WriteLine("'log' to obtain logarithm with the base of 10");
                        Console.WriteLine("'ln' to obtain logarithm of your chosen number");
                        UserInput = Console.ReadLine();
                        if (UserInput == "RESET")
                        {
                            break;
                        }
                        while (!CheckFunc(UserInput))
                        {
                            Console.WriteLine("Input a correct function");
                            UserInput = Console.ReadLine();
                        }
                        y = 1;
                    }
                    int o = 0;
                    if (UserInput == "sqrx") // Checks which function the user has input, finds the right one and does it
                    {
                        o = 1;
                    }
                    else if (UserInput == "x!")
                    {
                        o = 1;
                    }
                    else if (UserInput == "1/x")
                    {
                        o = 1;
                    }
                    else if (UserInput == "log")
                    {
                        o = 1;
                    }
                    else if (UserInput == "ln")
                    {
                        o = 1;
                    }
                    else
                    {
                        x = 0;
                    }
                    while (o != 1) // While loop checks, what the user has input for the second number, the same as for the first number
                    {
                        Console.WriteLine("Input your second number");
                        a = Console.ReadLine();
                        if (CheckInput(a))  
                        {
                            if (CheckPi(a))
                            {
                                float pi = 3.141592653f;
                                n2 = pi;
                            }
                            else if (CheckE(a))
                            {
                                float e = 2.718281828f;
                                n2 = e;
                            }
                            else
                            {
                                n2 = float.Parse(a);
                            }
                            o = 1;
                        }
                        else
                        {
                            o = 0;
                            Console.WriteLine("Input a NUMBER");
                        }
                    }
                    if (UserInput == "+") // Checks which function the user has input, finds the right one and does it
                    {
                        n3 = Resultofadd(n1, n2);
                        result = n3;
                        Console.WriteLine(n3);
                        x = 1;
                    }
                    else if (UserInput == "-")
                    {
                        n3 = Resultofsubstract(n1, n2);
                        result = n3;
                        Console.WriteLine(n3);
                        x = 1;
                    }
                    else if (UserInput == "x")
                    {
                        n3 = Resultofmultiply(n1, n2);
                        result = n3;
                        Console.WriteLine(n3);
                        x = 1;
                    }
                    else if (UserInput == "/")
                    {
                        n3 = Resultofdivide(n1, n2);
                        result = n3;
                        Console.WriteLine(n3);
                        x = 1;
                    }
                    else if (UserInput == "xy")
                    {
                        n3 = Resultofraise(n1, n2);
                        result = n3;
                        Console.WriteLine(n3);
                        x = 1;
                    }
                    else if (UserInput == "sqrx")
                    {
                        n3 = Resultofsqrroot(n1);
                        result = n3;
                        Console.WriteLine(n3);
                        x = 1;
                    }
                    else if (UserInput == "x!")
                    {
                        n3 = Resultoffactorial(n1);
                        result = n3;
                        Console.WriteLine(n3);
                        x = 1;
                    }
                    else if (UserInput == "1/x")
                    {
                        n3 = Resultofinverse(n1);
                        result = n3;
                        Console.WriteLine(n3);
                        x = 1;
                    }
                    else if (UserInput == "log")
                    {
                        n3 = Resultoflog(n1);
                        result = n3;
                        Console.WriteLine(n3);
                        x = 1;
                    }
                    else if (UserInput == "ln")
                    {
                        n3 = Resultofln(n1);
                        result = n3;
                        Console.WriteLine(n3);
                        x = 1;
                    }
                    else
                    {
                        x = 0; // Asks again for the second number
                    }
                }
                Console.WriteLine("You want to go again? y/n"); // Asks the user, if he wants to go again
                string Userput = Console.ReadLine();
                if (Userput == "y")
                {
                    Console.WriteLine("Do you want to use the result? y/n"); // Asks if the user wants to use the result
                    string Userput1 = Console.ReadLine();
                    if (Userput1 == "y")
                    {
                        n1 = result;
                        x = 0;
                        n = 1; // Accordingly activates neccessary while loops
                        y = 0;
                    }
                    else if (Userput1 == "n")
                    {
                        n = 0;
                        x = 1; // Accordingly activates neccessary while loops
                    }
                }
                else if (Userput == "n")
                {
                    i = 1; // Shuts the program down
                }
            }
        }
        static float Resultofadd(float n1, float n2) // Mathematical functions
        {
            return n1 + n2;
        }
        static float Resultofsubstract(float n1, float n2)
        {
            return n1 - n2;
        }
        static float Resultofmultiply(float n1, float n2)
        {
            return n1 * n2;
        }
        static float Resultofdivide(float n1, float n2)
        {
            return n1 / n2;
        }
        static float Resultofraise(float n1, float n2)
        {
            return (float)Math.Pow(n1, n2); // x to the power of y
        }
        static float Resultofsqrroot(float n1)
        {
            return (float)Math.Sqrt(n1); // Does a square root
        }
        static float Resultoffactorial(float n1)
        {
            if (n1 <= 1)
            {
                return 1;
            }
            return n1 * Resultoffactorial(n1 - 1); // Does a factorial from a number
        }

        static float Resultofinverse(float n1)
        {
            return 1 / n1;
        }

        static float Resultoflog(float n1)
        {
            return (float)Math.Log10(n1);
        }
        static float Resultofln(float n1) // Does logarithm functions
        {
            return (float)Math.Log(n1);
        }
        static bool CheckInput(string s) // Checks if the user has input a number, pi or e
        {
            if (Int32.TryParse(s, out int b))
            {
                return true;
            }
            else if (float.TryParse(s, out float k))
            {
                return true;

            }
            else if (CheckPi(s))
            {
                return true;
            }
            else if (CheckE(s))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static bool CheckPi(string s) // Checks if the input is pi
        {
            if (s == "pi")
            {
                return true;
            }
            return false;
        }
        static bool CheckE(string s) // Checks if the input is e
        {
            if (s == "e")
            {
                return true;
            }
            return false;
        }
        static bool CheckFunc(string s) // Checks, if the input function is correct
        {
            if (s == "+")
            {
                return true;
            }
            else if (s == "-")
            {
                return true;
            }
            else if (s == "x")
            {
                return true;
            }
            else if (s == "/")
            {
                return true;
            }
            else if (s == "xy")
            {
                return true;
            }
            else if (s == "sqrx")
            {
                return true;
            }
            else if (s == "x!")
            {
                return true;
            }
            else if (s == "1/x")
            {
                return true;
            }
            else if (s == "log")
            {
                return true;
            }
            else if (s == "ln")
            {
                return true;
            }
            return false;
        }
    }
}