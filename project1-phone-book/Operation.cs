using System;
using System.Collections.Generic;

namespace project1_phone_book
{
    class Operation
    {
        PhoneBook phoneBook = new PhoneBook();

        public void Welcome()
        {
            Console.WriteLine("Telefon rehberi uygulamasına hoş geldiniz!");
        }
        public void Start()
        {
            Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz :)");
            Library.WriteStarEnd();
            Console.WriteLine("(1) Yeni Numara Kaydetmek");
            Console.WriteLine("(2) Varolan Numarayı Silmek");
            Console.WriteLine("(3) Varolan Numarayı Güncelleme");
            Console.WriteLine("(4) Rehberi Listelemek");
            Console.WriteLine("(5) Rehberde Arama Yapmak");
        }

        public void List()
        {
            List<PhoneBookModel> list = phoneBook.List(false);
            Console.WriteLine("Telefon Rehberi");
            Library.WriteStarEnd();
            if (list.Count<=0)
                Library.MessageBox("Rehberde Kayıt Bulunamadı!");
            else {
                Console.WriteLine("Rehberde Toplam {0} kayıt mevcut.",list.Count);
                Library.WriteStarEnd();
                foreach (var item in list)
                {
                    Console.WriteLine("İsim: {0}",item.Isim);
                    Console.WriteLine("Soyisim: {0}",item.Soyisim);
                    Console.WriteLine("Telefon: {0}",item.Telefon);
                    Console.WriteLine("-");
                }
            }
        }

        public void Search()
        {
            Library.WriteStarLine("KAYIT ARAMA MODÜLÜ");
            Console.WriteLine("İsim veya soyisime göre arama yapmak için: (1)");
            Console.WriteLine("Telefon numarasına göre arama yapmak için: (2)");
            bool state = true;
            while (state==true)
            {
                string command = Console.ReadLine();
                if (command=="1")
                {
                    
                }
                else if (command=="2")
                {

                }
                else 
                {
                    Console.WriteLine("Seçeneklerde olmayan rakam girdiniz!");
                    state=false;
                    continue;
                }
            }
            Library.WriteStarEnd();
        }

        public void Add()
        {
            Library.WriteStarLine("KAYIT EKLEME MODÜLÜ");
            string isim     = Library.nullControl("Lütfen İsim giriniz             :","İsim bilgisi boş geçilemez!"); 
            string soyisim  = Library.nullControl("Lütfen Soyisim giriniz          :","Soyisim bilgisi boş geçilemez!"); 
            string telefon  = Library.nullControl("Lütfen Telefon giriniz          :","Telefon bilgisi boş geçilemez!"); 
            phoneBook.Add(isim,soyisim,telefon);
            Library.MessageBox("Kayıt başarıyla eklendi!");
            Library.WriteStarEnd();
        }

        public void Delete()
        {
            Library.WriteStarLine("KAYIT SİLME MODÜLÜ");
            bool isDelete = false;
            string isimsoyisim  = Library.nullControl("Lütfen numarasını silmek istediğiniz kişinin adını ya da soyadını giriniz:","Bu alan boş geçilemez!"); 
            List<PhoneBookModel> List = new List<PhoneBookModel>();
            List = phoneBook.Find(isimsoyisim);
            if (List.Count<=0)
            {
                bool state = true;
                while (state==true)
                {
                    Console.WriteLine("Aradığınız kriterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.");
                    Console.WriteLine("* Silmeyi sonlandırmak için : (1)");
                    Console.WriteLine("* Yeniden denemek için      : (2)");
                    string number = Console.ReadLine();
                    if (number=="1")
                        state = false;
                    else if (number=="2") {
                        state = false;
                        Delete();
                    }
                    else
                    {
                        Console.WriteLine("Seçeneklerde olmayan rakam girdiniz!");
                        state = false;
                        continue;
                    }
                }
                isDelete = false;
            }
            else 
            {
                phoneBook.Delete(List[0]);
                isDelete = true;
            }
            if (isDelete)
                Library.MessageBox("Kayıt başarıyla silindi!");
            Library.WriteStarEnd();
        }

        public bool Close()
        {
            return Library.Confirm("Programdan çıkmak istediğinize emin misiniz?");
        }

        
    }
}