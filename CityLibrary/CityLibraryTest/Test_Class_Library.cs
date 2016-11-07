using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CityLibrary;

namespace CityLibraryTest
{
    /// <summary>
    /// Summary description for Test_Class_Library
    /// </summary>
    [TestClass]
    public class Test_Class_Library
    {
        public Test_Class_Library()
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
        public void Test_Method_LibraryConstructor()
        {
            Library lib = new Library("Svjetlost++");

            // Pogrešan unos formata imena biblioteke (_name),
            // očekivana pojava ArgumentException-a
        }
        
        [TestMethod]
        public void Test_Method_LibraryAddMember()
        {
            Library lib = new Library("Svjetlost");
            string HarisID = lib.AddMember("Haris", "Hasic", "1111111111111");

            Assert.AreEqual(lib.FindMember(HarisID).ID, HarisID);
            
            // Provjera da li je član zaista dodan u kolekciju
        }
        
        [TestMethod]
        public void Test_Method_LibraryAddBook()
        {
            Book k = new Book();
            k.Title = "Sto godina samoce";
            k.ISBN = "ISBN 1-12345-123-1";
            k.Publisher = "Sarajevo publishing";
            
            Author a = new Author("Haris", "Hasic");
            k.Author = a;

            Library lib = new Library("Svjetlost");

            Assert.AreEqual(lib.AddBook(k, 100, Convert.ToDateTime("21.12.2010")), true);

            // Provjera vracene vrijednosti kod unosa nove knjige,
            // očekivano true
        }
        
        [TestMethod]
        public void Test_Method_LibraryRemoveBook()
        {
            Author a = new Author("Haris", "Hasic");
            Book k = new Book();
            k.Title = "Sto godina samoce";
            k.ISBN = "ISBN 1-12345-123-1";
            k.Publisher = "Sarajevo publishing";

            Library lib = new Library("Svjetlost");
            lib.AddBook(k, 100, Convert.ToDateTime("21.12.2010"));

            Assert.AreEqual(lib.RemoveBook("ISBN 1-12345-123-1"), true);

            // Provjera vracene vrijednosti kod brisanja knjige,
            // očekivano true
        }
        
        [TestMethod]
        [ExpectedException(typeof(CityLibrary.Exceptions.BookNotAvailableException))]
        public void Test_Method_LibraryIssueBook()
        {
            Book k = new Book();
            k.Title = "Sto godina samoce";
            k.ISBN = "ISBN 1-12345-123-1";
            k.Publisher = "Sarajevo publishing";

            Author a = new Author("Haris", "Hasic");
            k.Author = a;

            Library lib = new Library("Svjetlost");
            lib.AddBook(k, 1, Convert.ToDateTime("21.12.2010"));
            String HarisID = lib.AddMember("Haris", "Hasic", "1111111111111");
            String NikoID = lib.AddMember("Niko", "Neznanovic", "2222222222222");

            lib.IssueBook(HarisID, "ISBN 1-12345-123-1", Convert.ToDateTime("21.12.2015"));
            lib.IssueBook(NikoID, "ISBN 1-12345-123-1", Convert.ToDateTime("21.9.2015"));
        
            // Pokušaj izdavanja knjige kada broj raspolozivih primjeraka spadne na 0,
            // očekivana pojava BookNotAvailableException-a
        }
    }
}
