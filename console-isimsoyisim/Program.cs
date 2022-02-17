using System;

namespace console_isimsoyisim
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lütfen isminizi giriniz: ");
            string name = Console.ReadLine();
            Console.WriteLine("Lütfen soyisminizi giriniz: ");
            string surname = Console.ReadLine();
            Console.WriteLine("Merhaba " + name + " "+ surname);
            Console.ReadLine();
        }
    }
}
