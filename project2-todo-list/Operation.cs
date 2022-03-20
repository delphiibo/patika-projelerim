using System;
using System.Collections.Generic;
namespace project2_todo_list
{
    class Operation
    {
        public void Start()
        {
            Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz :)");
            Library.WriteStarEnd();
            Console.WriteLine("(1) Board Listelemek");
            Console.WriteLine("(2) Board'a Kart Eklemek");
            Console.WriteLine("(3) Board'dan Kart Silmek");
            Console.WriteLine("(4) Kart Taşımak");
        }

        public void DefaultRecord()
        {
             TeamUsers.Add(1,"Ibrahim");
             TeamUsers.Add(2,"Ahmet");
             TeamUsers.Add(3,"Ayşe");
             TeamUsers.Add(4,"Fatma");
             TeamUsers.Add(5,"Halil");
             
             Boards.TodoLine.Add(new CartModel("MS-SQL","MS-Sql Eğitimi",TeamUsers.Find("Ayşe"),CartSize.Buyukluk.M));
             Boards.TodoLine.Add(new CartModel("C++","C++ Eğitimi",TeamUsers.Find("Ahmet"),CartSize.Buyukluk.XL));

             Boards.Board.Add("TO-DO Line",Boards.TodoLine);
             Boards.Board.Add("IN-PROGRESS Line",Boards.InProgressLine);
             Boards.Board.Add("DONE Line",Boards.DoneLine);
        }

        public void List()
        {
            foreach (var board in Boards.Board)
            {
                Console.WriteLine(board.Key);
                Library.WriteStarEnd();
                if (board.Value.Count<=0)
                    Console.WriteLine(" ~ BOŞ ~");
                else {
                    foreach (var list in board.Value)
                    {
                        Console.WriteLine("Başlık           : {0}",list.Baslik);
                        Console.WriteLine("İçerik           : {0}",list.Icerik);
                        Console.WriteLine("Atanan Kişi      : {0}",list.AtananKisi.KullaniciAdi);
                        Console.WriteLine("Büyüklük         : {0}",list.Buyukluk);
                        Console.WriteLine("-");
                    }
                }
            }
        }

        public void TeamUserList()
        {
            
            Library.WriteStarLine("Kayıtlı Kişiler");
            Library.WriteStarEnd();
            foreach (var item in TeamUsers.List())
            {
                Console.WriteLine("No   : {0}",item.Id);
                Console.WriteLine("Isim : {0}",item.KullaniciAdi);
                Console.WriteLine("-");
            }
        }

        public void Add()
        {
            Library.WriteStarLine("KAYIT EKLEME MODÜLÜ");
            string Baslik               = Library.NullControl    ("Başlık Giriniz                                       :","Başlık boş girilemez!");
            string Icerik               = Library.NullControl    ("İçerik Giriniz                                       :","İçerik boş girilemez!");
            CartSize.Buyukluk Buyukluk  = Library.CartSizeControl("Büyüklük Seçiniz -> XS(1),S(2),M(3),L(4),XL(5)       :","Büyüklük boş girilemez!","Büyüklük sayı olarak girilmelidir!","Büyüklük buluanamadı!");
            TeamUserModel Kisi          = Library.TeamUserControl("Kişi Seçiniz                                         :","Kişi boş girilemez","Kişi ID si sayı olarak girilmelidir!","Kişi ID'si bulunamadı!");
            CartModel cartmodel = new CartModel(Baslik,Icerik,Kisi,Buyukluk);
            Boards.TodoLine.Add(cartmodel);
            Library.MessageBox("Kayıt başarıyla eklendi!");
            Library.WriteStarEnd();
        }

