using System;
using CarManager;
using NUnit.Framework;

namespace Tests
{
    public class CarTests
    {
        private Car testCar;
        [SetUp]
        public void Setup()
        {
            testCar = new Car("Mitsubishi", "Outlander2014", 12, 60);
        }

        [Test]
        public void TestConstructors()
        {
            string expectedMake = "Mitsubishi";
            string expectedModel = "Outlander2014";
            double expectedFuelConsumption = 12;
            double expectedFuelCapacity = 60;
            double expectedFuelAmount = 0;
            Assert.AreEqual(expectedMake, testCar.Make);
            Assert.AreEqual(expectedModel, testCar.Model);
            Assert.AreEqual(expectedFuelConsumption, testCar.FuelConsumption);
            Assert.AreEqual(expectedFuelCapacity, testCar.FuelCapacity);
            Assert.AreEqual(expectedFuelAmount, testCar.FuelAmount);
        }

        [Test]
        public void TestIfMakeThrowsExceptionIfValueIsNullOrEmpty()
        {
            Assert.Throws<ArgumentException>(() => testCar = new Car(null, "Outlander2014", 2, 60));
            Assert.Throws<ArgumentException>(() => testCar = new Car(String.Empty, "Outlander2014", 2, 60));
        }

        [Test]
        public void TestIfModelThrowsExceptionIfValueIsNullOrEmpty()
        {
            Assert.Throws<ArgumentException>(() => testCar = new Car("Mitsubishi", null, 2, 60));
            Assert.Throws<ArgumentException>(() => testCar = new Car("Mitsubishi", String.Empty, 2, 60));
        }

        [Test]
        public void TestIfFuelConsumptionThrowsExceptionIfValueIsNegativeOrEqualToZero()
        {
            Assert.Throws<ArgumentException>(() => testCar = new Car("Mitsubishi", "Outlander2014", 0, 60));
            Assert.Throws<ArgumentException>(() => testCar = new Car("Mitsubishi", "Outlander2014", -200, 60));
        }

        [Test]
        public void TestIfFuelCapacityThrowsExceptionIfValueIsNegativeOrEqualToZero()
        {
            Assert.Throws<ArgumentException>(() => testCar = new Car("Mitsubishi", "Outlander2014", 2, 0));
            Assert.Throws<ArgumentException>(() => testCar = new Car("Mitsubishi", "Outlander2014", 2, -222));
        }

        [Test]
        public void TestRefuelMethod()
        {
            testCar.Refuel(12);
            double expectedFuel = 12;
            Assert.AreEqual(expectedFuel, testCar.FuelAmount);
        }

        [Test]
        public void TesIfRefuelThrowsExceptionIfNegativeOrEqualToZeroValueIsGiven()
        {
            Assert.Throws<ArgumentException>(() => testCar.Refuel(-1));
            Assert.Throws<ArgumentException>(() => testCar.Refuel(0));
        }

        [Test]
        public void TestIfRefuelHandlesFuelOverflow()
        {
            testCar.Refuel(80);
            double expectedFuel = 60;
            Assert.AreEqual(expectedFuel,testCar.FuelAmount);
        }

        [Test]
        public void TestDrive()
        {
            testCar.Refuel(60);
            decimal expectedFuelAmount = 45.6M;
            testCar.Drive(120);
            Assert.AreEqual(expectedFuelAmount,testCar.FuelAmount);
        }

        [Test]
        public void TestIfDriveThrowsExceptionIfThereIsNotEnoughFuelForDriving()
        {
            Assert.Throws<InvalidOperationException>(() => testCar.Drive(12));
        }
    }
}