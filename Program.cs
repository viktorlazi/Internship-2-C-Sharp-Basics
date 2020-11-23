using System;

namespace Internship_2_C_Sharp_Basics
{
    class Program
    {
        static void Main(string[] args)
        {
            int userInput = 0;

            do{
            Console.WriteLine(
            "1 - Ispis cijele liste \n" +
            "2 - Ispis imena pjesme unosom pripadajućeg rednog broja \n" +
            "3 - Ispis rednog broja pjesme unosom pripadajućeg imena \n" +
            "4 - Unos nove pjesme \n" +
            "5 - Brisanje pjesme po rednom broju \n" +
            "6 - Brisanje pjesme po imenu \n" +
            "7 - Brisanje cijele liste \n" +
            "8 - Uređivanje imena pjesme \n" +
            "9 - Uređivanje rednog broja pjesme \n" +
            "0 - Izlaz iz aplikacije"
            );
            userInput = int.Parse(Console.ReadLine());

            Console.Clear();
            }while(userInput != 0);
            
        }
    }
}
