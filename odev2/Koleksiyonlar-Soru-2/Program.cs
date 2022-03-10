using System;
using System.Collections;

namespace Koleksiyonlar_Soru_2
{
    class Program
    {
        public static void WriteStarLine(string str)
        {
            Console.WriteLine("***** " + str + " *****");
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
            ArrayList Numbers = new ArrayList();
            ArrayList MaxNumbers = new ArrayList();
            ArrayList MinNumbers = new ArrayList();

            for (var i = 1; i <= 20; i++)
            {
                int number = InsertNumber(i);
                Numbers.Add(number);
            }

            Numbers.Sort();
            MinNumbers.Add(Numbers[0]);
            MinNumbers.Add(Numbers[1]);
            MinNumbers.Add(Numbers[2]);
            Numbers.Reverse();
            MaxNumbers.Add(Numbers[0]);
            MaxNumbers.Add(Numbers[1]);
            MaxNumbers.Add(Numbers[2]);

            WriteStarLine("Girdiniz Sayılardan En Büyük 3 Sayı");
            MaxNumbers.Print();
            WriteStarLine("Girdiniz Sayılardan En Küçük 3 Sayı");
            MinNumbers.Print();
            double MaxNumbersAvarege = MaxNumbers.Average();
            double MinNumbersAvarage = MinNumbers.Average();
            double AverageTotal = MaxNumbersAvarege+MinNumbersAvarage;
            Console.WriteLine("En Büyük 3 Sayının Ortalaması = {0}",MaxNumbersAvarege);
            Console.WriteLine("En Küçük 3 Sayının Ortalaması = {0}",MinNumbersAvarage);
            Console.WriteLine("En Büyük 3 Sayının Ortalaması ve En Küçük 3 Sayının Ortalaması Toplamı = {0}",AverageTotal);
        }
    }
    public static class Extension {
        public static void Print(this ArrayList arrList)
        {
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
