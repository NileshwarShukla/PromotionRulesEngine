using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine
{
    public class NItemFixedPriceRule : IRule
    {
        public Product Product1 { get; set; }
        public Product Product2 { get; set; }
        public decimal RulePrice { get; set; }

        private string _productSeprator = "&";
        public void ParseInput(List<Product> products, string[] input)
        {
            int index = Array.IndexOf(input, _productSeprator);
            Product prod1 = products.Where(a => a.ProductName.Trim().ToLower() == input[index - 1].Trim().ToLower()).FirstOrDefault();
            Product prod2 = products.Where(a => a.ProductName.Trim().ToLower() == input[index + 1].Trim().ToLower()).FirstOrDefault();
            
            if (prod1 == null) return;
            if (prod1.IsProductAssociatedWithRule) return;
            if (prod2 == null) return;
            if (prod2.IsProductAssociatedWithRule) return;

            this.Product1=prod1;
            this.Product2=prod2;
            
            this.Product1.IsProductAssociatedWithRule = true;
            this.Product2.IsProductAssociatedWithRule = true;

            index = Array.IndexOf(input, "for");
            this.RulePrice = Convert.ToDecimal(input[index + 1]);
        }
        public void CalculatePrice()
        {
            if (this.Product1 == null) return;
            if (this.Product2 == null) return;

            int qty1=this.Product1.Quantity;
            int qty2=this.Product2.Quantity;
            if (qty1-- > 0 && qty2-- > 0)
            { 
                this.Product1.Quantity=qty1;
                this.Product2.Quantity=qty2;
                this.Product2.SetPrice(1, RulePrice);
            }
            else if (this.Product1.Quantity > 0)
            {
                this.Product1.CalculatePrice();
            }
            else if (this.Product2.Quantity > 0)
            {
                this.Product2.CalculatePrice();
            }
           

        }
    }
}
