using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine
{
   public interface IRule
    {
       void ParseInput(List<Product> products, string[] input);

       void CalculatePrice();
    }
}
