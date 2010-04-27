using System.Drawing;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using CellularAutomata.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CellularAutomata.UnitTests
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class ConfigurationTests
    {
        public ConfigurationTests()
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
            get { return testContextInstance; }
            set { testContextInstance = value; }
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
        public void Environment_Ser_Test()
        {
            CAEnvironment environment = new CAEnvironment(new Size(10, 10), false, "GameOfLife", "Moore", null);
            environment.States.Add(0);


            Stream stream = null;
            IFormatter formatter = new BinaryFormatter();
            stream = new FileStream("testfileser", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, environment);
            stream.Close();

            Stream stream1 = null;
            IFormatter formatter1 = new BinaryFormatter();
            stream1 = new FileStream("testfileser", FileMode.Open, FileAccess.Read, FileShare.None);
            CAEnvironment env2 = (CAEnvironment) formatter1.Deserialize(stream1);
            Assert.AreEqual(env2.Size.Height, environment.Size.Height);
            stream1.Close();
        }

        [TestMethod]
        public void Cell_GetXml_Test()
        {
            Cell cell = new Cell();
            cell.Location = new Point(100, 50);
            cell.State = true;

            var xml = cell.GetXml();

            Assert.AreEqual("<Cell left=\"100\" top=\"50\" />", xml);
        }

        [TestMethod]
        public void Cell_BuildFromXml_Test()
        {
            var xml = "<Cell left=\"100\" top=\"50\" />";

            Cell c = new Cell();
            c.BuildFromXml(xml);

            Assert.AreEqual(100, c.Location.X);
            Assert.AreEqual(50, c.Location.Y);
            Assert.IsTrue(c.State);
        }

        [TestMethod]
        public void CellCollection_GetXml_Test()
        {
            Cell c1 = new Cell(new Point(10, 20));
            Cell c2 = new Cell(new Point(30, 40));
            Cell c3 = new Cell(new Point(50, 60));

            var cells = new CellCollection {c1, c2, c3};

            string xml = cells.GetXml();

            Assert.AreEqual(ExpectedValues.CellCollection_GetXml, xml);
        }

        [TestMethod]
        public void CellCollection_BuildFromXml_Test()
        {
            var xml = ExpectedValues.CellCollection_GetXml;

            CellCollection c = new CellCollection();
            c.BuildFromXml(xml);

            Assert.AreEqual(3, c.Count);
        }

        [TestMethod]
        public void Pattern_GetXml_Test()
        {
            Pattern pattern = new Pattern();
            pattern.Name = "walker";
            pattern.Description = "desc";
            pattern.Cells.Add(new Cell(new Point(5, 10)));
            pattern.Cells.Add(new Cell(new Point(6, 11)));

            var xml = pattern.GetXml();

            Assert.AreEqual(ExpectedValues.Pattern_GetXml, xml);
        }

        [TestMethod]
        public void Pattern_BuildFromXml_Test()
        {
            var xml = ExpectedValues.Pattern_GetXml;

            Pattern pattern = new Pattern();
            pattern.BuildFromXml(xml);

            Assert.AreEqual("walker", pattern.Name);
            Assert.AreEqual("desc", pattern.Description);
            Assert.AreEqual(2, pattern.Cells.Count);
        }

        [TestMethod]
        public void PatternCollection_GetXml_Test()
        {
            Pattern p1 = new Pattern();
            p1.Name = "walker";
            p1.Description = "desc";
            p1.Cells.Add(new Cell(new Point(10, 20)));

            Pattern p2 = new Pattern();
            p2.Name = "test";
            p2.Description = "desc1";
            p2.Cells.Add(new Cell(new Point(20, 30)));

            Pattern p3 = new Pattern();
            p3.Name = "test2";
            p3.Description = "desc2";
            p3.Cells.Add(new Cell(new Point(30, 40)));

            var patterns = new PatternCollection { p1, p2, p3 };

            string xml = patterns.GetXml();

            Assert.AreEqual(ExpectedValues.PatternCollection_GetXml, xml);
        }

        [TestMethod]
        public void PatternCollection_BuildFromXml_Test()
        {
            var xml = ExpectedValues.PatternCollection_GetXml;

            PatternCollection patterns = new PatternCollection();
            patterns.BuildFromXml(xml);

            Assert.AreEqual(3, patterns.Count);
        }
    }
}