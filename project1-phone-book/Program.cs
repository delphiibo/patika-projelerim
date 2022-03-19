using System;

namespace project1_phone_book
{
    class Program
    {
        static void Main(string[] args)
        {
            Operation operation = new Operation();
            operation.DefaultList();
            operation.Welcome();
            operation.Start();
            bool state = true;
            while (state == true)
            {
                Console.Write("Lütfen 1 ile 5 arası rakam veya komut giriniz : ");
                string command = Console.ReadLine();
                if (command == "kapat")
                {
                    if (operation.Close() == true)
                        state = false;
                    continue;
                }
                else if (command == "yardim")
                {
                    operation.Start();
                    continue;
                }
                int number = 0;
                bool isNumber = int.TryParse(command, out number);
                if (isNumber == false || number < 1 || number > 5)
                {
                    Console.WriteLine("Yanlış rakam veya komut girdiniz.");
                    continue;
                }
                switch (number)
                {
                    case 1: operation.Add(); break;
                    case 2: operation.Delete(); break;
                    case 3: operation.Update(); break;
                    case 4: operation.List(); break;
                    case 5: operation.Search(); break;
                }
            }
        }
    }
}
