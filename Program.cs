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
                Console.Clear();

                switch(userInput){
                    case 0:
                        break;
                    case 1:
                        PrintList(playList);
                        break;
                    case 2:
                        PrintByKey(playList);
                        break;
                    case 3:
                        PrintByValue(playList);
                        break;
                    case 4:
                        NewSong(playList);
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

        static bool UserCheck(){
            System.Console.WriteLine("Jeste li sigurni? d/n: ");

            do{
                var userInput = Console.ReadLine();

                if(userInput.Equals("d") || userInput.Equals("da")){
                    return true;
                }else if(userInput.Equals("n") || userInput.Equals("ne")){
                    return false;
                }else{
                    System.Console.WriteLine("Pogresan unos.\n" +
                                    "Dozvoljeni unosi su:\n" +
                                    "da/ne/d/n \n");
                    System.Console.WriteLine("Jeste li sigurni? d/n: ");
                }
            }while(true);
        }
        static void PrintList(Dictionary<int, string> x){
            System.Console.WriteLine("Playlista:");
            foreach(var pair in x){
                System.Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
            }   
        }
        static void PrintByKey(Dictionary<int, string> x){
            Console.WriteLine("Unesi redni broj pjesme: ");
            int userKey = int.Parse(System.Console.ReadLine());

            string songName;
            if(x.TryGetValue(userKey, out songName)){
                Console.WriteLine("Naziv pjesme: {0}", songName);
            }else{
                System.Console.WriteLine("Pjesma ne postoji.");
            }
        }

        static void PrintByValue(Dictionary<int, string> x){
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
        static void NewSong(Dictionary<int, string> x){
            System.Console.WriteLine("Zelite unijeti novu pjesmu.");
            System.Console.WriteLine("Naziv pjesme: ");

            var userSong = Console.ReadLine();
            
            if(!userSong.Equals("")){
                if(UserCheck()){
                    var songKey = x.Count + 1;
                    x.Add(songKey, userSong);
                    System.Console.WriteLine("Pjesma je unesena u playlistu");
                }else{
                    System.Console.WriteLine("Pjesma nije unesena u playlistu");
                }
            }else{
                System.Console.WriteLine("Niste unijeli naziv");
            }
        }

        static void DeleteByKey(){

        }
    }
}
