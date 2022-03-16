using System;

namespace inheritance
{
    public class Bitkiler : Canlilar
    {
        protected void FotosentezYapmak()
        {
            Console.WriteLine("Bitkiler fotosentez yapar.");
        }

        public override void UyaranlaraTepki()
        {
            //base.UyaranlaraTepki();
            Console.WriteLine("Bitkiler güneşe tepki verir.");
        }
    }

    public class TohumluBitkiler:Bitkiler{
        public TohumluBitkiler() {
            base.FotosentezYapmak();
            base.Beslenme();
            base.Solunum();
            base.Bosaltim();
            base.UyaranlaraTepki();
        }
        public void TohumlaCogalma(){
             Console.WriteLine("Tohumlu bitkiler tohumla çoğalır.");   
        }
    }

    public class TohumsuzBitkiler:Bitkiler{
        public TohumsuzBitkiler()
        {
            base.FotosentezYapmak();
            base.Beslenme();
            base.Solunum();
            base.Bosaltim();
        }
        public void SporlaCogalma(){
             Console.WriteLine("Tohumlu bitkiler sporla çoğalır.");   
        }
    }
}