using System;
using FightingArena;
using NUnit.Framework;
namespace Tests
{
    public class WarriorTests
    {
        private Warrior testWarrior;
        private Warrior testWarrior1;
        [SetUp]
        public void Setup()
        {
            testWarrior = new Warrior("Pesho", 10, 100);
            testWarrior1 = new Warrior("Gosho", 5, 50);
        }

        [Test]
        public void TestConstructor()
        {
            string expectedName = "Pesho";
            int expectedDamage = 10;
            int expectedHp = 100;
            Assert.AreEqual(expectedName, testWarrior.Name);
            Assert.AreEqual(expectedDamage, testWarrior.Damage);
            Assert.AreEqual(expectedHp, testWarrior.HP);
        }

        [Test]
        public void TestIfNameThrowsExceptionIfValueIsNullOrEmptyOrWhitespace()
        {
            Assert.Throws<ArgumentException>(() => testWarrior = new Warrior(null, 10, 100));
            Assert.Throws<ArgumentException>(() => testWarrior = new Warrior(String.Empty, 10, 100));
            Assert.Throws<ArgumentException>(() => testWarrior = new Warrior(" ", 10, 100));
        }

        [Test]
        public void TestIfDamageThrowsExceptionIfValueIsLessThanOrEqualToZero()
        {
            Assert.Throws<ArgumentException>(() => testWarrior = new Warrior("Pesho", 0, 100));
            Assert.Throws<ArgumentException>(() => testWarrior = new Warrior("Pesho", -1, 100));
        }

        [Test]
        public void TestIfHPThrowsExceptionIfValueIsLessThanZero()
        {
            Assert.Throws<ArgumentException>(() => testWarrior = new Warrior("Pesho", 10, -1));
        }

        [Test]
        public void TestAttackMethod()
        {
            testWarrior.Attack(testWarrior1);
            int expectedHP = 40;
            Assert.AreEqual(expectedHP, testWarrior1.HP);
        }

        [Test]
        public void TestIfAttackThrowsExceptionIfAttackerHPIsLessThanOrEqualTo30()
        {
            testWarrior1 = new Warrior("Gosho", 5, 30);
            Assert.Throws<InvalidOperationException>(() => testWarrior.Attack(testWarrior1));
            testWarrior1 = new Warrior("Gosho", 5, 29);
            Assert.Throws<InvalidOperationException>(() => testWarrior.Attack(testWarrior1));
        }

        [Test]
        public void TestIfAttackThrowsExceptionIfEnemyHPIsLowerThanOrEqualTo30()
        {
            testWarrior = new Warrior("Pesho", 2, 30);
            Assert.Throws<InvalidOperationException>(() => testWarrior.Attack(testWarrior1));
            testWarrior = new Warrior("Pesho", 5, 29);
            Assert.Throws<InvalidOperationException>(() => testWarrior.Attack(testWarrior1));
        }

        [Test]
        public void TestIfAttackThrowsExceptionIfEnemyIsTooStrong()
        {
            testWarrior = new Warrior("Pesho", 5, 39);
            testWarrior1 = new Warrior("Gosho", 50, 50);
            Assert.Throws<InvalidOperationException>(() => testWarrior.Attack(testWarrior1));
        }

        [Test]
        public void TestIfAttackHandlesIfEnemyDamageFallsBelowZero()
        {
            testWarrior = new Warrior("Pesho", 500, 390);
            testWarrior1 = new Warrior("Gosho", 50, 50);
            testWarrior.Attack(testWarrior1);
            int expectedHealth = 0;
            Assert.AreEqual(expectedHealth,testWarrior1.HP);
        }
    }
}