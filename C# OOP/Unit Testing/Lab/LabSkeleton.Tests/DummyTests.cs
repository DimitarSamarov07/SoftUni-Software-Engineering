using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        [Test]
        public void DummyLoosesHealthIfAttacked()
        {
            Axe axe = new Axe(1, 21);
            Dummy weapon = new Dummy(100, 20);
            axe.Attack(weapon);
            Assert.That(weapon.Health, Is.EqualTo(99), "Dummy health doesn't change after being attacked");
        }

        [Test]
        public void DeadDummyThrowsExceptionIfAttacked()
        {
            Axe axe = new Axe(200, 22);
            Dummy weapon = new Dummy(0, 200);
            bool throwsException = false;
            try
            {
                axe.Attack(weapon);
            }
            catch (Exception e)
            {
                throwsException = true;
            }
            Assert.That(throwsException, Is.EqualTo(true), "Dead weapon doesn't throw exception after being attacked");
        }

        [Test]
        public void DeadDummyCanGiveXp()
        {
            int experience = 300;
            Dummy deadMasterPesho = new Dummy(0, experience);
            Assert.That(() => deadMasterPesho.GiveExperience()
                , Is.EqualTo(300)
                , "Dead dummy cannot give xp");
        }

    }
}
