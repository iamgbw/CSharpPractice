using OpenQA.Selenium.DevTools.V133.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice
{
    internal class LINQPrograms
    {
        public static void charOccurrenceUsingLINQ()
        {
            string input = "Ganesh Bhimrao Waghmare";

            var charCount = input.Where(c => !Char.IsWhiteSpace(c)).GroupBy(c => c)
                .Select(group => new { Char = group.Key, Count = group.Count() });

            foreach(var item in charCount)
            {
                Console.WriteLine($"Character {item.Char} occurres {item.Count}");
            }
        }

        public static void reverseString()
        { 
        }


    }
}
