using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestMetricApp;
using ConsoleTables;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestWriteTableDefaut()
        {
            List<Periodical> periodicals = new List<Periodical>();

            Periodical periodical = new Periodical { Name = "макс", Publisher = "ооо альфа", Number = "48", ReleaseYear = "1943", ReleaseMonth = "9" };

            periodicals.Add(periodical);

            Int32 reference = 976749220;
            Int32 result = ConsoleTable.From<Periodical>(periodicals).ToString().GetHashCode();

            Assert.AreEqual(reference, result);
        }


        [TestMethod]
        public void TestWriteTableNotCount()
        {
            var noCount = new ConsoleTable(new ConsoleTableOptions
            {
                Columns = new[] { "one", "two", "three" },
                EnableCount = false
            });


            Int32 result = noCount.AddRow(1, 2, 3).ToString().GetHashCode();
            Int32 reference = 1818748203;

            Assert.AreEqual(reference, result);
        }


        [TestMethod]
        public void TestConsoleTableSomething()
        {
            var rows = Enumerable.Repeat(new Something(), 0);

            Int32 result = ConsoleTable.From<Something>(rows).ToString().GetHashCode();  
            Int32 reference = 427112349;

            Assert.AreEqual(reference, result);
        }
    }
}
