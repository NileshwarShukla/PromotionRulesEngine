using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine
{
    public class RuleEngine
    {
        IReaderWriter _console;
        public RuleEngine(IReaderWriter readWrite)
        {
            _console = readWrite;
        }
        public string Start()
        {
           _console.Write("Enter Product with Unit Price \n Ex : Product1 UnitPrice \n keep Blank to end");

           string[] inputs = _console.ReadTillBreak();
            
            List<Product> products = FetchProducts(inputs);

            _console.Write("Enter Rules  \n Ex : 3 of A's for 130 OR C & D for 30 \n keep Blank to end");
            inputs = _console.ReadTillBreak();

            List<IRule> rules = FetchRules(products, inputs);

            products = ProductQuantitySet(products);

            CalculateProductPrices(products);
            ApplyPromotionToProducts(rules);

           return CalculateTotal(products);



        }

   

        private string CalculateTotal(List<Product> products)
        {
            return Product.Sum(products).ToString();
        }

        private void ApplyPromotionToProducts(List<IRule> rules)
        {
            foreach (IRule rule in rules)
            {
                rule.CalculatePrice();
            }
        }

        private void CalculateProductPrices(List<Product> products)
        {
            foreach (Product prod in products.Where(a=>!a.IsProductAssociatedWithRule))
            {
                prod.CalculatePrice();
            }
        }

        private List<Product> ProductQuantitySet(List<Product> products)
        {

            for (int i = 0; i < products.Count; i++)
            {
                _console.Write(string.Format("Enter quantity of product {0}", products[i].ProductName));
                int quantity = 0;
                int.TryParse(_console.ReadLine(),out quantity);
                products[i].Quantity = quantity<0?0:quantity;
            }
            return products;
        }

        

        private List<IRule> FetchRules(List<Product> products,string[] input)
        {
            List<IRule> rules = new List<IRule>();
            IRule rule;
            try
            {
                 foreach(string s in input)
                {


                    string[] rulesProduct = s.Split(' ');
                    if (s.Contains("&"))
                    {
                         rule = new NItemFixedPriceRule();
                         rule.ParseInput(products, rulesProduct);
                         rules.Add(rule);
                    }
                    else if (s.Contains("of"))
                    {
                        rule = new ItemsRuleFixedPrice();
                        rule.ParseInput(products, rulesProduct);
                        rules.Add(rule);
                    }
                  
                }
             
            }
            catch (Exception ex)
            {
                _console.Write(ex.Message);
            }
            return rules;
        }

        private List<Product> FetchProducts(string [] input)
        {
            List<Product> products = new List<Product>();
            Product product;
            try
            {
               
                foreach(string s in input)
                {
                 
                   string[] productAndUnitPrice=  s.Split(' ');
                   if (!products.Any(a => a.ProductName.Trim().ToLower() == productAndUnitPrice[0].ToLower().Trim()))
                   {
                       product = new Product();
                       product.ProductName = productAndUnitPrice[0];
                       product.UnitPrice = Convert.ToDecimal(productAndUnitPrice[1]);
                       products.Add(product);
                   }                   
                }
                
            }
            catch (Exception ex)
            {
                _console.Write(ex.Message);
            }
            return products;
        }
    }


}
