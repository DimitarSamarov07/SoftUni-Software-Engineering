using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using NUnit.Framework;
using Skeleton.Contracts;

namespace Skeleton.Tests
{
    [TestFixture]
    public class HeroTests
    {
        [Test]
        public void DoesHeroGainXpWhenTargetDies()
        {
            Mock<IWeapon> fakeWeapon = new Mock<IWeapon>();
            Mock<ITarget> fakeTarget = new Mock<ITarget>();
            fakeWeapon.Setup(x => x.AttackPoints).Returns(1);
            fakeWeapon.Setup(x => x.DurabilityPoints).Returns(20);
            fakeTarget.Setup(x => x.Health).Returns(1);
            fakeTarget.Setup(x => x.Experience).Returns(301);
            fakeTarget.Setup(x => x.IsDead()).Returns(true);
            fakeTarget.Setup(x => x.GiveExperience()).Returns(301);
            Hero hero = new Hero("Ivan", fakeWeapon.Object);
            hero.Attack(fakeTarget.Object);
            Assert.That(hero.Experience, Is.EqualTo(301), "Hero doesn't gain Xp when target dies");
        }
    }

}