namespace BlueOrigin.Tests
{
    using System;
    using NUnit.Framework;

    public class SpaceshipTests
    {
        private Spaceship ship;
        private Astronaut astronaut;
        [SetUp]
        public void Setup()
        {
            ship = new Spaceship("PeshoShip", 12);
            astronaut = new Astronaut("Pesho",50);
        }

        [Test]
        public void TestCtor()
        {
            Assert.AreEqual("PeshoShip", ship.Name);
            Assert.AreEqual(12, ship.Capacity);
            Assert.AreEqual(0, ship.Count);
        }

        [Test]
        public void TestIfNameThrows()
        {
            Assert.Throws<ArgumentNullException>(() => ship = new Spaceship("", 12));
            Assert.Throws<ArgumentNullException>(() => ship = new Spaceship(null, 12));
        }

        [Test]
        public void TestIfCapacityThrows()
        {
            Assert.Throws<ArgumentException>(() => ship = new Spaceship("PeshoShip", -1));
        }

        [Test]
        public void TestAdd()
        {
            ship.Add(astronaut);
            Assert.AreEqual(1,ship.Count);
        }

        [Test]
        public void AddFull()
        {
            for (int i = 0; i < 12; i++)
            {
                ship.Add(new Astronaut(i.ToString(),30+i));
            }
            Assert.Throws<InvalidOperationException>(()=>ship.Add(new Astronaut("GGGGG",50)));
        }

        [Test]
        public void TestCheckForExisting()
        {
            ship.Add(astronaut);
            Assert.Throws<InvalidOperationException>(() => ship.Add(astronaut));
        }

        [Test]
        public void TestRemove()
        {
            ship.Add(astronaut);
            Assert.AreEqual(true,ship.Remove(astronaut.Name));
            Assert.AreEqual(0,ship.Count);
            Assert.AreEqual(false,ship.Remove("FJFuifh"));
            
        }
    }
}