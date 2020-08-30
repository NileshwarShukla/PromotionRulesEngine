using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine
{
   public class Product
    {
        public string ProductName { get; set; }

        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }

        private decimal Price { get; set; }

        public bool IsProductAssociatedWithRule { get; set; }

        public virtual void CalculatePrice()
        {
            Price += Quantity * UnitPrice;
        }
        public void SetPrice(int quantity, decimal unitPrice)
        {
            Price += quantity * unitPrice;
        
        }

        public static string Sum(List<Product> products)
        {
            return products.Sum(a => a.Price).ToString();
        }
    }
}
