//***********************************
//
// Auther : Vinothkanth V
//
//***********************************
//
//
// Program Date   : 17 / 7 / 2018
// Modified  Date : 19 / 7 / 2018
//
//
//***********************************

// 
namespace PracticeProgram
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using PracticeProgram;

    /// <summary>
    /// 
    /// </summary>
    public class StockPrice
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter the portfile location\n");
                string fileLocation = Convert.ToString(Console.ReadLine());

                string[] getFileData = PortfolioStock.getStockFile(fileLocation);

                string[] getSingleLine = PortfolioStock.fetchSingleLine(getFileData);

                double[] getStockValue = PortfolioStock.splitFileData(getSingleLine);

                string getRepot = PortfolioStock.getReport(getSingleLine, getStockValue);

                Console.WriteLine("\n\n");
                Console.WriteLine("----------------------- ( PortFolio Stock ) ----------------------\n\n");
                Console.WriteLine(getRepot);

                Console.ReadKey();

            }
            catch (Exception fileNotFount)
            {
                Console.WriteLine(fileNotFount);
            }
        }
    }
}
