using System;
using TextFile;
using System.Text;

namespace CarDealerShip
{
    public enum Type { Buy, Sell };
    public class Contract
    {
        private CarDealership dealership;
        private Car car;
        private int Date;
        private Partner partner;
        private int Price;
        private Type type;
        public Contract(CarDealership dealership, Car car, int Date, Partner partner, int Price, Type t)
        {
            this.dealership = dealership;
            this.car = car;
            this.partner = partner;
            this.Date = Date;
            this.Price = Price;
            this.type = t;
        }

        public bool isBuying()
        {
            if (type == Type.Buy) return true;
            else if (type == Type.Sell) return false;
            else return true;
        }

        public int getPrice()
        {
            return Price;
        }
        public Car getCar()
        {
            return car;
        }
        public Partner getPartner() { return partner; }

        public static bool Read(TextFileReader reader, out Contract contract)
        {
            if (reader.ReadLine(out string line))
            {
                Car c;
                string carid;
                int carprice;
                int caryear;
                Fuel carfuel;
                Brand b;
                int Date;
                Partner p;
                int price;
                Type t;
                CarDealership dealership;

                char[] separators = new char[] { ' ', '\t' };
                string[] tokens = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);

                dealership = new CarDealership(tokens[0]);
                carid = tokens[1];
                carprice = Int32.Parse(tokens[2]);
                caryear = Int32.Parse(tokens[3]);
                if (tokens[4] == "Fuel") { carfuel = Fuel.Fuel; }
                else if (tokens[4] == "Hibrid") { carfuel = Fuel.Hibrid; }
                else if (tokens[4] == "Electric") { carfuel = Fuel.Electric; }
                else { carfuel = Fuel.Diesel; }

                if (tokens[5] == "Audi") { b = Brand.Audi; }
                else if (tokens[5] == "Skoda") { b = Brand.Skoda; }
                else { b = Brand.Mazda; }

                c = new Car(carid, carprice, caryear, carfuel, b);
                Date = Int32.Parse(tokens[6]);
                p = new Partner(tokens[7]);
                price = Int32.Parse(tokens[8]);
                if (tokens[9] == "B")
                {
                    t = Type.Buy;
                }
                else
                {
                    t = Type.Sell;
                }

                contract = new Contract(dealership, c, Date, p, price, t);
                return true;
            }
            else
            {
                CarDealership noDealership = new CarDealership("");
                Car NoCar = new Car("", 0, 0, Fuel.Hibrid, Brand.Audi);
                Partner noPartner = new Partner("");
                contract = new Contract(noDealership, NoCar, 0, noPartner, 0, Type.Sell);
                return false;
            }
        }
    }
}