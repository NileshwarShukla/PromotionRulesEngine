using PromotionEngine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
namespace PromotionEngine
{
    public class TextReaderWriter : IReaderWriter
    {
        string fileName = "";
        string inpFile = "";
        string outFile = "";

        public TextReaderWriter(string fName)
        {
            fileName = fName;
            inpFile = Path.Combine(rootFolder, string.Format("{0}.txt", fileName));
            outFile = Path.Combine(rootFolder, string.Format("{0}Out.txt", fileName));

            if (File.Exists(outFile))
                File.Delete(outFile);
            ReadFile();
        }
        static readonly string rootFolder = ConfigurationSettings.AppSettings.Get("rootFolder");
        

        string[] lines;
        int lineIndex;
        public void ReadFile()
        {
            try
            {
                lines = File.ReadAllLines(inpFile);
            }
            catch (Exception ex)
            {
                this.Write(ex.Message);
            }
        }
        public string[] ReadTillBreak()
        {
            List<string> inp = new List<string>();
            while (true)
            {
                string s = lines[lineIndex++];
                if (string.IsNullOrEmpty(s)) break;
                inp.Add(s);

            }
            return inp.ToArray();
        }
        public string ReadLine()
        {

            return lines[lineIndex++];
        }
        public string ReadLast()
        {

            return lines.Last();
        }
        public void Write(string s)
        {
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(rootFolder,outFile), true))
            {
                outputFile.WriteLine(s);
            }
        }
    }
}
