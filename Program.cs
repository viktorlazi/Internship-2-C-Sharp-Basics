using System;
using System.Collections.Generic;

namespace Internship_2_C_Sharp_Basics
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear(); // clear the terminal at the start

            int userInput = 0;
            var playList = new Dictionary<int, string>();
            playList.Add(1, "Lemon song");
            playList.Add(2, "Lijepe zene prolaze kroz grad");
            playList.Add(3, "Milde sorte");


            

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
                "10 - Shuffle pjesama \n" +
                "0 - Izlaz iz aplikacije"
                );
                userInput = int.Parse(Console.ReadLine());

                switch(userInput){
                    case 1:
                        printList(playList);
                        break;
                    case 2:
                        printByKey(playList);
                        break;
                    case 3:
                        printByValue(playList);
                        break;
                    default:
                        Console.WriteLine("Krivi unos");
                        break;
                }

                System.Console.WriteLine("\n\n\n -- Enter za povratak ---");
                Console.ReadLine();

                Console.Clear();
            }while(userInput != 0);
        }

        static void printList(Dictionary<int, string> x){
            Console.Clear();
            System.Console.WriteLine("Playlista:");
            foreach(var pair in x){
                System.Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
            }   
        }
        static void printByKey(Dictionary<int, string> x){
            Console.Clear();
            Console.WriteLine("Unesi redni broj pjesme: ");
            int userKey = int.Parse(System.Console.ReadLine());

            string songName;
            if(x.TryGetValue(userKey, out songName)){
                Console.WriteLine("Naziv pjesme: {0}", songName);
            }else{
                System.Console.WriteLine("Pjesma ne postoji.");
            }
        }

        static void printByValue(Dictionary<int, string> x){
            Console.Clear();
            Console.WriteLine("Unesi naziv pjesme: ");
            string userName = System.Console.ReadLine();

            bool found = false;
            foreach(var pair in x){
                if(userName.Equals(pair.Value)){
                    found = true;
                    System.Console.WriteLine("Redni broj: {0}", pair.Key);
                    break;
                }
            }
            if(!found){
                System.Console.WriteLine("Pjesma ne postoji");
            } 
        }


    }
}
