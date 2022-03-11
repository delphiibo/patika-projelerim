using System;

namespace static_sinif_ve_uyeler
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Çalışan Sayısı: {0}",Calisan.CalisanSayisi);
            
            Calisan calisan = new Calisan("Ayşe","Yılmaz","İK");
            Console.WriteLine("Çalışan Sayısı: {0}",Calisan.CalisanSayisi);
            Calisan calisan1 = new Calisan("Deniz","Arda","İK");
            Calisan calisan2 = new Calisan("zikriye","Ürkmez","İK");
            Console.WriteLine("Çalışan Sayısı: {0}",Calisan.CalisanSayisi);
        }
    }
    class Calisan 
    {
        private static int calisanSayisi;

        public static int CalisanSayisi { get => calisanSayisi; }

        private string Isim; 
        private string Soyisim;
        private string Departman;

        static Calisan()
        {
            calisanSayisi = 0;
        }
        public Calisan(string ısim, string soyisim, string departman)
        {
            this.Isim = ısim;
            this.Soyisim = soyisim;
            this.Departman = departman;
            calisanSayisi++;
        }
    }
}
