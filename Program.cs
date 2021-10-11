using System;

namespace HomeTask_6
{
    class Program
    {
        static void Main(string[] args)
        {
            //First Task 

            Polynom polynom = 7.2; //implicit

            Console.WriteLine(polynom);

            InputFromConsole.Start();

            ////Second Task

            var SiteTraffic = new SiteTrafficStatistics();

            SiteTraffic.ReadDataFromFile(@"D:\Users\vital\source\repos\HomeTask_6\input.txt");

            Console.WriteLine(SiteTraffic);

            Console.WriteLine("This visitor 139.18.150.126 visit site: " + SiteTraffic.GetCountOfVisit("139.18.150.126") + " times\n");

            Console.WriteLine("This visitor 139.18.150.126 most often visited the site on " + SiteTraffic.GetTheMostPopularDay("139.18.150.126"));

            Console.WriteLine($"\nThis visitor 139.18.150.126 most often visited the site at {SiteTraffic.GetTheMostPopularHourForVisitor("139.18.150.126")} o'clock");

            Console.WriteLine($"\nMost often visited the site at {SiteTraffic.GetTheMostPopularHourForSite()} o'clock.");



            // Third Task

            double[,] arr = new double[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };

            Matrix matrix = new Matrix();

            matrix.Array = arr;

            int index = -1;

            foreach (var item in matrix)
            {
                index++;
                Console.Write(item + " ");
                if (index == matrix.Array.GetLength(1) - 1)
                {
                    index = -1;
                    Console.WriteLine();
                }
            }
        }
    }
}
