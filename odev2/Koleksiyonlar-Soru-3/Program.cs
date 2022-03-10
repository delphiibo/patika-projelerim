using System;
using System.Collections;
using System.Collections.Generic;

namespace Koleksiyonlar_Soru_3
{
    class Program
    {
        static Dictionary<string,int> LetterCalc(ArrayList arrList)
        {
            Dictionary<string,int> list = new Dictionary<string,int>();
            foreach (var item in arrList)
            {
                if (list.ContainsKey(item.ToString())==false)
                {
                    int count =0;
                    for (var i=0;i<arrList.Count;i++)
                    {
                        if (Convert.ToString(arrList[i])==item.ToString())
                            count++;
                    }
                    list.Add(item.ToString(),count);
                }
            }
            return list;
        }

        static void Main(string[] args)
        {
            ArrayList vowelList = new ArrayList();
            char[] vowels = {'a','e','ı','i','o','ö','ü','A','E','I','İ','O','Ö','Ü'};
            Console.Write("Lütfen bir cümle giriniz : ");
            string sentence = Console.ReadLine();
            for (int i = 0; i < sentence.Length; i++)
            {
                if (Array.IndexOf(vowels,sentence[i])>-1)
                    vowelList.Add(sentence[i].ToString().ToLower());
            }
            Console.WriteLine("Girdiğiniz Cümle İçerisinde Toplam {0} Sesli Harf Var.",vowelList.Count);
            vowelList.Sort();
            Console.WriteLine("Sesli harlerin listesi : ");
            Dictionary<string,int> liste = LetterCalc(vowelList);
            foreach (var item in liste)
                Console.WriteLine("{0} harfi {1} kere tekrar ediyor",item.Key,item.Value);
        }
    }
}
