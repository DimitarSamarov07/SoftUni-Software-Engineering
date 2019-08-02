using NUnit.Framework;

namespace Tests
{
    public class DatabaseTests
    {
        private Database.Database data;
        [SetUp]
        public void Setup()
        {
            data = new Database.Database(10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20);
        }

        [Test]
        public void TestConstructor()
        {
            const int expectedCount = 11;
            Assert.AreEqual(expectedCount, data.Count,"The constructor does not work correctly!!");
        }

        [Test]
        public void CanItAdd()
        {
            const int expectedCountAfterAdding = 12;
            data.Add(2);
            Assert.AreEqual(expectedCountAfterAdding, data.Count,"Add method does not work correctly!!");
        }

        [Test]
        public void DoesItThrowExceptionWhenAttemptedToAdd17ThElement()
        {
            data.Add(21);
            data.Add(22);
            data.Add(23);
            data.Add(24);
            data.Add(25);
            Assert.That(() => data.Add(26),
                Throws.InvalidOperationException,"Exception should be thrown if is attempted to add 17th element in the array!!");
        }
        [Test]
        public void CanItRemove()
        {
            const int expectedCountAfterRemoving = 10;
            data.Remove();
            Assert.AreEqual(expectedCountAfterRemoving,data.Count,"The Remove method does not work correctly!!");
        }
        [Test]
        public void DoesItThrowExceptionWhenAttemptedToRemoveIfTheArrayIsEmpty()
        {
            data = new Database.Database();
            Assert.That(()=>data.Remove(),
                Throws.InvalidOperationException,"Exception should be thrown if the array is empty and is attempted to remove!!");
        }

        [Test]
        public void CanItFetch()
        {
            int[] expectedArray = new[] {10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20};
            Assert.AreEqual(expectedArray,data.Fetch(),"The Fetch method does not work correctly!!");
        }
    }
}