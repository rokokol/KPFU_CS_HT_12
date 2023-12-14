﻿using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;

namespace HT
{
    internal class Program
    {
        /// <summary>
        /// Reads the input int. If input incorrect it ass user to try again.
        /// </summary>
        /// <returns>The input int.</returns>
        /// <param name="positiveFlag">If set to <c>true</c> input must be positive.</param>
        /// <param name="nonZero">If set to <c>true</c> input must not be zero.</param>
        static int ReadInt(bool positiveFlag, bool nonZero)
        {
            int result = 1;
            bool term = true;
            while (term)
            {
                Offer();
                bool convert = int.TryParse(Console.ReadLine(), out result);
                bool positive = (result >= 0) || !positiveFlag;
                bool noZero = (result != 0) || !nonZero;
                if (convert && positive && noZero)
                {
                    term = false;
                }
                else if (!positive)
                {
                    Console.WriteLine("The input must be positive. Please, try again:");
                }
                else
                {
                    Console.WriteLine("Incorrect input. Please, try again:");
                }
            }
            return result;
        }

        /// <summary>
        /// Writes "> " in start of the line.
        /// </summary>
        static void Offer()
        {
            Console.Write("> ");
        }
        
        /// <summary>
        /// Writes a number of the task.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="number">Number of the task.</param>
        static void Message(string message, int number)
        {
            Console.WriteLine("\nLet's check problem #{0}\nThis program {1}\nPress any to continue...", number, message);
            Offer();
            Console.ReadKey();
        }

        
        public static async Task Main(string[] args)
        {
            #region HT

            void First()
            {
                Message("makes 3 threads those prints numbers from 1 to 10:", 1);
                // Prints every second
                Thread first = new Thread(() =>
                {
                    for (int i = 0; i < 11; i++)
                    {
                        Console.WriteLine($"First: {i}");
                        Thread.Sleep(1000);
                    }
                });

                // Prints every 2 second
                Thread second = new Thread(() =>
                {
                    for (int i = 0; i < 11; i++)
                    {
                        Console.WriteLine($"Second: {i}");
                        Thread.Sleep(2000);
                    }
                });
                
                // Prints every 3 second
                Thread third = new Thread(() =>
                {
                    for (int i = 0; i < 11; i++)
                    {
                        Console.WriteLine($"Third: {i}");
                        Thread.Sleep(3000);
                    }
                });
                
                // Run them
                first.Start();
                second.Start();
                third.Start();
                Console.ReadKey();
            }

            void Second()
            {
                Message("tests async-factorial and sync-square threads", 2);
                ParameterizedThreadStart factorial = delegate(object x)
                {
                    int res = 1;
                    int i = (int)x;
                    while (i > 1)
                    {
                        res *= i--;
                    }
                    Thread.Sleep(8000);
                    Console.WriteLine(res);
                };
                
                ParameterizedThreadStart square = delegate(object x)
                {
                    Console.WriteLine((double)x * (double)x);
                };

                bool term = true;
                while (term)
                {
                    Console.WriteLine("Type \"f\" to factorial, \"s\" to square or \"e\" to exit:");
                    Offer();
                    string resp = Console.ReadLine().ToLower().Trim();
                    switch (resp)
                    {
                        case "f":
                            Thread fact = new Thread(factorial);
                            Console.WriteLine("Enter a natural number:");
                            fact.Start(ReadInt(true, false));
                            break;
                        case "s":
                            Thread sq = new Thread(square);
                            Console.WriteLine("Enter a number:");
                            Offer();
                            double x;
                            while (!double.TryParse(Console.ReadLine()?.Replace('.', ','), out x))
                            {
                                Console.WriteLine("It is not a rational number. Please, try again:");
                                Offer();
                            }
                            sq.Start(x);
                            break;
                        case "e":
                            term = false;
                            break;
                        default:
                            Console.WriteLine("Incorrect input");
                            break;
                    }
                }
            }

            void Third()
            {
                
            }

            #endregion
            
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("ru");
            bool run = true;
            while (run)
            {
                Console.WriteLine();
                Console.WriteLine(@"||===========================<\\>===========================||");
                Console.WriteLine(
                    "Please, type \"exit\" to stop a number of a task:");
                Offer();
                string respond = Console.ReadLine().ToLower().Trim();
                if (respond.Equals("exit"))
                {
                    run = false;
                    continue;
                }
                
                switch (respond)
                {
                    case "1": First(); break;
                    case "2": Second(); break;
                    case "3": Third(); break;
                    default:
                        Console.WriteLine("This is not a command or a number of task");
                        break;
                }
            }
        }
    }
}