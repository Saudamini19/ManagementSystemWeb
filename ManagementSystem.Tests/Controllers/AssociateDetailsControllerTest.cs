using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;//to work with mvc
using ManagementSystem;//reference of the application
using ManagementSystem.Controllers;//reference of the controller

namespace ManagementSystem.Tests.Controllers
{
    /// <summary>
    /// Summary description for AssociateDetailsControllerTest
    /// </summary>
    [TestClass]
    public class AssociateDetailsControllerTest
    {
        public AssociateDetailsControllerTest()
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
        public void TestMethod1()
        {
            // Arrange
            AssociateDetailsController controller = new AssociateDetailsController();

            // Act
            ViewResult result = controller.Filtering() as ViewResult;

            // Assert
            Assert.AreEqual("This is a custom test",result.ViewBag.Message);

            AdminDetailsController c = new AdminDetailsController();
            ViewResult r = c.Filtering() as ViewResult;
            Assert.AreEqual("This is a custom test for Admin Details", r.ViewBag.Message);
        }
    }
}
