using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentEx3
{
    class Program
    {
        /// <summary>
        /// Operation: Create a new catalogue.
        /// </summary>
        const string CREATE_CATA = "0";
        /// <summary>
        /// Operation: Add a product and the price.
        /// </summary>
        const string ADD = "1";
        /// <summary>
        /// Operation: Update a product price a user selected.
        /// </summary>
        const string UPDATE = "2";
        /// <summary>
        /// Operation: Show average product price per catalogue.
        /// </summary>
        const string SHOW_AVG_PER_CATA = "3";
        /// <summary>
        /// Operation: Show average price of all products across all catalogues.
        /// </summary>
        const string SHOW_TOTAL_AVG = "4";
        /// <summary>
        /// Operation: Show all product catalogues and their contents.
        /// </summary>
        const string SHOW_CATA_PRDUCT = "5";
        /// <summary>
        /// Operation: End this program.
        /// </summary>
        const string EXIT = "6";

        /// <summary>
        /// Maixmum number of product catalogues.
        /// </summary>
        const int MAX_NUM_CATALOGUES = 10;

        /// <summary>
        /// Minimum number of index of product list/catalogue list.
        /// </summary>
        const int MIN_INDEX_NUM = 1;


        /// <summary>
        /// An array of Product catalogues.
        /// </summary>
        static ProductCatalogue[] Catalogues = new ProductCatalogue[MAX_NUM_CATALOGUES];

        /// <summary>
        /// Assignment 1-3 main method.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //the number of catalogues created
            int numberOfCatalogues = 0;
            string userInput = null;
            bool loop = true;
            do
            {
                //get option from user
                userInput = GetOption();
                switch (userInput)
                {
                    case CREATE_CATA:
                        CreateCatalogue(ref numberOfCatalogues);
                        break;

                    case ADD:
                        AddProductAndPrice(ref numberOfCatalogues);
                        break;

                    case UPDATE:
                        UpdatePrice(ref numberOfCatalogues);
                        break;

                    case SHOW_AVG_PER_CATA:
                        ShowAvgPricePerCatalogue(numberOfCatalogues);
                        break;

                    case SHOW_TOTAL_AVG:
                        ShowTotalAvgPrice(numberOfCatalogues);
                        break;

                    case SHOW_CATA_PRDUCT:
                        ShowAllCataloguesAndProducts(numberOfCatalogues);
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
        /// Create a new catalogue.
        ///     If the number of catalogue is as same as MAX_NUM_CATALOGUES, the method shows an error message.
        /// </summary>
        /// <param name="numberOfCatalogues">The number of catalogues created.</param>
        private static void CreateCatalogue(ref int numberOfCatalogues)
        {
            //check existance of any catalogues
            if (numberOfCatalogues == MAX_NUM_CATALOGUES)
            {
                Console.WriteLine("Catalogue list is full.");
                return;
            }
            string name = InputHelper.GetStringFromUser("Please enter a new catalogue name: ");
            ProductCatalogue cata = new ProductCatalogue(name);
            Catalogues[numberOfCatalogues] = cata;
            numberOfCatalogues++;
        }


        /// <summary>
        /// Add product and its price.
        ///   The method ask to enter a product name and its price respectively,
        ///   then stores them in a catalogue previously selected by the user.
        /// </summary>
        /// <param name="numberOfCatalogues">The number of catalogues created.</param>
        private static void AddProductAndPrice(ref int numberOfCatalogues)
        {
            if (numberOfCatalogues == 0)
            {
                Console.WriteLine("No catalogues exist. Please create a catalogue first.");
                return;
            }
            ProductCatalogue cata = SelectCatalogue(numberOfCatalogues);
            Console.WriteLine("You have chosen {0}.", cata.CatalogueName);
            
            //Check the number of products in the catalogue.
            if (cata.NumberOfProducts == ProductCatalogue.MAX_NUM_PRODUCTS)
            {
                Console.WriteLine("Cannot add a product. The catalog is full. ");
                return;
            }

            string name = InputHelper.GetStringFromUser("Enter the name of a new product in your catalogue: ");
            double price = InputHelper.GetPositiveDoubleFromUser(string.Format("Enter the retail price of {0}: ", name));
            cata.InsertProduct(new ProductData(name, price));
            Console.WriteLine();
        }

        /// <summary>
        /// Update a price of a product.
        ///   The price of the product will be update to new price that user enters.
        /// </summary>
        /// <param name="numberOfCatalogues">The number of catalogues created.</param>
        private static void UpdatePrice(ref int numberOfCatalogues)
        {
            if (numberOfCatalogues == 0)
            {
                Console.WriteLine("No catalogues exist. Please create a catalogue first.");
                return;
            }

            ProductCatalogue cata = SelectCatalogue(numberOfCatalogues);
            // Show all products in the catalogue and products in it.
            ShowProductNamesAndPrice(cata);
            if (cata.NumberOfProducts == 0)
            {
                return;
            }

            int index = SelectProduct(cata.NumberOfProducts);
            //show a product that a user selected
            ProductData data = cata.GetProduct(index - 1);
            Console.Write("You have selected {0}.", data.ProductName);
            Console.WriteLine("The current retail price is {0:c2}.", data.RetailPrice);
            //update the price
            data.RetailPrice = InputHelper.GetPositiveDoubleFromUser("Please enter the new price: ");

            Console.WriteLine();
        }

        /// <summary>
        /// Show average price per catalogue.
        ///     Price is not displayed if there are no products.
        /// </summary>
        /// <param name="numberOfCatalogues">The number of catalogues created.</param>
        private static void ShowAvgPricePerCatalogue(int numberOfCatalogues)
        {
            if (numberOfCatalogues == 0)
            {
                Console.WriteLine("No catalogues exist. Please create a catalogue first.");
                return;
            }

            //loop to show all catalogues' average price
            for (int i = 0; i < numberOfCatalogues; i++)
            {
                ProductCatalogue cata = Catalogues[i];
                Console.Write("You have {0} products in {1}. ", cata.NumberOfProducts, cata.CatalogueName);
                if (cata.NumberOfProducts > 0)
                {
                    double avgPrice = cata.GetAvgPrice();
                    Console.WriteLine("The average retail price is: {0:c2}.", avgPrice);
                }
                else
                {
                    Console.WriteLine("");
                }
            }
        }


        /// <summary>
        /// Show Average price of all products across all catalogues.
        ///     Price is not displayed if there are no products.
        /// </summary>
        /// <param name="numberOfCatalogues">The number of catalogues created.</param>
        private static void ShowTotalAvgPrice(int numberOfCatalogues)
        {
            if (numberOfCatalogues == 0)
            {
                Console.WriteLine("No catalogues exist. Please create a catalogue first.");
                return;
            }

            double sum = 0;
            int numOfAllProducts = 0;
            for (int i = 0; i < numberOfCatalogues; i++)
            {
                //Sum up all price of all products across all catalogues
                sum += Catalogues[i].GetSumPrice();
                numOfAllProducts += Catalogues[i].NumberOfProducts;
            }
            //devide it by the number of all products
            sum = (numOfAllProducts == 0) ? 0 : sum / numOfAllProducts;

            Console.WriteLine();
            Console.Write("You have {0} catalogues and {1} products. ", numberOfCatalogues, numOfAllProducts);
            Console.WriteLine("The average product price across all catalogues is: {0:c2}.", sum);
            Console.WriteLine();
        }


        /// <summary>
        /// Show all catalogues and their products.
        ///     Catalogue name and its products are displayed respectively.
        /// </summary>
        /// <param name="numberOfCatalogues">The number of catalogues created.</param>
        private static void ShowAllCataloguesAndProducts(int numberOfCatalogues)
        {
            if (numberOfCatalogues == 0)
            {
                Console.WriteLine("No catalogues exist. Please create a catalogue first.");
                return;
            }
            Console.WriteLine("You have {0} catalogues.", numberOfCatalogues);
            for (int i = 0; i < numberOfCatalogues; i++)
            {
                Catalogues[i].PrintCatalogue();
            }
        }

        /// <summary>
        /// Show all products in the catalog.
        /// </summary>
        /// <param name="cata">Product catalog.</param>
        private static void ShowProductNamesAndPrice(ProductCatalogue cata)
        {
            if (cata == null || cata.NumberOfProducts == 0)
            {
                Console.WriteLine("No products exist.");
                return;
            }
            for (int i = 0; i < cata.NumberOfProducts; i++)
            {
                ProductData data = cata.GetProduct(i);
                //product number starts from 1, thus "+1"
                Console.WriteLine("{0}. {1}: {2:c2}", (i + 1), data.ProductName, data.RetailPrice);
            }
        }

        /// <summary>
        /// Select catalogue.
        ///     User selects existing catalogues.
        /// </summary>
        /// <param name="numberOfCatalogues">The number of catalogues created.</param>
        /// <returns>ProductCatalogue object.</returns>
        private static ProductCatalogue SelectCatalogue(int numberOfCatalogues)
        {
            ShowAllCatalogueNames(numberOfCatalogues);

            int index = InputHelper.GetIntFromUser(
                "Please choose the catalogues: ", MIN_INDEX_NUM, numberOfCatalogues);
            ProductCatalogue ret = Catalogues[index - 1];
            return ret;
        }

        /// <summary>
        /// Select product name
        ///     user selects existing products.
        /// </summary>
        /// <param name="numberOfProducts">The number of product</param>
        /// <returns>A int number user enters.</returns>
        private static int SelectProduct(int numberOfProducts)
        {
            return InputHelper.GetIntFromUser(
                "Please enter the number of the product, whose price you would like to update: ",
                MIN_INDEX_NUM,
                numberOfProducts);
        }

        /// <summary>
        /// Get string of operation from user via console.
        /// </summary>
        /// <returns>A string value that represent the operation.</returns>
        private static string GetOption()
        {
            string ret = null;
            do
            {
                DisplayOptionList();
                ret = Console.ReadLine();
                // main menu will be displayed until a user types anything between the number of the menu
            } while (ret != CREATE_CATA && ret != ADD && ret != UPDATE && ret != SHOW_AVG_PER_CATA
                && ret != SHOW_TOTAL_AVG && ret != SHOW_CATA_PRDUCT && ret != EXIT);

            return ret;
        }

        /// <summary>
        /// Show all product names in catalog.
        /// </summary>
        /// <param name="productNames">An array that stores product name.</param>
        /// <param name="numberOfProducts">The number of product.</param>
        private static void ShowAllCatalogueNames(int numberOfCatalogues)
        {
            Console.WriteLine("You have {0} product catalogues:", numberOfCatalogues);
            for (int i = 0; i < numberOfCatalogues; i++)
            {
                //product number starts from 1, thus "+1"
                Console.WriteLine((i + 1) + ". " + Catalogues[i].CatalogueName);
            }
        }

        /// <summary>
        /// Show initial message.
        /// </summary>
        private static void DisplayOptionList()
        {
            Console.WriteLine();
            Console.WriteLine("0. Create a new catalogue");
            Console.WriteLine("1. Add new product and price");
            Console.WriteLine("2. Update existing product price");
            Console.WriteLine("3. Show average product price per catalogue");
            Console.WriteLine("4. Show average product price across all catalogues");
            Console.WriteLine("5. Show all product catalogues and their contents");
            Console.WriteLine("6. Exit");
            Console.WriteLine();
            Console.Write("Please enter the number of the action you want to perform: ");
        }
    }
}
