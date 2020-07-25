using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            IReaderWriter readWrite = new ConsoleReaderWriter();
            RuleEngine ruleEngine = new RuleEngine(readWrite);
            string totalPrice= ruleEngine.Start();
            readWrite.Write(totalPrice);
            Console.ReadLine();
        }
    }
}
