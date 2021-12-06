using System;
using System.Collections.Generic;

namespace CMSN_Lab_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<char, int> dictionaryCharToInt = new Dictionary<char, int> {
                { 'a', 10 },
                { 'b', 11 },
                { 'c', 12 },
                { 'd', 13 },
                { 'e', 14 },
                { 'f', 15 },
                { 'g', 16 },
                { 'h', 17 },
                { 'i', 18 },
                { 'j', 19 },
                { 'k', 20 } };

            Dictionary<int, char> dictionaryIntToChar = new Dictionary<int, char> {
                { 10, 'a' },
                { 11, 'b' },
                { 12, 'c' },
                { 13, 'd' },
                { 14, 'e' },
                { 15, 'f' },
                { 16, 'g' },
                { 17, 'h' },
                { 18, 'i' },
                { 19, 'j' },
                { 20, 'k' } };

            string minus = "";
            string input21 = Console.ReadLine();
            if (input21[0] == '-')
            {
                input21 = input21.TrimStart('-');
                minus = "-";
            }

            int output10 = 0;
            int digit = 1;
            int convertedToIntCharecter;
            for (int i = input21.Length - 1; i >= 0; i--)
            {
                char character = input21[i];
                if (character - 48 < 10)
                     convertedToIntCharecter = Convert.ToInt32(character - 48);
                 else
                     convertedToIntCharecter = dictionaryCharToInt[character];
                  output10 += convertedToIntCharecter * digit;
                digit *= 21;
            }
            Console.WriteLine("Число в десятичной системе счисления: " + minus + output10);


            string output21 = "";
            if (input21 == "0") 
                output21 = "0";

            digit = 1;
            while (output10 > 0)
            {
                if (output10 % 21 < 10) 
                    output21 = Convert.ToString(output10 % 21) + output21; 
                else
                    output21 = dictionaryIntToChar[output10 % 21] + output21;


                output10 /= 21;
                digit *= 10;
            }
            Console.WriteLine("Число в системе счисления с основанием 21: " + minus + output21);
        }
    }
}
