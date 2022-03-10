using System;
using System.Collections;

namespace Koleksiyonlar_Soru_1
{
    class Program
    {
        public static void WriteStarLine(string str)
        {
            Console.WriteLine("***** " + str + " *****");
        }

        static bool isPrime(int number)
        {
            if (number <= 1)
                return false;
            if (number == 2)
                return true;
            if (number % 2 == 0)
                return false;
            for (var i = 3; i < number; i++)
            {
                if (number % i == 0)
                    return false;
            }
            return true;
        }
        static int InsertNumber(int index)
        {
            Console.Write("Lütfen {0}. sayıyı giriniz : ", index);
            int number = 0;
            bool isNumeric = int.TryParse(Console.ReadLine(), out number);
            if (isNumeric == false)
            {
                Console.WriteLine("{0}. değeri hatalı girdiniz!", index);
                InsertNumber(index);
                return 0;
            }
            else if (number < 0)
            {
                Console.WriteLine("{0}. değeri negatif değer olamaz!", index);
                InsertNumber(index);
                return 0;
            }
            else
                return number;
        }

        static void Main(string[] args)
        {
            ArrayList primeNumbers = new ArrayList();
            ArrayList nonPrimeNumbers = new ArrayList();

            for (var i = 1; i <= 20; i++)
            {
                int number = InsertNumber(i);
                if (isPrime(number))
                    primeNumbers.Add(number);
                else
                    nonPrimeNumbers.Add(number);
            }
            WriteStarLine("Girdiğiniz Sayılardan Asal Olan Sayılar");
            primeNumbers.Print();
            WriteStarLine("Girdiğiniz Sayılardan Asal Olmayan Sayılar");
            nonPrimeNumbers.Print();
            Console.WriteLine("Asal Sayıların Eleman Sayısı : {0}",primeNumbers.Count);
            Console.WriteLine("Asal Olmayan Sayıların Eleman Sayısı : {0}",nonPrimeNumbers.Count);
            Console.WriteLine("Asal Sayıların Ortalaması : {0}",primeNumbers.Average());
            Console.WriteLine("Asal Olmayan Sayıların Ortalaması : {0}",nonPrimeNumbers.Average());
        }
    }
    public static class Extension {
        public static void Print(this ArrayList arrList)
        {
            arrList.Sort();
            arrList.Reverse();
            foreach (var item in arrList)
                Console.WriteLine(item);
        }

        public static double Average(this ArrayList arrList)
        {
            if (arrList.Count<=0)
                return 0;
            double result = 0;
            foreach (var item in arrList)
                result += Convert.ToDouble(item);
            return result/arrList.Count;
        }
        
    }
}
