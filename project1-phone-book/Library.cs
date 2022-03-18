using System;
using System.Collections.Generic;

namespace project1_phone_book
{
    static class Library
    {
        public static string nullControl(string writeTxt,string NullTxt)
        {
            Console.Write(writeTxt);
            string value = Console.ReadLine();
            if (value==""){
                Console.WriteLine(NullTxt);
                return nullControl(writeTxt,NullTxt);
            } 
            else
                return value;
        }
        public static void MessageBox(string msg)
        {
            Console.WriteLine(new string('-', msg.Length + 2));
            Console.WriteLine("|" + msg + "|");
            Console.WriteLine(new string('-', msg.Length + 2));
        }
        public static bool Confirm(string msg)
        {
            Console.Write( msg + " (y/n)");
            string command = Console.ReadLine();
            if (command=="y")
                return true;
            else if (command=="n")
                return false;
            else
            {
                Console.WriteLine("Yanlış seçim yaptınız!");
                return Confirm(msg);
            }
        }

        public static void WriteStarLine(string msg)
        {
            Console.WriteLine("********** {0} **********",msg);
        }

        public static void WriteStarEnd()
        {
            Console.WriteLine("*******************************************");
        }
    }
}