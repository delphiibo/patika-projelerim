using System;

namespace inheritance
{
    public class Hayvanlar:Canlilar
    {
        protected void Adaptasyon()
        {
           Console.WriteLine("Hayvanlar adaptasyon kurabilir."); 
        }

        public override void UyaranlaraTepki()
        {
            base.UyaranlaraTepki();
            Console.WriteLine("Hayvanlar temasa tepki verir.");
        }
    }

    public class Surungenler:Hayvanlar{
        public Surungenler() {
            base.Adaptasyon();
            base.Beslenme();
            base.Solunum();
            base.Bosaltim();
        }
        public void SurunerekHareketEderler()
        {
            Console.WriteLine("Sürünler sürünerek hareket eder."); 
        }
    }

    public class Kuslar:Hayvanlar{
        public Kuslar() {
            base.Adaptasyon();
            base.Beslenme();
            base.Solunum();
            base.Bosaltim();
            base.UyaranlaraTepki();
        }
        public void Ucmak()
        {
            Console.WriteLine("Kuşlar uçar."); 
        }
    }
}