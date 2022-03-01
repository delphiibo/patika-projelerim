using System;

namespace odev1
{
    class Program
    {
        static void Main(string[] args)
        {
            Sorular s = new Sorular();
            Console.WriteLine("********** SORULAR **********");
            s.SoruGetir();
        }
    }

    class Sorular 
    {
        public void SoruGetir()
        {
            Console.Write("Lütfen soru numarası giriniz : ");
            string SoruNo = Console.ReadLine();
            switch (SoruNo)
            {
                case "1" : Soru1();break;
                case "2" : Soru2();break;
                case "3" : Soru3();break;
                case "4" : Soru4();break;
                default:Console.WriteLine("Girdiğiniz {0} numaralı soru metotu bulunamadı.",SoruNo);break;
            }
        }
        public void Soru1() 
        {
            Console.WriteLine("SORU 1 : Bir konsol uygulamasında kullanıcıdan pozitif bir sayı girmesini isteyin(n). Sonrasında kullanıcıdan n adet pozitif sayı girmesini isteyin. Kullanıcının girmiş olduğu sayılardan çift olanlar console'a yazdırın.");
            Console.Write("Lütfen pozitif bir tamsayı giriniz : ");
            bool isNumber = int.TryParse(Console.ReadLine(), out int arrCount);
            if (isNumber == false || arrCount<=0)
            {
                Console.WriteLine("Girmiş olduğunuz değer pozitif bir tamsayı değil!");
                Soru1();
            }
            else
            {
                int[] arr = new int[arrCount];
                for (int i = 0; i < arrCount; i++)
                {
                    Console.Write("Lütfen {0}. sayıyı giriniz : ", i + 1);
                    bool isNumberArr = int.TryParse(Console.ReadLine(), out int arrNumber);
                    if (isNumberArr == false || arrNumber<=0)
                    {
                        Console.WriteLine("Girmiş olduğunuz {0}. sayı değeri pozitif bir tamsayı değil!", i + 1);
                        i--;
                    }
                    else
                        arr[i] = arrNumber;
                }
                Console.WriteLine("Girdiğiniz sayılardan çift olanlar : ");

                foreach (var item in arr)
                {
                    bool isEven = item % 2 == 0;
                    if (isEven==true)
                        Console.WriteLine(item);
                }
            }
        }

        public void Soru2() 
        {
            Console.WriteLine("SORU 2 : Bir konsol uygulamasında kullanıcıdan pozitif iki sayı girmesini isteyin (n, m). Sonrasında kullanıcıdan n adet pozitif sayı girmesini isteyin. Kullanıcının girmiş olduğu sayılardan m'e eşit yada tam bölünenleri console'a yazdırın.");
            Console.WriteLine("Hoş geldiniz. Birazdan iki pozitif tam sayı girmeniz istenecektir.");
            Console.Write("Lütfen 1. pozitif tam sayıyı giriniz : ");
            bool isNumber = int.TryParse(Console.ReadLine(), out int arrCount);
            if (isNumber == false || arrCount<=0) 
            {
                Console.WriteLine("Girmiş olduğunuz değer pozitif bir sayı değil!");
                Soru2();
            }
            else
            {
                int m = 0;
                bool isSecNumber = false;
                while(isSecNumber==false)
                {
                    Console.Write("Lütfen 2. pozitif tamsayıyı giriniz : ");
                    bool isM = int.TryParse(Console.ReadLine(),out m);
                    if (isM==false || m<=0)
                    {
                        isSecNumber = false;
                        Console.WriteLine("Girmiş olduğunuz değer pozitif bir tamsayı değil!"); 
                    }
                    else 
                        isSecNumber = true;
                }
                int[] arr = new int[arrCount];
                for (int i = 0; i < arrCount; i++)
                {
                    Console.Write("Lütfen {0}. sayıyı giriniz : ", i + 1);
                    bool isNumberArr = int.TryParse(Console.ReadLine(), out int arrNumber);
                    if (isNumberArr == false)
                    {
                        Console.WriteLine("Girmiş olduğunuz {0}. sayı değeri pozitif bir tamsayı değil!", i + 1);
                        i--;
                    }
                    else
                        arr[i] = arrNumber;
                }
                Console.WriteLine("Girdiğiniz sayılardan 2. sayıya eşit olanlar : ");
                foreach (var item in arr)
                {
                    bool isEqual = item==m;
                    if (isEqual==true)
                        Console.WriteLine(item);
                }
                Console.WriteLine("Girdiğiniz sayılardan 2. sayıya tam bölünenler : ");
                foreach (var item in arr)
                {
                    bool isFullyDived = item % m == 0;
                    if (isFullyDived==true)
                        Console.WriteLine(item);
                }
            }
        }
        public void Soru3() 
        {
            Console.WriteLine("SORU 3 : Bir konsol uygulamasında kullanıcıdan pozitif bir sayı girmesini isteyin (n). Sonrasında kullanıcıdan n adet kelime girmesi isteyin. Kullanıcının girişini yaptığı kelimeleri sondan başa doğru console'a yazdırın.");
            Console.Write("Lütfen pozitif tam sayıyı giriniz : ");
            bool isNumber = int.TryParse(Console.ReadLine(), out int arrCount);
            if (isNumber == false || arrCount<=0) 
            {
                Console.WriteLine("Girmiş olduğunuz değer pozitif bir sayı değil!");
                Soru3();
            }
            else
            {
                string[] arr = new string[arrCount];
                for (int i = 0; i < arrCount; i++)
                {
                    Console.Write("Lütfen {0}. kelimeyi giriniz : ", i + 1);
                    arr[i] = Console.ReadLine();
                }
                for (int i = arr.Length-1; i >=0; i--)
                {
                    Console.WriteLine(arr[i]);
                }
            }
        }
        public void Soru4() 
        {
            Console.WriteLine("SORU 4 : Bir konsol uygulamasında kullanıcıdan bir cümle yazması isteyin. Cümledeki toplam kelime ve harf sayısını console'a yazdırın.");
            Console.Write("Lütfen bir cümle giriniz:");
            string sentence = Console.ReadLine();
            string[] wordCountArr = sentence.Split(" ");
            int wordCount = wordCountArr.Length;
            int totalLettter = 0;
            for (var i=0;i<sentence.Length;i++)
            {
                if (char.IsLetter(sentence[i]))
                    totalLettter++;
            }
            Console.WriteLine("Girdiğiniz cümle toplam {0} kelimeden ve {1} harften oluşmaktadır.",wordCount,totalLettter);
        }

    }
}
