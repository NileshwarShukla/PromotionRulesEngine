using PromotionEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine
{
    public class ConsoleReaderWriter : IReaderWriter
    {
        public string[] ReadTillBreak()
        {
            List<string> inp = new List<string>();
            while (true)
            {
                string s = Console.ReadLine();
                if (s.ToLower().Trim() == "") break;
                inp.Add(s);
            }
            return inp.ToArray();
        }
        public string ReadLine()
        {
            return Console.ReadLine();
        }
        public void Write(string s)
        {
            Console.WriteLine(s);
        }
    }
}
