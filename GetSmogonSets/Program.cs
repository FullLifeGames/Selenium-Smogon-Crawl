using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.IO;

namespace GetSmogonSets
{
    class Program
    {
        static void Main(string[] args)
        {
            // The folder, where the raw Html sites will get saved (Filler)
            string saveFolder = "E:\\Pokes\\";
            // The location, where the Pokes.txt is
            string pokestxt = "E:\\Pokes.txt";

            IWebDriver driver = new FirefoxDriver();
            StreamReader sr = new StreamReader(pokestxt);
            while (!sr.EndOfStream)
            {
                string pokemon = sr.ReadLine();
                driver.Navigate().GoToUrl("http://www.smogon.com/dex/xy/pokemon/" + pokemon);
                string filename = saveFolder + pokemon.Replace('/','_');
                if (File.Exists(filename))
                {
                    File.Delete(filename);
                }
                StreamWriter sw = new StreamWriter(File.Create(filename));                
                sw.Write(driver.PageSource);
                sw.Close();
                Console.WriteLine(filename);
            }
            sr.Close();
        }
    }
}
