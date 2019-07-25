using System;
using System.Globalization;

namespace product_types.Entities
{
    class UsedProducts : Product
    {
        public DateTime ManufactureDate { get; set; }
        public UsedProducts()
        {
        }
        public UsedProducts(string name, double price, DateTime manufactureDate) : base(name, price)
        {
            ManufactureDate = manufactureDate;
        }
        public override string PriceTag()
        {
            return Name + " (used) $" + Price.ToString("F2", CultureInfo.InvariantCulture) 
                        + " (Manufacture date: " 
                        + ManufactureDate.ToString("dd/MM/yyyy") 
                        + ")"; 
        }
    }
}