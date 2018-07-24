//***********************************
//  
//  The PortfolioStock class is used to calculate the portfolio stack value for given text file
//  
//
//
// Auther : Vinothkanth V
// Program Date   : 17 / 7 / 2018
// Modified  Date : 19 / 7 / 2018
//
//
//***********************************

namespace PracticeProgram
{
        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Text;
        using System.Net;
        using Newtonsoft.Json;
        using System.Web.Script.Serialization;
        using Newtonsoft.Json.Linq;

        public class PortfolioStock
        {
            
            /// <summary>
            /// This function is used to get the portfolio file and assingned on string array of portFile
            /// </summary>
            /// <param name="putPortFile">Port File Location</param>
            /// <returns>array of file data</returns>
            public static string[] getStockFile(string fileLocation)
            {
                string[] fileData = new string[]{};
                try
                {
                    if (fileLocation == string.Empty)
                    {
                        throw new System.IO.FileNotFoundException("File Not Found Exception");
                    }
                    else if (System.IO.File.ReadAllLines(fileLocation))
                    {
                        throw new System.IO.FileNotFoundException("File Not Found Exception"); 
                    }
                    else
                    {
                        fileData = System.IO.File.ReadAllLines(fileLocation);
                    }
                }
                catch (System.IO.FileNotFoundException exception)
                {
                    throw new System.IO.FileNotFoundException(exception);
                }

                return fileData;

            }

            /// <summary>
            ///   This function is used to fetch the current portfolio value of given key word
            ///   It can be get the data using web client Method
            /// </summary>
            /// <param name="keySymbol"> Stock key ("GOOG") </param>
            /// <returns> Value of current key stock "18.000" of double value</returns>
            public static double fetchStockValue(string keySymbol) 
            {
                //Console.WriteLine(keySymbol);
                double keySymbolValue = 0.0;
                try
                {
                    string jsonData;
                    using (WebClient wc = new WebClient())
                    {
                        jsonData = wc.DownloadString("https://www.alphavantage.co/query?function=TIME_SERIES_DAILY&symbol=" + keySymbol + "&interval=5min&apikey=GQ7GFRH3XJS6L2Q5");
                    }
                    keySymbolValue = Convert.ToDouble(JObject.Parse(jsonData)["Time Series (Daily)"].First().First().First().First().ToString());
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception);
                    throw new ArgumentException("Argument Exception");
                }

                return keySymbolValue;
            }

            /// <summary>
            /// This function is used to read the text file and split each and every line and stored in 
            /// string array
            /// </summary>
            /// <returns>array of single line data</returns>
            public static string[] fetchSingleLine(string[] getAllStockData)
            {
                string[] singleLine = new string[getAllStockData.Length];

                try
                {
                    for (int lineCount = 0; lineCount < getAllStockData.Length; lineCount++)
                    {
                        singleLine[lineCount] = getAllStockData[lineCount];
                    }
                }
                catch (IndexOutOfRangeException exception)
                {
                    Console.WriteLine(exception);
                    throw new IndexOutOfRangeException(exception);
                }

                return singleLine;

            }

            /// <summary>
            ///  This function is used to calculate one pare of key and value of port data
            /// </summary>
            /// <param name="portKey">GOOG</param>
            /// <param name="portValue">50</param>
            /// <returns>564.34</returns>
            public static double sumOfOnePortkeyAndPortValue(string portKey, double portValue)
            {
                double pareValue = 0.0;

                try
                {
                    //Console.WriteLine(fetchStockValue(portKey));
                    pareValue = 50 * portValue;
                }
                catch(ArgumentException exception)
                {
                    Console.WriteLine(exception);
                }

                return pareValue;
            }

            /// <summary>
            /// To split the given string as dashed
            /// </summary>
            /// <param name="pareOfStock">GOOG - 50</param>
            /// <returns>["GOOG","50"]</returns>
             public static double splitWordsAsDash(string[] pareOfStock)
            {
                double sumOfPareValues = 0.0;

                try
                { 
                    for (int wordCount = 0; wordCount < pareOfStock.Length; wordCount += 2)
                    {
                        string stockValue = Convert.ToString(pareOfStock[wordCount].Trim()) ;
                        double portPoint = Convert.ToDouble(pareOfStock[wordCount + 1].Trim());
                        sumOfPareValues += Convert.ToDouble(sumOfOnePortkeyAndPortValue(stockValue, portPoint ));
                    }
                }
                catch (IndexOutOfRangeException exception)
                {
                    Console.WriteLine(exception);
                }

                return sumOfPareValues;
            }

            /// <summary>
            /// To calculate the overall value of single line 
            /// </summary>
            /// <returns>72234.6</returns>
            public static double[] splitFileData(string[] oneSingleLineData)
            {
                double[] finalPortValue = new double[oneSingleLineData.Length];
                int finalPortIndex = 0;

                try
                {
                    foreach (string pare in oneSingleLineData)
                    {
                       double totalValueOfSingleLine = 0.0;
                       foreach (string pareOfWord in pare.Split(','))
                       {
                            totalValueOfSingleLine += Convert.ToDouble(splitWordsAsDash(pareOfWord.Trim().Split('-')));
                       }
                       finalPortValue[finalPortIndex] = Convert.ToDouble(totalValueOfSingleLine);
                       finalPortIndex += 1;
                    }
                }
                catch (IndexOutOfRangeException exception)
                {
                    Console.WriteLine(exception);
                }

                return finalPortValue;
            }

            public static string getReport(string[] rawData, double[] finalResult)
            {
                Dictionary<string, double> dict = new Dictionary<string, double>();
                string finalReport = string.Empty;
                try
                {
                    
                    for (int stockCount = 0; stockCount < rawData.Length; stockCount++)
                    {
                        dict.Add(rawData[stockCount], finalResult[stockCount]);
                    }

                    var portValueAsDesendingOrder = from pair in dict orderby pair.Value descending select pair;

                    foreach (KeyValuePair<string, double> pair in portValueAsDesendingOrder)
                    {
                        finalReport += " Stock Report (" + pair.Value + " ) \t For  => [ " + pair.Key + "] \n";
                    }

                }
                catch (IndexOutOfRangeException exception)
                {
                    Console.WriteLine(exception);
                }

                return finalReport;
            }

            public static double[] splitFileData()
            {
                throw new NotImplementedException();
            }
        }
}
