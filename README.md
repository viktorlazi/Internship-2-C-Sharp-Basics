# Internship-2-C-Sharp-Basics

Izradite .NET Core konzolnu aplikaciju za izradu glazbene playliste. Aplikacija treba raditi na način da se pri pokretanju otvara izbornik za odabir akcije:. 


Playlista mora biti implementirana kao Dictionary<int, string>, gdje je ključ redni broj pjesme u listi, a string ime pjesme. Pjesme uvijek moraju biti po redu, odnosno u nijednom trenutku ne smije nedostajati nijedan broj u intervalu između prve i zadnje pjesme na listi. 
Ne smije se moći unijeti pjesma koja već postoji u listi(isti value u elementima dictionarya).


Sve akcije moraju biti popraćene ispravnim ispisom koji obavještava korisnika u kojem je koraku akcije koju pokušava izvesti, npr. “Unesite novo ime pjesme koju ste odabrali editirati:”. 
Sve akcije koje mijenjaju podatke (sve osim ispisa) moraju imati potvrdni dijalog, odnosno izbornik koji traži korisnika da potvrdi akciju koju je odabrao. 
U slučaju da akcija ne nađe traženu pjesmu u listi (po imenu ili rednom broju) također treba pružiti odgovarajući ispis, te dati korisniku mogućnost da se vrati na početni izbornik.

Izbornik:
1 - Ispis cijele liste
2 - Ispis imena pjesme unosom pripadajućeg rednog broja
3 - Ispis rednog broja pjesme unosom pripadajućeg imena
4 - Unos nove pjesme
5 - Brisanje pjesme po rednom broju
6 - Brisanje pjesme po imenu
7 - Brisanje cijele liste
8 - Uređivanje imena pjesme
(U redu je dohvaćati pjesmu i po imenu i po rednom broju, odaberite što vam je draže)
9 - Uređivanje rednog broja pjesme, odnosno premještanje pjesme na novi redni broj u listi
(Ako pjesmu rednog broja 8 premještamo na redni broj 4, pjesme 4 -7 se moraju pomaknuti za jedno mjesto unaprijed, dok 8 ide na mjesto 4)
0 - Izlaz iz aplikacije

Bonus:
10 - Shuffle pjesama, odnosno nasumično premještanje elemenata liste
