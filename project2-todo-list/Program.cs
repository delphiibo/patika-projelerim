using System;

namespace project2_todo_list
{
    class Program
    {
        static void Main(string[] args)
        {
            Operation operation = new Operation();
            operation.DefaultRecord();
            operation.Start();
            bool state = true;
            while (state == true)
            {
                Console.Write("Lütfen 1 ile 4 arası rakam veya komut giriniz : ");
                string command = Console.ReadLine();
                if (command == "kapat")
                {
                    if (operation.Close() == true)
                        state = false;
                    continue;
                }
                else if (command == "menu")
                {
                    operation.Start();
                    continue;
                }
                else if (command == "kisiler")
                {
                    operation.TeamUserList();
                    continue;
                }
                else if (command == "temizle")
                {
                    Console.Clear();
                    continue;
                }
                int number = 0;
                bool isNumber = int.TryParse(command, out number);
                if (isNumber == false || number < 1 || number > 4)
                {
                    Console.WriteLine("Yanlış rakam veya komut girdiniz.");
                    continue;
                }
                switch (number)
                {
                    case 1: operation.List(); break;
                    case 2: operation.Add(); break;
                    case 3: operation.Delete(); break;
                    case 4: operation.Move(); break;
                }
            }

        }
    }
}
