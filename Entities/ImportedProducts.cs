using System;
using System.Globalization;

namespace product_types.Entities
{
    class ImportedProducts : Product
    {
        public double CustomsFee { get; set; }
        public ImportedProducts()
        {
        }
        public ImportedProducts(string name, double price, double customsFee) : base (name, price)
        {
            CustomsFee = customsFee;
        }
        public double TotalPrice()
        {
            return Price + CustomsFee;
        }
        public override string PriceTag()
        {
            return Name + " $" 
                        + TotalPrice().ToString("F2", CultureInfo.InvariantCulture) 
                        + " (Customs fee: $ "
                        + CustomsFee.ToString("F2", CultureInfo.InvariantCulture) 
                        + ")";
        }
    }
}