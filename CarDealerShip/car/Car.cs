using System;
using System.Runtime.CompilerServices;
using System.Text;
using TextFile;

namespace CarDealerShip
{

    public enum Fuel
    {
        Diesel,
        Fuel,
        Hibrid,
        Electric
    };

    public enum Brand
    {
        Audi,
        Mazda,
        Skoda
    };

    public class Car
    {
        public class EmptyRowException : Exception { }
        private List<Contract> contracts = new();
        private Fuel fuel;
        private string iD;
        private Brand brand;
        private int newPrice;
        private double CurrentPrize;
        private int cp;
        private int Year;
        private bool isInDs;
        public Car(string iD, int newPrice, int Year, Fuel f, Brand b)
        {
            this.brand = b;
            this.fuel = f;
            this.iD = iD;
            this.newPrice = newPrice;
            this.CurrentPrize = newPrice * (100 - (2023 - Year)) / (100 * getFactor());
            this.cp = Convert.ToInt32(Math.Round(CurrentPrize));
        }
        public void setContracts(List<Contract> cont)
        {
            foreach (Contract c in cont)
            {
                if (c.getCar().getid() == this.iD)
                {
                    if (!c.isBuying())
                    {
                        isInDs = false;
                    }
                    else if (c.isBuying())
                    {
                        isInDs = true;
                    }
                }
            }
        }
        public bool getIsInDs()
        {
            return isInDs;
        }
        public void setIsInDs(bool l)
        {
            this.isInDs = l;
        }
        public void showContracts()
        {
            Console.WriteLine(getIsInDs());
        }
        public int getPrice()
        {
            return cp;
        }

        public Brand GetBrand()
        {
            return brand;
        }
        public int getAge()
        {
            return 2023 - Year;
        }
        public string getid()
        {
            return iD;
        }
        private double getFactor()
        {
            if (this.brand == Brand.Audi)
            {
                if (this.fuel == Fuel.Fuel) { return 1.0; }
                else if (this.fuel == Fuel.Hibrid) { return 1.3; }
                else if (this.fuel == Fuel.Diesel) { return 0.9; }
                else if (this.fuel == Fuel.Electric) { return 1.2; }
                else { return 0; }
            }
            else if (this.brand == Brand.Mazda)
            {
                if (this.fuel == Fuel.Fuel) { return 2.0; }
                else if (this.fuel == Fuel.Hibrid) { return 2.3; }
                else if (this.fuel == Fuel.Diesel) { return 2.0; }
                else if (this.fuel == Fuel.Electric) { return 2.5; }
                else { return 0; }
            }
            else if (this.brand == Brand.Skoda)
            {
                if (this.fuel == Fuel.Fuel) { return 3.0; }
                else if (this.fuel == Fuel.Hibrid) { return 4.0; }
                else if (this.fuel == Fuel.Diesel) { return 3.1; }
                else if (this.fuel == Fuel.Electric) { return 3.8; }
                else { return 0; }
            }
            else { return 0; }
        }
        public static bool Read(TextFileReader reader, out Car car)
        {
            if (reader.ReadLine(out string line))
            {
                if (line == "") throw new EmptyRowException();
                char[] separators = new char[] { ' ', '\t' };
                string[] tokens = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);

                string id = tokens[0];
                int p = Int32.Parse(tokens[1]);
                int y = Int32.Parse(tokens[2]);
                Fuel f;
                if (tokens[3] == "Fuel") { f = Fuel.Fuel; }
                else if (tokens[3] == "Hibrid") { f = Fuel.Hibrid; }
                else if (tokens[3] == "Electric") { f = Fuel.Electric; }
                else { f = Fuel.Diesel; }
                Brand b;
                if (tokens[4] == "Audi") { b = Brand.Audi; }
                else if (tokens[4] == "Skoda") { b = Brand.Skoda; }
                else { b = Brand.Mazda; }

                car = new Car(id, p, y, f, b);
                return true;
            }
            else
            {
                car = new("", 0, 0, Fuel.Diesel, Brand.Audi);
                return false;
            }
        }
    }
}
