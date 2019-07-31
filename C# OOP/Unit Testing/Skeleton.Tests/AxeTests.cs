using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        private Axe axe;
        private Dummy dummy;

        [SetUp]
        public void TestInit()
        {
            axe = new Axe(2, 2);
            dummy = new Dummy(20, 20);
        }
        [Test]
        public void AxeLoosesDurabilityAfterAttack()
        {
            axe.Attack(dummy);
            Assert.That(axe.DurabilityPoints, Is.EqualTo(1), "Axe durability doesn't change after attack");
        }
        [Test]
        public void BrokenWeaponCannotAttack()
        {
            axe.Attack(dummy);
            axe.Attack(dummy);
            Assert.That(() => axe.Attack(dummy), Throws.InvalidOperationException
                .With.Message.EqualTo("Axe is broken."));
        }
    }
}
