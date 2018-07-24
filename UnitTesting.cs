using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticeProgram;
namespace PortFolioTestCaseOne
{
    [TestClass]
    public class UnitTest1
    {     
        /// <summary>
        /// Check the key value of GOOG is equal to 500
        /// </summary>
        [TestMethod]
        public void checkSumOFKeyValue_GOOG()
        {
            double stockValue = PortfolioStock.sumOfOnePortkeyAndPortValue("GOOG", 10);
            Assert.AreEqual(500, stockValue);
            Assert.AreNotEqual(600, stockValue);
            Assert.AreNotEqual(-200, stockValue);
        }

        /// <summary>
        ///Check the key value of MS is equal to 1000
        /// </summary>
        [TestMethod]
        public void checkSumOFKeyValue_MS()
        {
            double stockValue = PortfolioStock.sumOfOnePortkeyAndPortValue("MS", 20);
            Assert.AreEqual(1000, stockValue);
            Assert.AreNotEqual(2000, stockValue);
            Assert.AreNotEqual(-300, stockValue);
        }

        /// <summary>
        /// Check the key value of INFS is not equal to 1000
        /// </summary>
        [TestMethod]
        public void checkSumOFKeyValueNotEqual_INFS()
        {
            double stockValue = PortfolioStock.sumOfOnePortkeyAndPortValue("INFS", 50);
            Assert.AreNotEqual(1000, stockValue);
        }

        /// <summary>
        /// Check the key value of GOOG is not equal to -49.65
        /// </summary>
        [TestMethod]
        public void checkPortValueForGoog()
        {
            double stockValue = PortfolioStock.fetchStockValue("GOOG");
            Assert.AreNotEqual(-49.65, stockValue);
        }

        /// <summary>
        /// 
        /// Check the result of port values are equal to [3000.0, 8000.0, 13500.0]
        /// </summary>
       [TestMethod]
       public void checkPortResult()
       {
           string[] getFileData = PortfolioStock.getStockFile(@"C:\Users\vinothkanth\Desktop\PortFolioData.txt");

           string[] getSingleLine = PortfolioStock.fetchSingleLine(getFileData);

           double[] getStockValue = PortfolioStock.splitFileData(getSingleLine);

           double[] stockValue = new double[3];
           stockValue[0] = 3000.0;
           stockValue[1] = 8000.0;
           stockValue[2] = 13500.0;
           CollectionAssert.AreEqual(stockValue, getStockValue);           
       }

       /// <summary>
       /// Check the result of port values are not equal to [18500, 6000, 2000]
       /// </summary>
       [TestMethod]
       public void checkPort_II()
       {
           string[] getFileData = PortfolioStock.getStockFile(@"C:\Users\vinothkanth\Desktop\PortFolioData.txt");

           string[] getSingleLine = PortfolioStock.fetchSingleLine(getFileData);

           double[] getStockValue = PortfolioStock.splitFileData(getSingleLine);

           double[] stockValue = new double[] { 18500, 6000, 2000 };
           Assert.AreNotEqual(stockValue, getStockValue);
       }

    /// <summary>
    /// check the file is empty are unknown file
    /// </summary>
      [TestMethod]
       public void UnknownFile()
       {
           string[] stockData = PortfolioStock.getStockFile(@"C:\Users\vinothkanth\Desktop\Por");
          string[] checkData = new string[]{};
          CollectionAssert.AreEqual(checkData, stockData);
       }

    /// <summary>
    /// Check the data file is not empty
    /// </summary>
      [TestMethod]
      public void FileNotEmpty()
      {
          string[] stockData = PortfolioStock.getStockFile(@"C:\Users\vinothkanth\Desktop\PortFolioData.txt");
          string[] checkData = new string[] { };
          CollectionAssert.AreNotEqual(checkData, stockData);
      }

    /// <summary>
    /// check one key and port value is equal to 500
    /// </summary>
      [TestMethod]
      public void splitDash()
      {
          double stockValue = PortfolioStock.splitWordsAsDash(new string[]{"GOOG","10"});
          Assert.AreEqual(500, stockValue); 
      }

    /// <summary>
      /// check one key and port value is not equal to 400
    /// </summary>
       [TestMethod]
      public void splitDashNotEqual()
      {
          double stockValue = PortfolioStock.splitWordsAsDash(new string[] { "GOOG", "10" });
          Assert.AreNotEqual(400, stockValue);
      }

        /// <summary>
        /// Check the result is equal to the given array
        /// </summary>
       [TestMethod]
       public void checkPort_Result()
       {
           string[] stockValue = new string[]{"GOOG-20,MS-10","MS-10,GOOG-10"};
           double[] v = new double[]{1500.0,1000.0};
           double[] checkValue = PortfolioStock.splitFileData(stockValue);
           CollectionAssert.AreEqual(checkValue, stockValue);
       }

        /// <summary>
       /// Check the result is not empty
        /// </summary>
       [TestMethod]
       public void checkPort_Result_I()
       {
           string[] stock = new string[] { "GOOG-20,MS-10", "MS-10,GOOG-10" };
           double[] check = new double[] {};
           double[] stockValue = PortfolioStock.splitFileData(stock);
           CollectionAssert.AreNotEqual(check, stockValue);
       }

       /// <summary>
       /// Check the result is not equal to given array
       /// </summary>
       [TestMethod]
       public void checkPort_Result_II()
       {
           string[] stock = new string[] { "GOOG-20,MS-10", "MS-10,GOOG-10" };
           double[] check = new double[] {500.0,300.0 };
           double[] stockValue = PortfolioStock.splitFileData(stock);
           CollectionAssert.AreNotEqual(check, stockValue);
       }
    }
}
