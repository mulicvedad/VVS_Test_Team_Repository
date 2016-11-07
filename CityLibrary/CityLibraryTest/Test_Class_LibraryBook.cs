using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CityLibrary;

namespace CityLibraryTest
{
    /// <summary>
    /// Summary description for Test_Class_LibraryBook
    /// </summary>
    [TestClass]
    public class Test_Class_LibraryBook
    {
        public Test_Class_LibraryBook()
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
        public void Test_Method_LibraryBookQuantity()
        {
            uint q = 20;

            Book k = new Book();
            k.Title = "Sto godina samoce";
            k.ISBN = "ISBN 1-12345-123-1";
            k.Publisher = "Sarajevo publishing";

            LibraryBook lk = new LibraryBook(k);
            lk.Quantity = q;

            Assert.AreEqual<uint>(lk.Quantity, q);
        }

        
        [TestMethod]
        public void Test_Method_LibraryBookArrivedOn()
        {
            Book k = new Book();
            k.Title = "Sto godina samoce";
            k.ISBN = "ISBN 1-12345-123-1";
            k.Publisher = "Sarajevo publishing";

            LibraryBook lk = new LibraryBook(k);
            lk.ArrivedOn = Convert.ToDateTime("21.12.2011");

            Assert.AreEqual(Convert.ToDateTime("21.12.2011"), lk.ArrivedOn);
        }

        [TestMethod]
        public void Test_Method_LibraryBookIncreaseQuantityBy()
        {
            Book k = new Book();
            k.Title = "Sto godina samoce";
            k.ISBN = "ISBN 1-12345-123-1";
            k.Publisher = "Sarajevo publishing";

            LibraryBook lk = new LibraryBook(k);
            
            lk.Quantity = 100;
            lk.IncreaseQuantityBy(5);

            Assert.AreEqual(Convert.ToUInt32(105), lk.Quantity);
        }

        [TestMethod]
        public void Test_Method_LibraryBookIncreaseQuantity()
        {
            Book k = new Book();
            k.Title = "Sto godina samoce";
            k.ISBN = "ISBN 1-12345-123-1";
            k.Publisher = "Sarajevo publishing";

            LibraryBook lk = new LibraryBook(k);

            lk.Quantity = 100;
            lk.IncreaseQuantity();

            Assert.AreEqual(Convert.ToUInt32(101), lk.Quantity);
        }

        [TestMethod]
        public void Test_Method_LibraryBookDecreaseQuantity()
        {
            Book k = new Book();
            k.Title = "Sto godina samoce";
            k.ISBN = "ISBN 1-12345-123-1";
            k.Publisher = "Sarajevo publishing";

            LibraryBook lk = new LibraryBook(k);

            lk.Quantity = 10;
            lk.DecreaseQuantity();

            Assert.AreEqual(Convert.ToUInt32(9), lk.Quantity);
        }
        
    }
}
