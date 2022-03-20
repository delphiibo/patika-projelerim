using System;

namespace project2_todo_list
{
    static class Library
    {
        public static string NullControl(string writeTxt, string nullTxt)
        {
            Console.Write(writeTxt);
            string value = Console.ReadLine();
            if (value == "")
            {
                Console.WriteLine(nullTxt);
                return NullControl(writeTxt, nullTxt);
            }
            else
                return value;
        }

        public static int NullNumberControl(string writeTxt, string nullTxt,string errorTxt)
        {
            string value = NullControl(writeTxt,nullTxt);
            int number = 0;
            bool isNumber = int.TryParse(value,out number);
            if (isNumber)
                return number;
            else {
                Console.WriteLine(errorTxt);
                return NullNumberControl(writeTxt,nullTxt,errorTxt);   
            }
        }

        public static CartSize.Buyukluk CartSizeControl(string writeTxt, string nullTxt,string errorTxt, string notFindText)
        {
            int value = NullNumberControl(writeTxt,nullTxt,errorTxt);
            if (value == 1)
                return CartSize.Buyukluk.XS;
            else if (value == 2)
                return CartSize.Buyukluk.S;
            else if (value == 3)
                return CartSize.Buyukluk.M;
            else if (value == 4)
                return CartSize.Buyukluk.L;
            else if (value == 5)
                return CartSize.Buyukluk.XL;
            else
            {
                Console.WriteLine(notFindText);
                return CartSizeControl(writeTxt, nullTxt,errorTxt,notFindText);
            }
        }

        public static TeamUserModel TeamUserControl(string writeTxt, string nullTxt, string errorTxt, string notFindText)
        {
            int value = NullNumberControl(writeTxt,nullTxt,errorTxt);
            TeamUserModel teamUserModel = TeamUsers.Find(value);
            if (teamUserModel.Id==0)
            {
                Console.WriteLine(notFindText);
                return TeamUserControl(writeTxt, nullTxt, errorTxt,notFindText);
            }
            else 
                return teamUserModel;

        }

        public static void MessageBox(string msg)
        {
            Console.WriteLine(new string('-', msg.Length + 2));
            Console.WriteLine("|" + msg + "|");
            Console.WriteLine(new string('-', msg.Length + 2));
        }
        public static bool Confirm(string msg)
        {
            Console.Write(msg + " (y/n)");
            string command = Console.ReadLine();
            if (command == "y")
                return true;
            else if (command == "n")
                return false;
            else
            {
                Console.WriteLine("Yanlış seçim yaptınız!");
                return Confirm(msg);
            }
        }

        public static void WriteStarLine(string msg)
        {
            Console.WriteLine("********** {0} **********", msg);
        }

        public static void WriteStarEnd()
        {
            Console.WriteLine("*******************************************");
        }
    }
}