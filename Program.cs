using System;
using System.Collections.Generic;

namespace Internship_2_C_Sharp_Basics
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear(); // clear the terminal at the start

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
                
                try{
                var userInput = Console.ReadLine();
                Console.Clear();

                switch(int.Parse(userInput)){
                    case 0:
                        Environment.Exit(0);
                        break;
                    case 1:
                        Console.ForegroundColor = ConsoleColor.Red;
                        PrintList(playList);
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case 2:
                        PrintByKey(playList);
                        break;
                    case 3:
                        PrintByValue(playList);
                        break;
                    case 4:
                        NewSong(ref playList);
                        break;
                    case 5:
                        DeleteByKey(ref playList);
                        break;
                    case 6:
                        DeleteByName(ref playList);
                        break;
                    case 7:
                        DeleteDictionary(ref playList);
                        break;
                    case 8:
                        ChangeSongName(ref playList);
                        break;
                    case 9:
                        ChangeSongKey(ref playList);
                        break;
                    default:
                        Console.WriteLine("Krivi unos");
                        break;
                }

                System.Console.WriteLine("\n\n\n -- Enter za povratak ---");
                Console.ReadLine();

                Console.Clear();
                }
                catch{
                    Console.Clear();
                    System.Console.WriteLine("Mozete unijeti samo broj!");
                    System.Console.WriteLine("\n\n\n -- Enter za povratak ---");
                    Console.ReadLine();
                    Console.Clear();
                }
            }while(true);
        }

            /* GENERAL FUNCTIONS */
            ///////////////////////
        static bool UserCheck(string msg = ""){ // user confirmation for the change            
            System.Console.WriteLine();
            if(msg != ""){System.Console.WriteLine(msg);} // if parameter is inputed
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
            }while(true); // if the input is invalid, ask again...
        }

        static void RemoveByKey(ref Dictionary<int, string> x, int songKey){
            // shift value by one place for every item after the deleted item
            // at the end remove the last item

            foreach(var pair in x){
                if(pair.Key == x.Count){
                    x.Remove(pair.Key);
                    System.Console.WriteLine("Pjesma je uklonjena.");
                }
                else if(pair.Key >= songKey){
                    x[pair.Key] = x[pair.Key+1];
                }
            }
        }

        static int FindByName(ref Dictionary<int,string> x, string name){
            // return the item key from inputed value
            int songKey = 0;
            foreach(var pair in x){
                if(name.Equals(pair.Value)){
                    songKey = pair.Key;
                    break;
                }
            }
            return songKey;
        }

        static void ChangeNumber(ref Dictionary<int,string> x, int oldKey, int newKey){

            //check if valid input
            if(oldKey > 0 && oldKey <= x.Count && newKey > 0 && newKey <= x.Count ){
                if(oldKey == newKey){
                    System.Console.WriteLine("Pjesma je vec na tom rednom broju");
                }else if(oldKey > newKey){
                    var valueBeforeChange = x[oldKey];
                    for(int i = oldKey;i>newKey;i--){
                        x[i] = x[i-1];
                    }
                    x[newKey] = valueBeforeChange; 
                    System.Console.WriteLine("Broj je promijenjen");

                }else if(oldKey < newKey){
                    var valueBeforeChange = x[oldKey];
                    for(int i = oldKey;i<newKey;i++){
                        x[i] = x[i+1];
                    }
                    x[newKey] = valueBeforeChange; 
                    System.Console.WriteLine("Broj je promijenjen");
                }
            }else{
                System.Console.WriteLine("Brojevi su pogresni");
                return;
            }            
        }
            /* PROGRAM FUNCTIONS */
            ///////////////////////
        static void PrintList(Dictionary<int, string> x){
            if(x.Count > 0){                
                System.Console.WriteLine("Playlista:");
                foreach(var pair in x){
                    System.Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
                }   
            }else{
                System.Console.WriteLine("Playlista je prazna");
            }
        }

        static void PrintByKey(Dictionary<int, string> x){
            Console.WriteLine("Unesi redni broj pjesme: ");
            try{
                int userKey = int.Parse(System.Console.ReadLine());

                string songName;
                if(x.TryGetValue(userKey, out songName)){
                    Console.WriteLine("Naziv pjesme: {0}", songName);
                }else{
                    System.Console.WriteLine("Pjesma ne postoji.");
                }
            }catch{
                System.Console.WriteLine("Mozete unijeti samo broj!");
            }
        }

        static void PrintByValue(Dictionary<int, string> x){
            Console.WriteLine("Unesi naziv pjesme: ");
            string userSongName = System.Console.ReadLine();

            int songKey = FindByName(ref x, userSongName);
            if(Convert.ToBoolean(songKey)){
                System.Console.WriteLine("Redni broj pjesme: {0}", songKey);
            }else{
                System.Console.WriteLine("Pjesma ne postoji");
            }
        }
        static void NewSong(ref Dictionary<int, string> x){
            System.Console.WriteLine("Zelite unijeti novu pjesmu.");
            System.Console.WriteLine("Naziv pjesme: ");

            var userSong = Console.ReadLine();
            string msg = "Zelite unijeti pjesmu \"" + userSong + "\"";
            
            if(!userSong.Equals("")){
                if(!Convert.ToBoolean(FindByName(ref x, userSong))){ // check if exists
                    if(UserCheck(msg)){
                        var songKey = x.Count + 1;
                        x.Add(songKey, userSong);
                        System.Console.WriteLine("Pjesma je unesena u playlistu");
                    }else{
                        System.Console.WriteLine("Pjesma nije unesena u playlistu");
                    }
                }else{
                    System.Console.WriteLine("Pjesma vec postoji u playlisti");
                }
            }else{
                System.Console.WriteLine("Niste unijeli naziv");
            }
        }

        static void DeleteByKey(ref Dictionary<int, string> x){
            Console.ForegroundColor = ConsoleColor.Red;
            PrintList(x);
            Console.ForegroundColor = ConsoleColor.White;
            
            System.Console.WriteLine("---------------");
            System.Console.WriteLine("Zelite ukloniti pjesmu.");
            System.Console.WriteLine("Unesite redni broj:");
            
            try{
                var userKey = int.Parse(Console.ReadLine());
            
                string songName;
                if(x.TryGetValue(userKey, out songName)){ // check if exists
                    string msg = "Zelite ukloniti pjesmu \"" + songName + "\"";
                    if(UserCheck(msg)){
                        RemoveByKey(ref x, userKey); 
                    }else{
                        System.Console.WriteLine("Pjesma \"" + songName + "\" nece biti uklonjena!");
                    }
                }else{
                    System.Console.WriteLine("Pjesma ne postoji.");
                }
            }catch(Exception e){
                System.Console.WriteLine("Pogresan unos");
            }
        }

        static void DeleteByName(ref Dictionary<int, string> x){
            Console.ForegroundColor = ConsoleColor.Red;
            PrintList(x);
            Console.ForegroundColor = ConsoleColor.White;

            System.Console.WriteLine("---------------");
            System.Console.WriteLine("Zelite ukloniti pjesmu.");
            System.Console.WriteLine("Unesite ime pjesme:");
            var userName = Console.ReadLine();

            int songKey = FindByName(ref x, userName);
            
            if(Convert.ToBoolean(songKey)){
                string msg = "Zelite ukloniti pjesmu \"" + userName + "\"";
                if(UserCheck(msg)){
                    RemoveByKey(ref x, songKey);
                }else{
                    System.Console.WriteLine("Pjesma \"" + userName + "\" nece biti uklonjena!");
                }
            }else{
                System.Console.WriteLine(
                    "Pjesma pod nazivom \"" +
                    userName +
                    "\" ne postoji u playlisti"
                );
            }
        }

        static void DeleteDictionary(ref Dictionary<int, string> x){
            if(x.Count > 0){ // check if empty
                System.Console.WriteLine("Zelite obrisati {0} pjesama. Promjene se nece moci vratiti!",x.Count);
                if(UserCheck()){
                    while(x.Count > 0){
                        x.Remove(x.Count);
                    }
                    System.Console.WriteLine("Playlista je obrisana!");
                }else{
                    System.Console.WriteLine("Playlista je ostala netaknuta. :)");
                }
            }else{
                System.Console.WriteLine("Playlista je vec prazna!");
            }
        }

        static void ChangeSongName(ref Dictionary<int, string> x){
            Console.ForegroundColor = ConsoleColor.Red;
            PrintList(x);
            Console.ForegroundColor = ConsoleColor.White;

            System.Console.WriteLine("---------------");
            System.Console.WriteLine("Zelite pormijeniti ime pjesme.");
            System.Console.WriteLine("Unesite broj pjesme: ");

            try{
            var userKey = int.Parse(Console.ReadLine());
            
            System.Console.WriteLine("Kako zelite promijeniti naziv pjesme \"{0}\"?", x[userKey]);
            var userSongName = Console.ReadLine();

            x[userKey] = userSongName;

            System.Console.WriteLine("Naziv promijenjen");
            }catch{
                System.Console.WriteLine("Mozete unijeti samo broj");
            }
        }
    
        static void ChangeSongKey(ref Dictionary<int, string> x){
            Console.ForegroundColor = ConsoleColor.Red;
            PrintList(x);
            Console.ForegroundColor = ConsoleColor.White;
            
            System.Console.WriteLine("---------------");
            System.Console.WriteLine("Zelite pormijeniti broj pjesme.");
            System.Console.WriteLine("Unesite broj pjesme: ");

            try{
                var oldKey = int.Parse(Console.ReadLine());
                
                System.Console.WriteLine("Unesite novi broj za pjesmu \"{0}\"?", x[oldKey]);
                var newKey = int.Parse(Console.ReadLine());

                ChangeNumber(ref x, oldKey, newKey);
            }
            catch{
                System.Console.WriteLine("Mozete unijeti samo broj!");
            }
        }
    }
}
