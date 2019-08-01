using System;
using NUnit.Framework.Internal;

namespace Telecom.Tests
{
    using NUnit.Framework;
    [TestFixture]
    public class Tests
    {
        private Phone testPhone;
        [SetUp]
        public void GetReadyForTest()
        {
            testPhone = new Phone("AzoriPhone","2600Delta");
        }
        [Test]
        public void DoesConstructorWorksProperly()
        {
            const string expectedMake = "AzoriPhone";
            const string expectedModel = "2600Delta";
            Assert.AreEqual(expectedMake,testPhone.Make);
            Assert.AreEqual(expectedModel,testPhone.Model);
        }

        [Test]
        public void DoesPropertiesThrowExceptionIfValueIsNullOrEmpty()
        {
            Assert.That(()=>testPhone=new Phone(String.Empty, "Bg"),Throws.ArgumentException
                ,"Make cannot be empty");
            Assert.That(()=>testPhone=new Phone(null, "Bg"),Throws.ArgumentException
                ,"Make cannot be null");
            Assert.That(()=>testPhone=new Phone("IScream", String.Empty),Throws.ArgumentException
                ,"Model cannot be empty");
            Assert.That(()=>testPhone=new Phone("IScream", null),Throws.ArgumentException
                ,"Model cannot be null");
        }
        [Test]
        public void CanItAdd()
        {
            int expectedCount = 1;
            testPhone.AddContact("Pesho","0887002243");
            Assert.AreEqual(expectedCount,testPhone.Count);
        }

        [Test]
        public void DoesItThrowExceptionIfTryAddingExistingContact()
        {
            testPhone.AddContact("Pesho", "0838383833");
            Assert.That(()=>testPhone.AddContact("Pesho","0838383833"),
                Throws.InvalidOperationException,"Invalid Operation!!You cannot add existing contact!!");
        }

        [Test]
        public void CanItCall()
        {
            testPhone.AddContact("Pesho", "08872234");
            string expectedReturnValue = $"Calling Pesho - 08872234...";
            Assert.That(()=>testPhone.Call("Pesho"),Is.EqualTo(expectedReturnValue)
                ,"Cannot Call");
        }

        [Test]
        public void DoesItThrowExceptionWhenCallingIfPersonDoesNotExist()
        {
            Assert.That(()=>testPhone.Call("Pesho"),Throws.InvalidOperationException
                ,"You have to throw exception - Person doesn't exist");
        }
    }
}