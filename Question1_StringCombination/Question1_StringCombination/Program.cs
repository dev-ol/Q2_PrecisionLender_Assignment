using System;
using System.Collections.Generic;

namespace Question1_StringCombination
{
     class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome! Let's combine two of your favorite words or numbers!");

            Console.WriteLine("Enter your first string: ");
            string s1 = Console.ReadLine();

            Console.WriteLine("Enter your second string: ");
            string s2 = Console.ReadLine();


            Console.WriteLine(StringCombination(s1, s2));
        }

        /*
         * This functions takes two strings, combines them and returns
         * a new string. (s1 = abc, s2 = 123 -> a1b2c3)
         */
        private static string StringCombination(string s1, string s2)
        {
            
            int s1Length = s1.Length, s2Length = s2.Length;

            if (s1Length == 0)
            {
                return s2;
            }
            else if (s2Length == 0)
            {
                return s1;
            }
            

            //storing the largest string length
            //loop ends after the last char is added 
            int count = s1Length > s2Length ?s1Length : s2Length;

            string result = "";

            int x = 0, y = 0; // use to iterate over the strings

            //looping to add each character to the new string
            for (int i = 0; i < count; i++)
            {
                if (x < s1Length)
                {
                    //storing the letter from string 1 at index
                    result+=s1[x];
                    x++;
                }
                else
                {
                    //storing the letter the rest of string 2 
                    //if the string 1 ended
                    result += s2.Substring(y);
                    break;
                }

                if (y < s2Length)
                {
                    //storing the letter from string 2 at index
                    result+=s2[y];
                    y++;
                }
                else
                {
                    //storing the letter the rest of string 1 
                    //if the string 2 ended
                    result += s1.Substring(x);
                    break;
                }
            }

            return result;
        }
    }
}
