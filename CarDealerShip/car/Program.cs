using System;

namespace CarDealerShip
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                CarDealership cd = new CarDealership("inp.txt", "conInp.txt");
                Console.WriteLine(cd.getAudiPrice() + " összesen a kereskedésben tartott audik értéke");
                //Console.WriteLine(cd.isYougSkoda(10));
                if (cd.isYougSkoda(10))
                {
                    Console.WriteLine("A kereskedésben található 10 évnél fiatalabb Skoda.");
                }
                else
                {
                    Console.WriteLine("A kereskedésben nem található 10 évnél fiatalabb skoda.");
                }
                Console.WriteLine(cd.getProfit() + " a kereskedés profitja.");
                Console.WriteLine(cd.howManyContracts("GipszJakab") + " szerződés lett kötve az adott partnerrel.");
                //cd.showCars();
                cd.Clear();
            } catch (FileNotFoundException)
            {
                Console.WriteLine("File not found");
            }
        }
    }
}