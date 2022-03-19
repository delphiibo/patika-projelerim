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
        public void DefaultList()
        {
            phoneBook.Add("ibrahim","dağ","05394119674");
            phoneBook.Add("leyla","dağ","05421417496");
            phoneBook.Add("süleyman","paşa","05394117496");
            phoneBook.Add("halil","akyol","05367984123");
            phoneBook.Add("sabri","demir","05439647899");
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
            List<PhoneBookModel> list = phoneBook.List();
            Console.WriteLine("Telefon Rehberi");
            Library.WriteStarEnd();
            if (list.Count <= 0)
                Library.MessageBox("Rehberde Kayıt Bulunamadı!");
            else
            {
                Console.WriteLine("Rehberde Toplam {0} kayıt mevcut.", list.Count);
                Library.WriteStarEnd();
                foreach (var item in list)
                {
                    Console.WriteLine("İsim: {0}", item.Isim);
                    Console.WriteLine("Soyisim: {0}", item.Soyisim);
                    Console.WriteLine("Telefon: {0}", item.Telefon);
                    Console.WriteLine("-");
                }
            }
        }

        public void Search()
        {
            Library.WriteStarLine("KAYIT ARAMA MODÜLÜ");
            Console.WriteLine("Arama yapmak istediğiniz tipi seçiniz.");
            Library.WriteStarEnd();
            Console.WriteLine("İsim veya soyisime göre arama yapmak için: (1)");
            Console.WriteLine("Telefon numarasına göre arama yapmak için: (2)");
            List<PhoneBookModel> list = new List<PhoneBookModel>();
            bool state = true;
            while (state == true)
            {
                string command = Console.ReadLine();
                if (command == "1")
                {
                    string isimsoyisim = Library.NullControl("Lütfen İsim veya soyisim giriniz:", "İsim soyisim bilgisi boş geçilemez!");
                    list = phoneBook.Find(isimsoyisim, isimsoyisim, "");
                    state = false;
                    continue;
                }
                else if (command == "2")
                {
                    string telefon = Library.NullControl("Lütfen telefon giriniz:", "Telefon bilgisi boş geçilemez!");
                    list = phoneBook.Find("", "", telefon);
                    state = false;
                    continue;
                }
                else
                {
                    Console.WriteLine("Seçeneklerde olmayan rakam girdiniz!");
                    Console.WriteLine("İsim veya soyisime göre arama yapmak için: (1)");
                    Console.WriteLine("Telefon numarasına göre arama yapmak için: (2)");
                    state = false;
                    continue;
                }
            }
            if (list.Count <= 0)
                Library.MessageBox("Kayıt Bulunamadı!");
            else
            {
                Console.WriteLine("Arama Sonuçlarınız:");
                Library.WriteStarEnd();
                foreach (var item in list)
                {
                    Console.WriteLine("İsim: {0}", item.Isim);
                    Console.WriteLine("Soyisim: {0}", item.Soyisim);
                    Console.WriteLine("Telefon: {0}", item.Telefon);
                    Console.WriteLine("-");
                }

            }
            Library.WriteStarEnd();
        }

        public void Add()
        {
            Library.WriteStarLine("KAYIT EKLEME MODÜLÜ");
            string isim = Library.NullControl("Lütfen İsim giriniz             :", "İsim bilgisi boş geçilemez!");
            string soyisim = Library.NullControl("Lütfen Soyisim giriniz          :", "Soyisim bilgisi boş geçilemez!");
            string telefon = Library.NullControl("Lütfen Telefon giriniz          :", "Telefon bilgisi boş geçilemez!");
            phoneBook.Add(isim, soyisim, telefon);
            Library.MessageBox("Kayıt başarıyla eklendi!");
            Library.WriteStarEnd();
        }

        public void Update()
        {
            Library.WriteStarLine("KAYIT GÜNCELLEME MODÜLÜ");
            bool isUpdate = false;
            string isimsoyisim = Library.NullControl("Lütfen numarasını güncellemek istediğiniz kişinin adını ya da soyadını giriniz:", "Bu alan boş geçilemez!");
            List<PhoneBookModel> List = new List<PhoneBookModel>();
            List = phoneBook.Find(isimsoyisim, isimsoyisim, "");
            if (List.Count <= 0)
            {
                bool state = true;
                while (state == true)
                {
                    Console.WriteLine("Aradığınız kriterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.");
                    Console.WriteLine("* Güncellemeyi sonlandırmak için : (1)");
                    Console.WriteLine("* Yeniden denemek için           : (2)");
                    string number = Console.ReadLine();
                    if (number == "1")
                        state = false;
                    else if (number == "2")
                    {
                        state = false;
                        Update();
                    }
                    else
                    {
                        Console.WriteLine("Seçeneklerde olmayan rakam girdiniz!");
                        state = false;
                        continue;
                    }
                }
                isUpdate = false;
            }
            else
            {
                Console.WriteLine("Güncellenecek kayıt bilgileri : ");
                Console.WriteLine("İsim: {0}", List[0].Isim);
                Console.WriteLine("Soyisim: {0}", List[0].Soyisim);
                Console.WriteLine("Telefon: {0}", List[0].Telefon);
                Console.WriteLine("-");
                Console.WriteLine("Güncellenecek kayıt için yeni bilgileri giriniz: ");
                string isim = Library.NullControl("Lütfen İsim giriniz             :", "İsim bilgisi boş geçilemez!");
                string soyisim = Library.NullControl("Lütfen Soyisim giriniz          :", "Soyisim bilgisi boş geçilemez!");
                string telefon = Library.NullControl("Lütfen Telefon giriniz          :", "Telefon bilgisi boş geçilemez!");
                List[0].Isim = isim;
                List[0].Soyisim = soyisim;
                List[0].Telefon = telefon;
                isUpdate = true;
            }
            if (isUpdate)
                Library.MessageBox("Kayıt başarıyla güncellendi!");
            Library.WriteStarEnd();
        }

        public void Delete()
        {
            Library.WriteStarLine("KAYIT SİLME MODÜLÜ");
            bool isDelete = false;
            string isimsoyisim = Library.NullControl("Lütfen numarasını silmek istediğiniz kişinin adını ya da soyadını giriniz:", "Bu alan boş geçilemez!");
            List<PhoneBookModel> List = new List<PhoneBookModel>();
            List = phoneBook.Find(isimsoyisim, isimsoyisim, "");
            if (List.Count <= 0)
            {
                bool state = true;
                while (state == true)
                {
                    Console.WriteLine("Aradığınız kriterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.");
                    Console.WriteLine("* Silmeyi sonlandırmak için : (1)");
                    Console.WriteLine("* Yeniden denemek için      : (2)");
                    string number = Console.ReadLine();
                    if (number == "1")
                        state = false;
                    else if (number == "2")
                    {
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
                bool delete = Library.Confirm(String.Format("{0} isimli kişi rehberden silinmek üzere, onaylıyor musunuz?", List[0].Isim));
                if (delete)
                {
                    phoneBook.Delete(List[0]);
                    isDelete = true;
                }
                else
                    Console.WriteLine("Kayıt silme iptal edildi!");
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