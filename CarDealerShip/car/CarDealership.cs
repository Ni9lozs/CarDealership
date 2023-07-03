using System;
using System.Globalization;
using System.Transactions;
using TextFile;


namespace CarDealerShip
{
    public class CarDealership
    {
        List<Car> cars = new();
        List<Contract> contracts = new();
        private string iD;
        private int profit = 0;
        private int Audi = 0;
        private int ccontract = 0;
        private bool l;
        public CarDealership(string id)
        {
            this.iD = id;
        }
        public CarDealership(string carsFile, string contractsFile)
        {
            TextFileReader reader = new(carsFile);
            while (Car.Read(reader, out Car car))
            {
                cars.Add(car);
                car.setIsInDs(true);
            }
            TextFileReader reader2 = new(contractsFile);
            while (Contract.Read(reader2, out Contract contract))
            {
                contracts.Add(contract);
            }
            foreach (Contract c in contracts)
            {
                    cars.Add(c.getCar());
            }
            foreach (Car c in cars)
            {
                c.setContracts(contracts);
                c.setIsInDs(true);
            }
        }
        public void showCars()
        {
            foreach (Car c in cars)
            {
                Console.WriteLine(c.getid());
                c.showContracts();
            }
        }
        public string getId()
        {
            return iD;
        }
        public  int getProfit()
        {
            foreach (Contract c in contracts)
            {
                    if (c.isBuying())
                    {
                        profit -= c.getPrice();
                    }
                    else if (!c.isBuying())
                    {
                        profit += c.getPrice();
                    }
            }
            return profit;
        }
        public int getAudiPrice()
        {
            //Console.WriteLine(Audi);
            foreach (Car c in cars)
            {
                if (c.GetBrand() == Brand.Audi && c.getIsInDs())
                {
                    //Console.WriteLine(c.getPrice() + " " + c.getid());
                    Audi += c.getPrice();
                }
            }
            return Audi;
        }
        public int howManyContracts(string id)
        {
            foreach (Contract c in contracts)
            {
                if (c.getPartner().getID() == id)
                {
                    ccontract++;
                }
            }
            return ccontract;
        }
        public bool isYougSkoda(int year)
        {
            foreach (Car c in cars)
            {
                if ((c.GetBrand() == Brand.Skoda) && ((2023 - c.getAge()) < year))
                {
                    this.l = true;
                    break;
                }
            }
            return this.l;
        }
        public void Clear()
        {
            cars.Clear();
            contracts.Clear();
        }
    }
}