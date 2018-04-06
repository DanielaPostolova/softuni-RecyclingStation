using System;
using System.Globalization;
using System.IO;
using Autofac;
using NUnit.Framework;
using RecyclingStation;
using RecyclingStation.WasteDisposal;
using RecyclingStation.WasteDisposal.Interfaces;

namespace RecyclingStationTests
{
    [TestFixture]
    public class IOTests
    {
        [Test]
        public void Test_001()
        {
            ExecuteFileTest("001");
        }

        [Test]
        public void Test_002()
        {
            ExecuteFileTest("002");
        }

        [Test]
        public void Test_003()
        {
            ExecuteFileTest("003");
        }

        [Test]
        public void Test_004()
        {
            ExecuteFileTest("004");
        }

        [Test]
        public void Test_005()
        {
            ExecuteFileTest("005");
        }

        [Test]
        public void Test_006()
        {
            ExecuteFileTest("006");
        }

        [Test]
        public void Test_007()
        {
            ExecuteFileTest("007");
        }

        [Test]
        public void Test_008()
        {
            ExecuteFileTest("008");
        }

        [Test]
        public void Test_009()
        {
            ExecuteFileTest("009");
        }

        [Test]
        public void Test_010()
        {
            ExecuteFileTest("010");
        }

        [Test]
        public void Test_011()
        {
            ExecuteFileTest("011");
        }
        
        [Test]
        public void Test_012()
        {
            ExecuteFileTest("012");
        }

        [Test]
        public void Test_013()
        {
            ExecuteFileTest("013");
        }

        [Test]
        public void Test_014()
        {
            ExecuteFileTest("014");
        }
        
        [Test]
        public void Test_015()
        {
            ExecuteFileTest("015");
        }

        private void ExecuteFileTest(string testNumber)
        {
            var testInput = new StreamReader(
                $@"C:\Users\danie\Documents\Visual Studio 2017\Projects\Softuni-oop\RecyclingStation-Exam\Tests\test.{testNumber}.in.txt");
            var testOutput = new StreamReader(
                $@"C:\Users\danie\Documents\Visual Studio 2017\Projects\Softuni-oop\RecyclingStation-Exam\Tests\test.{
                        testNumber
                    }.out.txt");

            var programOutput = new StringWriter();

            Console.SetIn(testInput);
            Console.SetOut(programOutput);

            var container = AutofacConfig.BuildContainer();
            var engine = container.Resolve<IEngine>();

            engine.Start();

            var expected = testOutput.ReadToEnd().Trim();
            var actual = programOutput.ToString().Trim();

            Assert.AreEqual(expected, actual);
        }
    }
}