        public void Delete()
        {
            bool isDelete = false;
            Library.WriteStarLine("KAYIT SİLME MODÜLÜ");
            Console.WriteLine("Öncelikle silmek istediğiniz kartı seçmeniz gerekiyor.");
            string baslik = Library.NullControl("Lütfen kart başlığını yazınız:","Kart başlığı boş geçilemez!");
            List<CartModel> todoLine = Boards.Find(Boards.TodoLine,baslik);
            List<CartModel> inProgressLine = Boards.Find(Boards.InProgressLine,baslik);
            List<CartModel> doneLine = Boards.Find(Boards.DoneLine,baslik);
            if (todoLine.Count<=0 && inProgressLine.Count<=0 && doneLine.Count<=0)
            {
                bool state = true;
                while (state == true)
                {
                    Console.WriteLine("Aradığınız krtiterlere uygun kart board'da bulunamadı. Lütfen bir seçim yapınız.");
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
                    else if (number=="")
                    {
                        Console.WriteLine("Seçim yapmadınız.Lütfen bir seçim yapınız!");
                        state = false;
                        continue;
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
                bool delete = Library.Confirm(String.Format("{0} başlıklı kart silinecek. Onaylıyor musunuz?",baslik));
                if (delete)
                {
                    foreach (var item in todoLine)
                        Boards.TodoLine.Remove(item);
                    foreach (var item in inProgressLine)
                        Boards.InProgressLine.Remove(item);
                    foreach (var item in doneLine)
                        Boards.DoneLine.Remove(item);
                    isDelete = true;
                }
            }
            if (isDelete)
                Library.MessageBox("Kayıt başarıyla silindi!");
            else 
                Console.WriteLine("Kayıt silme iptal edildi!");
            Library.WriteStarEnd();
        }
        public void Move()
        {
            bool isMove = false;
            Library.WriteStarLine("KAYIT TAŞIMA MODÜLÜ");
            Console.WriteLine("Öncelikle taşımak istediğiniz kartı seçmeniz gerekiyor.");
            string baslik = Library.NullControl("Lütfen kart başlığını yazınız:","Kart başlığı boş geçilemez!");
            List<CartModel> todoLine = Boards.Find(Boards.TodoLine,baslik);
            List<CartModel> inProgressLine = Boards.Find(Boards.InProgressLine,baslik);
            List<CartModel> doneLine = Boards.Find(Boards.DoneLine,baslik);
            if (todoLine.Count<=0 && inProgressLine.Count<=0 && doneLine.Count<=0)
            {
                bool state = true;
                while (state == true)
                {
                    Console.WriteLine("Aradığınız krtiterlere uygun kart board'da bulunamadı. Lütfen bir seçim yapınız.");
                    Console.WriteLine("* Taşımayı sonlandırmak için : (1)");
                    Console.WriteLine("* Yeniden denemek için       : (2)");
                    string number = Console.ReadLine();
                    if (number == "1")
                        state = false;
                    else if (number == "2")
                    {
                        state = false;
                        Move();
                    }
                    else if (number=="")
                    {
                        Console.WriteLine("Seçim yapmadınız.Lütfen bir seçim yapınız!");
                        state = false;
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("Seçeneklerde olmayan rakam girdiniz!");
                        state = false;
                        continue;
                    }
                }
                isMove = false;
            }
            else 
            {
                Console.WriteLine("Bulunan Kart Bilgileri:");
                Library.WriteStarEnd();
                foreach (var item in todoLine)
                {
                    Console.WriteLine("Başlık      : {0}",item.Baslik);
                    Console.WriteLine("İçerik      : {0}",item.Icerik);
                    Console.WriteLine("Atanan Kişi : {0}",item.AtananKisi.KullaniciAdi);
                    Console.WriteLine("Büyüklük    : {0}",item.Buyukluk);
                    Console.WriteLine("Line        : {0}","TO-DO Line");
                    Console.WriteLine("-");
                }
                foreach (var item in inProgressLine)
                {
                    Console.WriteLine("Başlık      : {0}",item.Baslik);
                    Console.WriteLine("İçerik      : {0}",item.Icerik);
                    Console.WriteLine("Atanan Kişi : {0}",item.AtananKisi.KullaniciAdi);
                    Console.WriteLine("Büyüklük    : {0}",item.Buyukluk);
                    Console.WriteLine("Line        : {0}","IN-PROGRESS Line");
                    Console.WriteLine("-");
                }
                foreach (var item in doneLine)
                {
                    Console.WriteLine("Başlık      : {0}",item.Baslik);
                    Console.WriteLine("İçerik      : {0}",item.Icerik);
                    Console.WriteLine("Atanan Kişi : {0}",item.AtananKisi.KullaniciAdi);
                    Console.WriteLine("Büyüklük    : {0}",item.Buyukluk);
                    Console.WriteLine("Line        : {0}","DONE Line");
                    Console.WriteLine("-");
                }
                Console.WriteLine("Lütfen taşımak istediğiniz Line'ı seçiniz:");
                Console.WriteLine("(1) TODO");
                Console.WriteLine("(2) IN PROGRESS");
                Console.WriteLine("(3) DONE");
                bool state = true;
                int number = 0;
                while (state==true)
                {
                    number = Library.NullNumberControl("Seçimizi Giriniz:","Seçim boş geçilemez!","Seçiminiz hatalı!");
                    if (number<1 || number>3)
                    {
                        Console.WriteLine("Seçiminiz yalnızca 1,2,3 rakamları olabilir!");
                        continue;
                    }
                    else 
                    {
                        state = false;
                        continue;   
                    }
                }
                foreach (var item in todoLine)
                    Boards.TodoLine.Remove(item);
                foreach (var item in inProgressLine)
                    Boards.InProgressLine.Remove(item);
                foreach (var item in doneLine)
                    Boards.DoneLine.Remove(item);
                if (number==1)
                {
                    foreach (var item in todoLine)
                        Boards.TodoLine.Add(item);
                    foreach (var item in inProgressLine)
                        Boards.TodoLine.Add(item);
                    foreach (var item in doneLine)
                        Boards.TodoLine.Add(item);
                }
                else if (number==2)
                {
                   foreach (var item in todoLine)
                        Boards.InProgressLine.Add(item);
                    foreach (var item in inProgressLine)
                        Boards.InProgressLine.Add(item);
                    foreach (var item in doneLine)
                        Boards.InProgressLine.Add(item);
                }
                else if (number==3)
                {
                   foreach (var item in todoLine)
                        Boards.DoneLine.Add(item);
                    foreach (var item in inProgressLine)
                        Boards.DoneLine.Add(item);
                    foreach (var item in doneLine)
                        Boards.DoneLine.Add(item);
                }
                isMove = true;
            }
            if (isMove)
                Library.MessageBox("Kayıt başarıyla taşındı!");
            else 
                Console.WriteLine("Kayıt taşıma iptal edildi!");
            Library.WriteStarEnd();
        }
        public bool Close()
        {
            return Library.Confirm("Programdan çıkmak istediğinize emin misiniz?");
        }
    }
}