using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileData;
namespace UnitTestFileData
{
    [TestClass]
    public class TestFileFunction
    {
        //Unit test cases to for version functionality
        [TestMethod]
        public void TestVersionFunction1()
        {
            string[] data = { "-v", "c:/test.txt" };
            string result = Program.FileProcessing(data);
            Assert.IsTrue(result.Contains("Version"));
        }
        [TestMethod]
        public void TestVersionFunction2()
        {
            string[] data = { "--v", "c:/test.txt" };
            string result = Program.FileProcessing(data);
            Assert.IsTrue(result.Contains("Version"));
        }
        [TestMethod]
        public void TestVersionFunction3()
        {
            string[] data = { "/v", "c:/test.txt" };
            string result = Program.FileProcessing(data);
            Assert.IsTrue(result.Contains("Version"));
        }
        [TestMethod]
        public void TestVersionFunction4()
        {
            string[] data = { "--version", "c:/test.txt" };
            string result = Program.FileProcessing(data);
            Assert.IsTrue(result.Contains("Version"));
        }
        [TestMethod]
        public void TestVersionFunction5()
        {
            string[] data = { "test", "c:/test" };
            string result = Program.FileProcessing(data);
            Assert.IsTrue(!result.Contains("Version"));
        }
        [TestMethod]
        public void TestVersionFunction6()
        {
            string[] data = { "", "test" };
            string result = Program.FileProcessing(data);
            Assert.IsTrue(!result.Contains("Version"));
        }

        //Unit test cases to for Size functionality
        [TestMethod]
        public void TestSizeFunction1()
        {
            string[] data = { "-s", "c:/test.txt" };
            string result = Program.FileProcessing(data);
            Assert.IsTrue(result.Contains("Size"));
        }
        [TestMethod]
        public void TestSizeFunction2()
        {
            string[] data = { "--s", "c:/test.txt" };
            string result = Program.FileProcessing(data);
            Assert.IsTrue(result.Contains("Size"));
        }
        [TestMethod]
        public void TestSizeFunction3()
        {
            string[] data = { "/s", "c:/test.txt" };
            string result = Program.FileProcessing(data);
            Assert.IsTrue(result.Contains("Size"));
        }
        [TestMethod]
        public void TestSizeFunction4()
        {
            string[] data = { "--size", "c:/test.txt" };
            string result = Program.FileProcessing(data);
            Assert.IsTrue(result.Contains("Size"));
        }
        [TestMethod]
        public void TestSizeFunction5()
        {
            string[] data = { "test", "c:/test" };
            string result = Program.FileProcessing(data);
            Assert.IsTrue(!result.Contains("Size"));
        }
        [TestMethod]
        public void TestSizeFunction6()
        {
            string[] data = { "", "test" };
            string result = Program.FileProcessing(data);
            Assert.IsTrue(!result.Contains("Size"));
        }
    }
}
