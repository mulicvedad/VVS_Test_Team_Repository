using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CityLibrary;

namespace CityLibraryTest
{
    /// <summary>
    /// Summary description for Test_Class_Book
    /// </summary>
    [TestClass]
    public class Test_Class_Book
    {
        public Test_Class_Book()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void Test_Method_BookISBN()
        {
            Book b = new Book();
            b.ISBN = "ISBN 1345-123-187";
            // Pogrešan unos formata ISBN parametra (ISBN),
            // očekivana pojava ArgumentException-a
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void Test_Method_BookTitle()
        {
            Book b = new Book();
            b.Title = "100 godina samoće#";
            // Pogrešan unos parametra naslov knjige (title),
            // očekivana pojava ArgumentException-a
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void Test_Method_BookPublisher()
        {
            Book b = new Book();
            b.Publisher = "Svjetlost, Sarajevo";
            // Pogrešan unos formata parametra izdavac knjige (publisher),
            // očekivana pojava ArgumentException-a
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentOutOfRangeException))]
        public void Test_Method_BookYearPublished()
        {
            Book b = new Book();
            b.YearPublished = -1;

            // Pogrešan unos parametra godina izdavanja (year_published),
            // očekivana pojava ArgumentException-a
        }

        [TestMethod]
        public void Test_Method_BookEquals()
        {
            Book k1 = new Book();
            k1.Title = "Sto godina samoce";
            k1.ISBN = "ISBN 1-12345-123-1";
            k1.Publisher = "Sarajevo publishing";

            Author a = new Author("Haris", "Hasic");
            k1.Author = a;

            Book k2 = new Book();
            k2.Title = "Sto godina samoce";
            k2.ISBN = "ISBN 1-12345-123-1";
            k2.Publisher = "Sarajevo publishing";
            k2.Author = a;

            Assert.IsTrue(k1.Equals(k2));

            // Provjera da li je ispravno preklopljena Equals metoda
        }

    }
}
