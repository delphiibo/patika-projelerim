using System;

namespace abstract_class
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("**********************");
            NewFocus newFocus = new NewFocus();
            Console.WriteLine(newFocus.HangiMarkaninAraci());
            Console.WriteLine(newFocus.KacTekerlektenOlusur());
            Console.WriteLine(newFocus.StandartRengiNe());
            
            Console.WriteLine("**********************");
            NewCivic newCivic = new NewCivic();
            Console.WriteLine(newCivic.HangiMarkaninAraci());
            Console.WriteLine(newCivic.KacTekerlektenOlusur());
            Console.WriteLine(newCivic.StandartRengiNe());
        }
    }
}
