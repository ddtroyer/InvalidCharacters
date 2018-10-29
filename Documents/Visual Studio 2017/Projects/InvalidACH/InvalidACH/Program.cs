using System;
using System.Text.RegularExpressions;
using System.IO;
using System.Reflection;

namespace InvalidACH
{
    class Program
    {
        static void Main(string[] args)
        {
            String path = "..\\InvalidACH\\files\\invalid-chars.ach"; //gets path to file

            string ACHFile = File.ReadAllText(@path); //converts file to string
            ACHFile = ACHFile.Replace("\r", "").Replace("\n", ""); //removes hard returns and newlines

            string pattern = @"^[a-z A-Z0-9_\-:.@$=/]+$"; //list of valid characters
            int i = 1;//finds location of invalid character

            //checks each character in file
            foreach (char a in ACHFile)
            {
                //converts character to string and checks against valid characters
                if (!(Regex.IsMatch(Convert.ToString(a), pattern)))
                {
                    //if invalid, writes character and position
                    Console.WriteLine("Character: {0} found at position {1}.", a, i);
                }
                i++;
            }

            Console.WriteLine("Hit Enter when finished.");
            Console.ReadLine();
        }
    }
}