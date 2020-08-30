using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine
{
    public class ItemsRuleFixedPrice : Product, IRule
    {
        public int RuleQuantity { get; set; }
        public Product Product { get; set; }
        public decimal RulePrice { get; set; }

        private string _productSeprator = "of";
       public void ParseInput(List<Product> products, string[] input)
       {

           int index = Array.IndexOf(input, _productSeprator);
           this.RuleQuantity = Convert.ToInt32(input[index - 1]);
           Product prod=products.Where(a => a.ProductName.Trim().ToLower() == input[index + 1].Replace("'s", "").Trim().ToLower()).FirstOrDefault();
           if (prod == null) return;
           if (prod.IsProductAssociatedWithRule) return;
           this.Product = prod;          
           
           
           this.Product.IsProductAssociatedWithRule = true;
           index = Array.IndexOf(input, "for");
           this.RulePrice = Convert.ToDecimal(input[index + 1]);
       
       }
       public override void CalculatePrice()
       {
           if (this.Product == null) return;

            int promotionQuantity =   this.Product.Quantity / this.RuleQuantity;
            int remainingQuantity =   this.Product.Quantity % this.RuleQuantity;

            this.Product.SetPrice(promotionQuantity, RulePrice);
            this.Product.SetPrice(remainingQuantity , this.Product.UnitPrice);
       }
    }
}
