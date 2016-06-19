using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    /// <summary>
    /// IFN501 Assignment 2 class.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Maximum number of products in catalog
        /// </summary>
        const int MAX_NUM_PRODUCTS = 100;

        /// <summary>
        /// Operation: Add a product and the price
        /// </summary>
        const string ADD = "1";
        /// <summary>
        /// Operation: Update a product price a user selected.
        /// </summary>
        const string UPDATE = "2";
        /// <summary>
        /// Operation: Show profit of each product.
        /// </summary>
        const string SHOW_PROFIT = "3";
        /// <summary>
        /// Operation: Show average price of all products.
        /// </summary>
        const string SHOW_AVG = "4";
        /// <summary>
        /// Operation: End this program.
        /// </summary>
        const string EXIT = "5";

        /// <summary>
        /// The program’s Main method shall implement a so­called REPL (“read­evaluate­print­loop”) loop, 
        /// where you repeatedly give a user to choose from five options.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            string[] productNames = new string[MAX_NUM_PRODUCTS];
            double[] retailPrices = new double[MAX_NUM_PRODUCTS];
            int numberOfProducts = 0;
            string userInput = null;
            bool loop = true;
            do
            {
                //get option from user
                userInput = GetOption();
                switch (userInput)
                {
                    case ADD:
                        AddProductAndPrice(productNames, retailPrices, ref numberOfProducts);
                        break;

                    case UPDATE:
                        UpdatePrice(productNames, retailPrices, ref numberOfProducts);
                        break;

                    case SHOW_PROFIT:
                        ShowProfit(productNames, retailPrices, ref numberOfProducts);
                        break;

                    case SHOW_AVG:
                        ShowAvgPrice(retailPrices, numberOfProducts);
                        break;

                    case EXIT:
                        //end the program.
                        loop = false;
                        break;

                    default:
                        break;
                }

            } while (loop);

            Console.WriteLine("Exit the program. Press any key...");
            Console.ReadKey();
        }


        /// <summary>
        /// Check if any product exist in catalog.
        /// </summary>
        /// <param name="numberOfProducts">The number of product.</param>
        /// <returns>true if the number of product is more than 0</returns>
        private static bool ExistProduct(int numberOfProducts)
        {
            return numberOfProducts != 0;
        }

        /// <summary>
        /// Show Average price of all products in catalog
        /// </summary>
        /// <param name="retailPrices">An array that retail price</param>
        /// <param name="numberOfProducts">The number of product.</param>
        private static void ShowAvgPrice(double[] retailPrices, int numberOfProducts)
        {
            if (!ExistProduct(numberOfProducts))
            {
                Console.WriteLine("No products in catalog.");
                Console.WriteLine();
                return;
            }

            double average = CalcAveragePrice(retailPrices, numberOfProducts);
            Console.WriteLine();
            Console.Write("You have {0} products in your catalogue. ", numberOfProducts);
            Console.WriteLine("The average retail price of those is: {0:c2}.", average);
            Console.WriteLine();
        }

        /// <summary>
        /// Get average price of all products in catalog.
        /// </summary>
        /// <param name="retailPrices">An array that retail price</param>
        /// <param name="numberOfProducts">The number of product.</param>
        /// <returns>The average price of all products</returns>
        private static double CalcAveragePrice(double[] retailPrices, int numberOfProducts)
        {
            //Check the value of numberOfProducts to avoid DivideByZeroException
            if (!ExistProduct(numberOfProducts))
            {
                return 0;
            }
            
            double ret = 0.0;
            for (int i = 0; i < numberOfProducts; i++)
            {
                ret += retailPrices[i];
            }
            return ret / numberOfProducts;
        }

        /// <summary>
        /// Show profit with product and its price.
        /// </summary>
        /// <param name="productNames">An array that stores product name.</param>
        /// <param name="retailPrices">An array that stores product price.</param>
        /// <param name="numberOfProducts">The number of product.</param>
        private static void ShowProfit(string[] productNames, double[] retailPrices, ref int numberOfProducts)
        {
            if (!ExistProduct(numberOfProducts))
            {
                Console.WriteLine("No products in catalog.");
                Console.WriteLine();
                return;
            }

            double percent = GetPositiveDouble("Please enter your sales profit in percent: ");
            Console.WriteLine();
            double salesProfit = 0.0;
            for (int i = 0; i < numberOfProducts; i++)
            {
                //calcurate the profit
                salesProfit = (percent * retailPrices[i]) / 100;

                Console.Write("Product {0}: {1}, ", (i + 1), productNames[i]);
                Console.WriteLine("price is {0:c2}, profit is {1:c2}", retailPrices[i], salesProfit);
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Update a price of a product.
        ///   The price of the product will be update to new price that user enters.
        /// </summary>
        /// <param name="productNames">An array that stores product name.</param>
        /// <param name="retailPrices">An array that stores product price.</param>
        /// <param name="numberOfProducts">The number of product.</param>
        private static void UpdatePrice(string[] productNames, double[] retailPrices, ref int numberOfProducts)
        {
            if (!ExistProduct(numberOfProducts))
            {
                Console.WriteLine("No products in catalog.");
                Console.WriteLine();
                return;
            }

            Console.WriteLine("You have {0} products in your catalogue: ", numberOfProducts);
            ShowProductNames(productNames, numberOfProducts);
            Console.WriteLine();
            
            int index = GetProductNumber(
                "Please enter the number of the product, whose price you would like to update: ",
                numberOfProducts);

            //element in an array starts from 0, thus "-1".
            Console.Write("You have selected {0}.", productNames[index - 1]);
            Console.WriteLine("The current retail price is {0:c2}.", retailPrices[index - 1]);
            retailPrices[index - 1] = GetPositiveDouble("Please enter the new price: ");

            Console.WriteLine();
        }

        /// <summary>
        /// Add product and its price in array.
        ///   The method ask to enter a product name and its price respectively,
        ///   then store them in an array.
        /// </summary>
        /// <param name="productNames">An array that stores product name.</param>
        /// <param name="retailPrices">An array that stores product price.</param>
        /// <param name="numberOfProducts">The number of product.</param>
        private static void AddProductAndPrice(string[] productNames, double[] retailPrices, ref int numberOfProducts)
        {
            if (numberOfProducts == MAX_NUM_PRODUCTS)
            {
                Console.WriteLine("Cannot add a product. The catalog is full. ");
                return;
            }

            string name = GetProductName("Enter the name of a new product in your catalogue: ");
            double price = GetPositiveDouble(string.Format("Enter the retail price of {0}: ", name));
            productNames[numberOfProducts] = name;
            retailPrices[numberOfProducts] = price;
            numberOfProducts++;
            Console.WriteLine();
        }


        /// <summary>
        /// Get double number from user via console
        /// If an input number can be converted to int, the method returns the input.
        /// </summary>
        /// <param name="message">A message to be displayed</param>
        /// <param name="numberOfProducts">The number of product</param>
        /// <returns></returns>
        private static int GetProductNumber(string message, int numberOfProducts)
        {
            int ret = 0;
            do
            {
                Console.Write(message);
                //product number has to be between 1 ~ numberOfProducts
            } while (!int.TryParse(Console.ReadLine(), out ret) || ret <= 0 || ret > numberOfProducts);
            return ret;
        }


        /// <summary>
        /// Get product name from user via console.
        /// </summary>
        /// <param name="message">A message to be displayed.</param>
        /// <returns>Product name.</returns>
        private static string GetProductName(string message)
        {
            string name = null;
            do
            {
                Console.Write(message);
                name = Console.ReadLine();
            } while (name == string.Empty || name == null);
            return name;
        }


        /// <summary>
        /// Get a positive double numerical number from user via console.
        ///   The method returns more than 0.
        /// </summary>
        /// <param name="message">A message to be displayed.</param>
        /// <returns>A positive double numerical number.</returns>
        private static double GetPositiveDouble(string message)
        {
            double ret = 0.0;
            do
            {
                Console.Write(message);
            } while (!double.TryParse(Console.ReadLine(), out ret) || ret < 0);

            return ret;
        }


        /// <summary>
        /// Get string of operation from user via console.
        /// </summary>
        /// <returns>Either of +, -, *, /</returns>
        private static string GetOption()
        {
            string ret = null;
            do
            {
                DisplayOptionList();
                ret = Console.ReadLine();
            } while (ret != ADD && ret != UPDATE && ret != SHOW_PROFIT
                && ret != SHOW_AVG && ret != EXIT);

            return ret;
        }

        /// <summary>
        /// Show all product names in catalog.
        /// </summary>
        /// <param name="productNames">An array that stores product name.</param>
        /// <param name="numberOfProducts">The number of product.</param>
        private static void ShowProductNames(string[] productNames, int numberOfProducts)
        {
            for (int i = 0; i < numberOfProducts; i++)
            {
                //product number starts from 1
                Console.WriteLine((i + 1) + ". " + productNames[i]);
            }
        }


        /// <summary>
        /// Show initial message.
        /// </summary>
        private static void DisplayOptionList()
        {
            Console.WriteLine();
            Console.WriteLine("1. Add new product and price");
            Console.WriteLine("2. Update existing product price");
            Console.WriteLine("3. Calculate profits");
            Console.WriteLine("4. Calculate totals");
            Console.WriteLine("5. Exit");
            Console.WriteLine();
            Console.Write("Please enter the number of the action you want to perform: ");
        }
    }
}
