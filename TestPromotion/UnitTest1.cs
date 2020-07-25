using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionEngine;

namespace TestPromotion
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1_Scenario1()
        {
            string fName = "Input01";
            IReaderWriter readWrite = new TextReaderWriter(fName);
            RuleEngine ruleEngine = new RuleEngine(readWrite);
            string actual= ruleEngine.Start();

            readWrite.Write(actual);
           
            string expected=readWrite.ReadLine();
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethod2_Scenario2()
        {
            string fName = "Input02";
            IReaderWriter readWrite = new TextReaderWriter(fName);
            RuleEngine ruleEngine = new RuleEngine(readWrite);
            string actual = ruleEngine.Start();

            readWrite.Write(actual);

            string expected = readWrite.ReadLine();
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethod3_Scenario3()
        {
            string fName = "Input03";
            IReaderWriter readWrite = new TextReaderWriter(fName);
            RuleEngine ruleEngine = new RuleEngine(readWrite);
            string actual = ruleEngine.Start();

            readWrite.Write(actual);
            readWrite.ReadLine();
            string expected = readWrite.ReadLine();
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethod4_Scenario_NoRules()
        {
            string fName = "Input04";
            IReaderWriter readWrite = new TextReaderWriter(fName);
            RuleEngine ruleEngine = new RuleEngine(readWrite);
            string actual = ruleEngine.Start();

            readWrite.Write(actual);
            readWrite.ReadLine();
            string expected = readWrite.ReadLine();
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethod5_Scenario_ProductNotConsiderdRules()
        {
            string fName = "Input05";
            IReaderWriter readWrite = new TextReaderWriter(fName);
            RuleEngine ruleEngine = new RuleEngine(readWrite);
            string actual = ruleEngine.Start();

            readWrite.Write(actual);
            readWrite.ReadLine();
            string expected = readWrite.ReadLine();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod6_Scenario_NoProduct_NoRule()
        {
            string fName = "Input06";
            IReaderWriter readWrite = new TextReaderWriter(fName);
            RuleEngine ruleEngine = new RuleEngine(readWrite);
            string actual = ruleEngine.Start();

            readWrite.Write(actual);
            readWrite.ReadLine();
            string expected = readWrite.ReadLine();
            Assert.AreEqual(expected, actual);
        }
         [TestMethod]
        public void TestMethod7_Scenario_DuplicateProduct()
        {
            string fName = "Input07";
            IReaderWriter readWrite = new TextReaderWriter(fName);
            RuleEngine ruleEngine = new RuleEngine(readWrite);
            string actual = ruleEngine.Start();

            readWrite.Write(actual);
            readWrite.ReadLine();
            string expected = readWrite.ReadLine();
            Assert.AreEqual(expected, actual);
        }
         [TestMethod]
         public void TestMethod8_Scenario_RuleDefinedForNonExistingProduct()
         {
             string fName = "Input08";
             IReaderWriter readWrite = new TextReaderWriter(fName);
             RuleEngine ruleEngine = new RuleEngine(readWrite);
             string actual = ruleEngine.Start();

             readWrite.Write(actual);
             readWrite.ReadLine();
             string expected = readWrite.ReadLine();
             Assert.AreEqual(expected, actual);
         }
         [TestMethod]
         public void TestMethod9_Scenario_NegativeQuantities()
         {
             string fName = "Input09";
             IReaderWriter readWrite = new TextReaderWriter(fName);
             RuleEngine ruleEngine = new RuleEngine(readWrite);
             string actual = ruleEngine.Start();

             readWrite.Write(actual);
             readWrite.ReadLine();
             string expected = readWrite.ReadLine();
             Assert.AreEqual(expected, actual);
         }
    }
}
