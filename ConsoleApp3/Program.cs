using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Calculation
    {
        public string binarysum(string a, string b)
        { 
            int buf = 0;
            bool carry = false;
            char[] sum = { '0', '0', '0', '0', '0', '0', '0', '0' };

            for (int i = 7; i >= 0; i--)
            {
                char[] reverseString = b.ToCharArray();
                Array.Reverse(reverseString);

                buf = Convert.ToInt16(a[i].ToString()) + Convert.ToInt16(reverseString[i].ToString()) + Convert.ToInt16(carry);

                if (buf == 0)
                {
                    sum[i] = '0';
                    carry = false;
                }

                else if (buf == 1)
                {
                    sum[i] = '1';
                    carry = false;
                }
                else if (buf == 2)
                {
                    sum[i] = '0';
                    carry = true;
                }
                else
                {
                    sum[i] = '1';
                    carry = true;
                }
            }

            string s = "";
            for (int i = 0; i < 8; i++)
            {
               s += sum[i];
            }

            return s;
        }
        public string To16bit(string number)
        {
            if (number.Length < 8)
            {
                int stop = 8 - number.Length;
                for (int i = 0; i < stop; i++)
                {
                    number = "0" + number;
                }
            }
            if (number.Length > 8)
            {
                number = number.Remove(0, number.Length - 8);
            }
            return number;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Calculation cl = new Calculation();

            string way = Environment.CurrentDirectory;
            int decA = 10001010;
            int decB = 11010101;

            Console.Write("Число A: ");
            Console.WriteLine(decA);
            Console.Write("Число B: ");
            Console.WriteLine(decB);

            string binA = Convert.ToString(decA);
            string binB = Convert.ToString(decB);
            
            binA = cl.To16bit(binA);
            binB = cl.To16bit(binB);

            string binSum = cl.binarysum(binA, binB);
            Console.Write("Сумма в дополнительном коде:");
            Console.WriteLine(binSum);
            Console.ReadLine();

            if (File.Exists(way + "\\output.txt") == false)
            {
                FileStream FileOutput = File.Create(way + "\\output.txt");
                FileOutput.Close();
            }

            FileStream stream = new FileStream(way + "\\output.txt", FileMode.Create);
            StreamWriter SW = new StreamWriter(stream);
            SW.Write(binSum);
            SW.Close();
            stream.Close();


        }
    }
}
