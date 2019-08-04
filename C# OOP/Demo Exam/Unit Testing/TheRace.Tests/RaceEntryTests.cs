using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private RaceEntry race;
        private UnitMotorcycle motorcycle;
        private UnitMotorcycle reserveMotorcycle;
        private UnitRider rider;
        private UnitRider reserveRider;
        [SetUp]
        public void Setup()
        {
            reserveMotorcycle=new UnitMotorcycle("LadMoto:D",12,23);
            reserveRider = new UnitRider("PEsho",reserveMotorcycle);
            race = new RaceEntry();
            motorcycle = new UnitMotorcycle("GT200", 2222, 453);
            rider = new UnitRider("Ivan", motorcycle);
        }

        [Test]
        public void TestCtor()
        {
            race.AddRider(rider);
            Assert.AreEqual(1, race.Counter);
        }
        [Test]
        public void CanItAddRider()
        {
            race.AddRider(rider);
            Assert.AreEqual(1, race.Counter);
            Assert.AreEqual(String.Format("Rider {0} added in race.",reserveRider.Name),race.AddRider(reserveRider));
        }

        [Test]
        public void TestCounter()
        {
            race.AddRider(rider);
            Assert.AreEqual(1,race.Counter);
        }
        [Test]
        public void DoesItThrowExceptionIfRiderIsNull()
        {
            reserveRider = null;
            Assert.That(()=>race.AddRider(reserveRider),Throws.InvalidOperationException
                .With.Message.EquivalentTo("Rider cannot be null."),"WROOONG");
        }

        [Test]
        public void DoesItThrowExceptionIfRiderExists()
        {
            race.AddRider(rider);
            reserveRider = rider;
            Assert.That(() => race.AddRider(reserveRider), Throws.InvalidOperationException.With
                .Message.EqualTo(String.Format("Rider {0} is already added.", rider.Name)));
        }

        [Test]
        public void CanItCalculateAverageHorsePower()
        {
            race.AddRider(rider);
            race.AddRider(reserveRider);
            List<double> powers = new List<double>{12,2222};
            double expectedAverage = powers.Average();
            Assert.AreEqual(expectedAverage,race.CalculateAverageHorsePower());
        }

        [Test]
        public void DoesItThrowExceptionWhenAttemptedToCalculateAverageWithLessThan2Participants()
        {
            race.AddRider(rider);
            Assert.That(()=>race.CalculateAverageHorsePower(),Throws.InvalidOperationException.With
                .Message.EqualTo("The race cannot start with less than 2 participants."));
        }
    }
}