using System;
using ExtendedDatabase;
using NUnit.Framework;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        private ExtendedDatabase.ExtendedDatabase dataVault;
        private Person pesho;
        [SetUp]
        public void Setup()
        {

            pesho = new Person(122342222, "Pesho");
            Person ivan = new Person(12222262, "Ivan");
            Person gosho = new Person(12122222, "Gosho");
            Person vasko = new Person(12222322, "Vasko");
            dataVault = new ExtendedDatabase.ExtendedDatabase(ivan, gosho, vasko);
        }

        [Test]
        public void DoesTheConstructorWork()
        {
            int expectedCount = 3;
            Assert.AreEqual(expectedCount, dataVault.Count, "The constructor does not work properly!!");

        }

        [Test]
        public void DoesAddRangeWork()
        {
            Person djjdjd = new Person(239191295532, "rrrq");
            Person ffff = new Person(239191291232222, "jdojsojoffds");
            Person gggggg = new Person(444112, "effffesffes");
            Person fffsew = new Person(4211421124124, "33333333qwee");
            Person rrrrr = new Person(6555552334, "rrqrqwqw");
            Person gggggas = new Person(9999999, "jfsoifjaojfoij");
            Person lemonande = new Person(124211212442144, "2412412");
            Person php = new Person(7987412724837, "Junk");
            Person java = new Person(30180148091801, "Rubbish");
            Person js = new Person(2391944412932, "Stalin");
            Person csharp = new Person(2391912934412, "GOD");
            Person python = new Person(4112412214, "Dinosaur");
            Person c = new Person(1241, "444");
            Person cePerson = new Person(999990, "gth");
            Person crwqPerson = new Person(63124, "xd");
            Person cqq = new Person(4123, "hivsauce");
            Person cdd= new Person(213131, "pewdiepie");
            Assert.That(()=>dataVault = new ExtendedDatabase.ExtendedDatabase(djjdjd, ffff, gggggg, fffsew, rrrrr, gggggas
                , lemonande, php, java, js, csharp, python, pesho,c,cePerson,crwqPerson,cqq,cdd),Throws.ArgumentException,"WROOOOOONGGGG");
        }
        [Test]
        public void CanItAdd()
        {
            int expectedCountAfterAdding = 4;
            dataVault.Add(pesho);
            Assert.AreEqual(expectedCountAfterAdding, dataVault.Count, "The method Add doesn't work properly at all!!");
        }

        [Test]
        public void DoesItThrowExceptionIfTheArrayIsFull()
        {
            Person djjdjd = new Person(239191295532, "rrrq");
            Person ffff = new Person(239191291232222, "jdojsojoffds");
            Person gggggg = new Person(444112, "effffesffes");
            Person fffsew = new Person(4211421124124, "33333333qwee");
            Person rrrrr = new Person(6555552334, "rrqrqwqw");
            Person gggggas = new Person(9999999, "jfsoifjaojfoij");
            Person lemonande = new Person(124211212442144, "2412412");
            Person php = new Person(7987412724837, "Junk");
            Person java = new Person(30180148091801, "Rubbish");
            Person js = new Person(2391944412932, "Stalin");
            Person csharp = new Person(2391912934412, "GOD");
            Person python = new Person(4112412214, "Dinosaur");
            Person c = new Person(8408108, "2000YearsBefore2019");
            dataVault.Add(djjdjd);
            dataVault.Add(ffff);
            dataVault.Add(gggggg);
            dataVault.Add(fffsew);
            dataVault.Add(rrrrr);
            dataVault.Add(gggggas);
            dataVault.Add(lemonande);
            dataVault.Add(php);
            dataVault.Add(java);
            dataVault.Add(js);
            dataVault.Add(csharp);
            dataVault.Add(python);
            dataVault.Add(c);
            Assert.That(() => dataVault.Add(pesho), Throws.InvalidOperationException, "The method should throw an exception if the array is full");
        }

        [Test]
        public void DoesItThrowExceptionIfAttemptedToAddUserWithUsernameThatAlreadyExist()
        {
            dataVault.Add(pesho);
            Assert.That(() => dataVault.Add(pesho), Throws.InvalidOperationException
                , "The Add method should throw an exception if is attempted to add user with username that already exist!!");
        }

        [Test]
        public void DoesItThrowExceptionIfAttemptedToAddUserWithIdThatAlreadyExist()
        {
            dataVault.Add(pesho);
            pesho = new Person(122342222, "NotPesho:D");
            Assert.That(() => dataVault.Add(pesho), Throws.InvalidOperationException
                , "The Add method should throw an exception if is attempted to add user with id that already exist!!");
        }

        [Test]
        public void CanItRemove()
        {
            const int expectedCountAfterRemoving = 2;
            dataVault.Remove();
            Assert.AreEqual(expectedCountAfterRemoving, dataVault.Count);
        }

        [Test]
        public void DoesItThrowExceptionIfIsAttemptedToRemoveButTheArrayIsEmpty()
        {
            dataVault = new ExtendedDatabase.ExtendedDatabase();
            Assert.That(() => dataVault.Remove(), Throws.InvalidOperationException
                , "The method should throw an exception if there's nothing to remove");
        }

        [Test]
        public void CanItFindByUsername()
        {
            Person expected = pesho;
            dataVault.Add(pesho);
            Assert.AreEqual(expected, dataVault.FindByUsername(pesho.UserName));
        }

        [Test]
        public void DoesItThrowExceptionIfIsAttemptedToFindPersonWithNonExistingOrNullUsername()
        {
            Assert.That(() => dataVault.FindByUsername(pesho.UserName), Throws.InvalidOperationException
            , "The method should throw an exception if Person with that username does not exist");
            Assert.That(() => dataVault.FindByUsername(null), Throws.ArgumentNullException
                , "The method should throw an exception if username is null");
            Assert.That(() => dataVault.FindByUsername(String.Empty), Throws.ArgumentNullException
                , "The method should throw an exception if username is empty");
        }

        [Test]
        public void CanItFindById()
        {
            Person expected = pesho;
            dataVault.Add(pesho);
            Assert.AreEqual(expected, dataVault.FindById(expected.Id));
        }

        [Test]
        public void DoesItThrowExceptionIfIsAttemptedToFindPersonWithNonExistingOrNegativeId()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => dataVault.FindById(-1), "The method should throw an exception if the id is negative");
            Assert.That(() => dataVault.FindById(32), Throws.InvalidOperationException
                , "The method should throw an exception if the id is not existing");
        }
    }
}