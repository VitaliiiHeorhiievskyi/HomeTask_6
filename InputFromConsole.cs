using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask_6
{
    class InputFromConsole
    {
        public static void Start()
        {

            Console.WriteLine("Hello\n");
            Polynom firstPolynom = null;
            Polynom secondPolynom = null;

            while (true)
            {
                try
                {
                    Console.WriteLine("Enter First polynom:");

                    firstPolynom = new Polynom(Console.ReadLine());
                    break;
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Data is not correct!");
                    Console.ResetColor();
                }
            }
            while (true)
            {
                try
                {
                    Console.WriteLine("\nEnter Second polynom:");

                    secondPolynom = new Polynom(Console.ReadLine());
                    break;
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Data is not correct!");
                    Console.ResetColor();
                }
            }

            int choice = 0;
            while (true)
            {
                try
                {
                    Console.WriteLine(firstPolynom.PrintMenu());
                    choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 0:
                            return;

                        case 1:
                            Console.WriteLine("\nFirst polynom: " + firstPolynom);
                            break;
                        case 2:
                            Console.WriteLine("\nSecond polynom: " + secondPolynom);
                            break;
                        case 3:
                            Console.WriteLine("Result of add: \n" + (firstPolynom + secondPolynom));
                            break;
                        case 4:
                            Console.WriteLine("Result of subtraction: \n" + (firstPolynom - secondPolynom));
                            break;
                        case 5:
                            {
                                Console.WriteLine("Enter Rank: ");

                                bool res = int.TryParse(Console.ReadLine(), out int Rank);
                                if (!res)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("\n\nThe data is not correct!! Rank must be integer!!\n");
                                    Console.ResetColor();
                                    break;
                                }

                                Console.WriteLine("Enter Value: ");

                                res = double.TryParse(Console.ReadLine(), out double value);
                                if (!res)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("\n\nThe data is not correct!! Value must be double!!\n");
                                    Console.ResetColor();
                                    break;
                                }
                                firstPolynom[Rank] = value;
                                secondPolynom[Rank] = value;
                                break;
                            }
                        case 6:
                            Console.WriteLine("Result of multiply: \n" + (firstPolynom * secondPolynom));
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nData is not correct!!");
                    Console.ResetColor();
                }
            }


        }
    }
}
