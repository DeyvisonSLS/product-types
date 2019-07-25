using System;
using System.Collections.Generic;
using System.Globalization;
using product_types.Entities;

namespace product_types
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> productsList = new List<Product>();

            Console.Write("Enter the number of products: ");
            int n = int.Parse(Console.ReadLine());

            for(int i = 0; i < n; i++)
            {
                //product sequence number
                Console.WriteLine("Product #{0}", i + 1);
                //Product type
                Console.Write("Common, used or imported (c/u/i): ");
                char productType = char.Parse(Console.ReadLine());
                //Name
                Console.Write("Name: ");
                string name = Console.ReadLine();
                //Price
                Console.Write("Price: ");
                double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Product product;

                switch(productType)
                {
                    case 'c':
                        product = new Product(name, price);
                        break;
                    case 'u':
                        //Asking for the manufacture date of the product
                        Console.Write("Manufacture date (DD/MM/YYYY): ");
                        DateTime manufactureDate = DateTime.Parse(Console.ReadLine());
                        //So, we instantiate the used product
                        product = new UsedProducts(name, price, manufactureDate);
                        break;
                    case 'i':
                        //Asking for the customs fee
                        Console.Write("Customs fee: ");
                        double customsFee = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                        //So, we instantiate the imported product
                        product = new ImportedProducts(name, price, customsFee);
                        break;
                    default:
                        Console.Write("Invalid type. Please choose a common, used or imported product (c/u/i): ");
                        productType = char.Parse(Console.ReadLine());
                        return;
                }

                productsList.Add(product);
            }
            
            //Resume
            Console.WriteLine("PRICE TAGS: ");
                foreach(Product prod in productsList)
                {
                    Console.WriteLine(prod.PriceTag());
                }
        }
    }
}
