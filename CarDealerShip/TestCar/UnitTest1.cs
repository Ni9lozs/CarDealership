using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CarDealerShip;
using TextFile;

namespace TestCar
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestOK1() 
        {
            var ds = new CarDealership("sdadsa");
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            string[] tokens = new string[] { "AudiHungaryZrt AudiA4 2000 2013 Fuel Audi 20220202 GipszJakab 100000 S\r\nAudiHungaryZrt AudiA4 2000 2013 Fuel Audi 20220202 GipszJakab 100000 S\r\nAudiHungaryZrt AudiA4 2000 2013 Fuel Audi 20220202 GipszJakab 100000 S\r\nAudiHungaryZrt AudiA4 2000 2013 Fuel Audi 20220202 GipszJakab 100000 S\r\nAudiHungaryZrt AudiA4 2000 2013 Fuel Audi 20220202 GipszJakab 100000 S\r\nAudiHungaryZrt AudiA4 2000 2013 Fuel Audi 20220202 GipszJakab 100000 S\r\nAudiHungaryZrt AudiA4 2000 2013 Fuel Audi 20220202 GipszJakab 100000 S\r\nAudiHungaryZrt AudiA4 2000 2013 Fuel Audi 20220202 GipszJakab 100000 S\r\nAudiHungaryZrt AudiA4 2000 2013 Fuel Audi 20220202 GipszJakab 100000 S\r\nAudiHungaryZrt AudiA4 2000 2013 Fuel Audi 20220202 GipszJakab 100000 S\r\nAudiHungaryZrt AudiA4 2000 2013 Fuel Audi 20220202 GipszJakab 100000 S\r\nAudiHungaryZrt AudiA4 2000 2013 Fuel Audi 20220202 GipszJakab 100000 B\r\nAudiHungaryZrt AudiA4 2000 2013 Fuel Audi 20220202 GipszJakab 100000 B\r\nAudiHungaryZrt AudiA4 2000 2013 Fuel Audi 20220202 GipszJakab 100000 B\r\nAudiHungaryZrt AudiA4 2000 2013 Fuel Audi 20220202 GipszJakab 100000 B\r\nAudiHungaryZrt AudiA4 2000 2013 Fuel Audi 20220202 GipszJakab 100000 B\r\nAudiHungaryZrt AudiA4 2000 2013 Fuel Audi 20220202 GipszJakab 100000 B\r\nAudiHungaryZrt AudiA4 2000 2013 Fuel Audi 20220202 GipszJakab 100000 B\r\nAudiHungaryZrt AudiA4 2000 2013 Fuel Audi 20220202 GipszJakab 100000 Bss" };
            string[] tokens2 = new string[] { "AudiA1 2000 2013 Fuel Audi\r\nAudiA4 2000 2013 Fuel Audi\r\nAudiA4 2000 2013 Fuel Audi\r\nAudiA3 2000 2013 Fuel Audi\r\nAudiA4 2000 2013 Fuel Audi\r\nAudiA5 2000 2013 Fuel Audi\r\nAudiA4 2000 2013 Fuel Audi\r\nAudiA4 2000 2013 Fuel Audi\r\nSkoda 2500 2022 Hibrid Skoda" };
            Assert.AreEqual(500000, ds.getProfit());
            Assert.AreEqual(19, ds.howManyContracts("GipszJakab"));
            Assert.AreEqual(true, ds.isYougSkoda(10));
            Assert.AreEqual(48600, ds.getAudiPrice());
        }
    }
}