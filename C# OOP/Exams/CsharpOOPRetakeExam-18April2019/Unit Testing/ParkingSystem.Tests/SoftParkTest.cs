using System.Collections.Generic;

namespace ParkingSystem.Tests
{
    using NUnit.Framework;

    public class SoftParkTest
    {
        private SoftPark parking;
        private Car testCar;
        private Car reserveTestCar;
        [SetUp]
        public void Setup()
        {
            parking = new SoftPark(); 
            testCar = new Car("LADA","PB7893920");
            reserveTestCar = new Car("Moskvich","PB838383882");
        }

        [Test]
        public void DoesConstructorWorksCorrectly()
        {
            Dictionary<string,Car> expectedDictionary= new Dictionary<string, Car>
            {
                {"A1", null},
                {"A2", null},
                {"A3", null},
                {"A4", null},
                {"B1", null},
                {"B2", null},
                {"B3", null},
                {"B4", null},
                {"C1", null},
                {"C2", null},
                {"C3", null},
                {"C4", null},
            };
            Assert.AreEqual(expectedDictionary,parking.Parking,"Ctor doesn't work correctly");
        }

        [Test]
        public void CanItParkCar()
        {
            string parkPlace = "A3";
            parking.ParkCar(parkPlace, testCar);
            Car car = parking.Parking[parkPlace];
            Assert.AreEqual(testCar,car,"ParkCar does not work correctly!!");
            Assert.AreEqual($"Car:{reserveTestCar.RegistrationNumber} parked successfully!",parking.ParkCar("A4",reserveTestCar));
        }

        [Test]
        public void DoesItThrowExceptionWhenAttemptedToParkCarOnInvalidSpot()
        {
            string fakeParkSpot = "PeshoResidence";
            Assert.That(()=>parking.ParkCar(fakeParkSpot,testCar),Throws.ArgumentException
            ,"The method should throw exception if invalid place is entered");
        }
        [Test]
        public void DoesItThrowExceptionWhenAttemptedToParkCarOnAlreadyTakenSpot()
        {
            string parkSpot = "A3";
            parking.ParkCar(parkSpot, reserveTestCar);
            Assert.That(()=>parking.ParkCar(parkSpot,testCar),Throws.ArgumentException
                ,"The method should throw exception if is attempted to park car on taken place");
        }
        
        [Test]
        public void DoesItThrowExceptionWhenAttemptedToParkAlreadyParkedCar()
        {
            string parkSpot = "A3";
            parking.ParkCar(parkSpot, testCar);
            Assert.That(()=>parking.ParkCar("A4",testCar),Throws.InvalidOperationException
                ,"The method should throw exception if is attempted to park already parked car");
        }

        [Test]
        public void CanItRemove()
        {
            string parkSpot = "A3";
            parking.ParkCar(parkSpot, testCar);
            parking.RemoveCar(parkSpot, testCar);
            Assert.That(parking.Parking[parkSpot],Is.EqualTo(null),"Cannot remove car properly!!");
            parking.ParkCar(parkSpot, testCar);
            Assert.That(parking.RemoveCar(parkSpot,testCar)
                ,Is.EqualTo($"Remove car:{testCar.RegistrationNumber} successfully!")
                ,"Cannot remove car properly!!");
        }

        [Test]
        public void DoesItThrowExceptionWhenAttemptedToRemoveNonExistingCarFromExistingSpot()
        {
            string parkSpot = "A3";
            parking.ParkCar(parkSpot, testCar);
            Assert.That(()=>parking.RemoveCar(parkSpot, reserveTestCar),Throws.ArgumentException
                ,"The method should throw an exception if attempted to remove non existing car from existing spot!!");
        }

        [Test]
        public void DoesItThrowExceptionWhenAttemptedToRemoveCarFromNonExistingSpot()
        {
            string parkSpot = "A3";
            string fakeSpot = "PeshoResidence";
            parking.ParkCar(parkSpot, testCar);
            Assert.That(()=>parking.RemoveCar(fakeSpot, reserveTestCar),Throws.ArgumentException
                ,"The method should throw an exception if attempted to remove  car from non existing spot!!");
        }
    }
}