using System;
using System.Collections.Generic;
using FightingArena;
using NUnit.Framework;

namespace Tests
{
    public class ArenaTests
    {
        private Warrior testWarrior;
        private Warrior testWarrior1;
        private Arena testArena;
        [SetUp]
        public void Setup()
        {
            testArena = new Arena();
            testWarrior = new Warrior("Pesho", 10, 100);
            testWarrior1 = new Warrior("Gosho", 5, 50);
        }

        [Test]
        public void TestConstructor()
        {
            List<Warrior> expectedValue = new List<Warrior>();
            Assert.AreEqual(expectedValue, testArena.Warriors);
        }

        [Test]
        public void TestEnroll()
        {
            testArena.Enroll(testWarrior);
            List<Warrior> expectedList = new List<Warrior> { testWarrior };
            Assert.AreEqual(testArena.Count, 1);
            Assert.AreEqual(expectedList, testArena.Warriors);
        }

        [Test]
        public void TestIfEnrollThrowsExceptionIfWarriorIsAlreadyEnrolled()
        {
            testArena.Enroll(testWarrior);
            Assert.Throws<InvalidOperationException>(() => testArena.Enroll(testWarrior));
        }

        [Test]
        public void TestFight()
        {
            testArena.Enroll(testWarrior);
            testArena.Enroll(testWarrior1);
            testArena.Fight("Pesho", "Gosho");
            int expectedHealth = 40;
            Assert.AreEqual(expectedHealth, testWarrior1.HP);
        }

        [Test]
        public void TestIfFightThrowsExceptionIfAnyOfTheWarriorsIsNull()
        {
            testArena.Enroll(testWarrior1);
            Assert.That(() => testArena.Fight("Peshou", "Gosho"), Throws.InvalidOperationException.With.Message
                .EqualTo($"There is no fighter with name Peshou enrolled for the fights!"));
            testArena = new Arena();
            testArena.Enroll(testWarrior);
            Assert.That(()=>testArena.Fight("Pesho","Goshou"),Throws.InvalidOperationException.With.Message
                .EqualTo($"There is no fighter with name Goshou enrolled for the fights!"));
        }
    }
}
