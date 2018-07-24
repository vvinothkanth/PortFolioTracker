# PortFolioTracker
Problem
-----------
Assume a text file with a sample content as follows:

GOOG - 50, MS - 10
INFY - 100, GOOG - 50, MS - 10
GOOG - 100, AMZN - 90, MS - 80

Here, each line is called a "portfolio" - which is nothing but a list of stock symbols with their corresponding count. For example, the first line in the above example means that someone owns "50 GOOG stocks and 10 MS stocks" and the second line means that someone owns "100 INFY stocks, 50 GOOG stocks and 10 MS stocks" and so on...Each of these stock symbols (such as GOOG, MS, etc.) has a price which can be queried from a site such as finance.yahoo.com. The value of each portfolio (each line) is the count of each stock multipled by its price. So, for example, the value of the first portfolio in this example would be:

   value = (50 * price_of_google_stock) + (10 * price_of_MS_stock)


Write a program that takes a text file (such as the above) as a command line argument and prints them in the descending order of their overall value, where the overall value of each line is the value of all stocks (price * quantity) in a given line.

An example run would be:

	>> java PortfolioTracker portfolio.txt
	GOOG - 100, AMZN - 90, MS - 80
	INFY - 100, GOOG - 50, MS - 10
	GOOG - 50, MS - 10


