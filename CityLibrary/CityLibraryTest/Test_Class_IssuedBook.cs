using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CityLibrary;

namespace CityLibraryTest
{
    /// <summary>
    /// Summary description for Test_Class_IssuedBook
    /// </summary>
    [TestClass]
    public class Test_Class_IssuedBook
    {
        public Test_Class_IssuedBook()
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
        public void Test_Method_IssuedBookConstructor()
        {
            Book k = new Book();
            k.Title = "Sto godina samoce";
            k.ISBN = "ISBN 1-12345-123-1";
            k.Publisher = "Sarajevo publishing";

            Member Haris = new Member("Haris", "Hasic", "2222222222222");

            IssuedBook IssBook = new IssuedBook(Haris, k, Convert.ToDateTime("21.12.1912"));

            // Pogrešan unos datuma vraćanja (_returnBy)
            // očekivana pojava ArgumentException-a
        }

        [TestMethod]
        [ExpectedException(typeof(System.InvalidOperationException))]
        public void Test_Method_IssuedBookReturnBook()
        {
            Book k = new Book();
            k.Title = "Sto godina samoce";
            k.ISBN = "ISBN 1-12345-123-1";
            k.Publisher = "Sarajevo publishing";

            Member Haris = new Member("Haris", "Hasic", "2222222222222");

            IssuedBook IssBook = new IssuedBook(Haris, k, DateTime.Now);

            IssBook.ReturnBook();
            IssBook.ReturnBook();

            // Pogrešan unos datuma vraćanja (_returnBy)
            // očekivana pojava ArgumentException-a
        }

    }
}
