using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CityLibrary;

namespace CityLibraryTest
{
    /// <summary>
    /// Summary description for Test_Class_Member
    /// </summary>
    [TestClass]
    public class Test_Class_Member
    {
        public Test_Class_Member()
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
        public void Test_Method_MemberID()
        {
            Member clan = new Member("Niko", "Neznanovic", "111111");
            clan.ID = "123-BD";

            // Pogrešan unos formata ID parametra (_id),
            // očekivana pojava ArgumentException-a
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void Test_Method_MemberConstructor()
        {
            Member clan1 = new Member("Haris", "Hasic", "1111111111111");
            Member clan2 = new Member("Niko", "Neznanovic", "111111");

            // Pogrešan unos formata CitizenID parametra (citizen_id),
            // očekivana pojava ArgumentException-a

            // Napravljene ispravke, nije bilo provjere da li uneseni
            // citizenID zadovoljava format
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void Test_Method_MemberCitizenID()
        {
            Member Haris = new Member("Haris", "Hasic", "2222222222222");
            Member Niko = new Member("Niko", "Neznanovic", "3333333333333");

            Niko.CitizenID = "5555";

            // Pogrešan unos formata CitizenID parametra (citizen_id)
            // preko setera, očekivana pojava ArgumentException-a
        }

        [TestMethod]
        public void Test_Method_Equals()
        {
            Member m1 = new Member("Haris", "Hasic", "2222222222222");
            Member m2 = new Member("Haris", "Hasic", "2222222222222");

            Assert.IsTrue(m1.Equals(m2));

            // Provjera ispravnog rada overrideane metode Equals 
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void Test_Method_Name()
        {
            Member Haris = new Member("Haris1+2#", "Hasic", "2222222222222");
            // Pogrešan unos formata CitizenID parametra (citizen_id)
            // preko setera, očekivana pojava ArgumentException-a
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void Test_Method_Surname()
        {
            Member Haris = new Member("Haris", "Hasic+12//", "2222222222222");
            // Pogrešan unos formata CitizenID parametra (citizen_id)
            // preko setera, očekivana pojava ArgumentException-a
        }
    }
}
