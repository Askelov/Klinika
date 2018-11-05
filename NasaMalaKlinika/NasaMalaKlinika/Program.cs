using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IspisiOpcijeLibrary;

delegate double del(double cijena);//Deklaracija delegata

namespace NasaMalaKlinika
{
    class Program
    {
        static void Main(string[] args)
        {
            //apstraktna klasa: Osoba
            //partial klasa: HitniPacijent
            //sealed klasa: Doktor
            int izbor = 0;
            string pom;
            Klinika klnika17337 = new Klinika();    //ime promjenjivih oblika kolekcijaINDEX_br
            Pacijent pacijent17337_1 = new Pacijent("Marko", "Markovic", "1111111111111", "adresa 1", "musko", "ozenjen", Convert.ToDateTime("18.12.1980"), Convert.ToDateTime("17.11.2017"));
            HitniPacijent pacijent17337_2 = new HitniPacijent(pacijent17337_1, true, "primio prvu pomoc");
            Doktor doktor17337_1 = new Doktor("Vedad","Vedovic","2222222222222","Adresa 2","musko","ozenjen", Convert.ToDateTime("10.12.1970"), "sifra1", 1000.0, "doktor" , "hirurg", 4 );
            Pregled pregled17337_1 = new Pregled("Vedad", "Vedovic", "2222222222222", "neurohirurgija", "2-12", "Marko", "Markovic", "1111111111111", 50, "virus", "injekcije", Convert.ToDateTime("10.10.2017"),12);
            klnika17337.DodajPregled(pregled17337_1);
            List<Pregled> pregledi17337_1=new List<Pregled>();
            pregledi17337_1.Add(pregled17337_1);
            Uposleni uposleni17337_1 = new Uposleni("Neko", "Nekic", "3333333333333", "neka 3", "musko", "ozenjen", Convert.ToDateTime("28.12.1975"), "sifra1", 10000.0, "medicinski tehnicar");           
            Karton karton17337_1 = new Karton("Marko", "Markovic", "1111111111111", pregledi17337_1,"alergican na polen","imao je pljuskavice","poreodica nije imala zdravstevnih problema");
            klnika17337.DodajKarton(karton17337_1);
            klnika17337.DodajPacijenta(pacijent17337_1);
            klnika17337.DodajUposlenog(doktor17337_1);
            klnika17337.DodajUposlenog(uposleni17337_1);




            do
            {
                Class1.IspisiOpcije(); //pozivanje funkcij za ispis preko klase iz dll 

                do
                {
                    pom = Console.ReadLine();
                    if (!Int32.TryParse(pom, out izbor) || izbor < 1 || izbor > 8) Console.WriteLine("Unos nije validan! Unesite ponovo.");
                } while (!Int32.TryParse(pom, out izbor) || izbor < 1 || izbor > 8);

                switch (izbor)
                {
                    case 1:
                        do
                        {
                            Console.WriteLine("1. Registruj pacijenta");
                            Console.WriteLine("2. Briši pacijenta");
                            pom = Console.ReadLine();
                            if (!Int32.TryParse(pom, out izbor) || izbor < 1 || izbor > 2) Console.WriteLine("Unos nije validan! Unesite ponovo.");
                        } while (!Int32.TryParse(pom, out izbor) || izbor < 1 || izbor > 2);
                        if (izbor == 1)
                        {
                            do
                            {
                                Console.WriteLine("1. Pacijent");
                                Console.WriteLine("2. Hitni pacijent");
                                pom = Console.ReadLine();
                                if (!Int32.TryParse(pom, out izbor) || izbor < 1 || izbor > 2) Console.WriteLine("Unos nije validan! Unesite ponovo.");
                            } while (!Int32.TryParse(pom, out izbor) || izbor < 1 || izbor > 2);
                            //--UNOS PACIJENTA--//
                            if (izbor == 1)
                            {

                                string ime, prezime, jmbg, adresa, spol, bracnoStanje, dat1, dat2;
                                DateTime datumRodjenja, prijem;
                                try
                                {
                                    Console.Write("Unesite ime: ");
                                    ime = Console.ReadLine();
                                    Console.Write("Unesite prezime: ");
                                    prezime = Console.ReadLine();
                                    Console.Write("Unesite datum rodjenja: ");
                                    dat1 = Console.ReadLine();
                                    if (!DateTime.TryParse(dat1, out datumRodjenja))
                                        throw new System.ArgumentException("Format datuma nije validan!");
                                    Console.Write("Unesite maticni broj: ");
                                    do
                                    {
                                        jmbg = Console.ReadLine();
                                        if(jmbg.Length!=13)
                                            Console.WriteLine("Jmbg treba da ima duzinu 13! Pokusaj ponovo");
                                    } while (jmbg.Length != 13);
                                    Console.Write("Unesite adresu pacijenta: ");
                                    adresa = Console.ReadLine();
                                    Console.Write("Unesite spol: ");
                                    spol = Console.ReadLine();
                                    Console.Write("Unesite bracno stanje: ");
                                    bracnoStanje = Console.ReadLine();
                                    Console.Write("Unesite datum prijema pacijenta: ");
                                    dat2 = Console.ReadLine();
                                    if (!DateTime.TryParse(dat2, out prijem))
                                        throw new System.ArgumentException("Format datuma nije validan!");

                                    klnika17337.DodajPacijenta(new Pacijent(ime, prezime, jmbg, adresa, spol, bracnoStanje, datumRodjenja, prijem));
                                    

                                    if (klnika17337.ImaLiVecKarton(jmbg))
                                        Console.WriteLine("Pacijent vec ima svoj karton!");
                                    else
                                    {
                                        Console.WriteLine("Pacijent nema svoj karton pa mu se kreira...uz dodatne informacije...\n");
                                        string alerg, ranijeBolesti, zdravStanje;
                                        List<Pregled> ppp = new List<Pregled>();
                                        Console.Write("Da li je pacijent alergican na nesto i na sta: ");
                                        alerg = Console.ReadLine();
                                        Console.Write("Da li je pacijent imao ranije bolesti i koje: ");
                                        ranijeBolesti = Console.ReadLine();
                                        Console.Write("Kakvo je zdravstveno stanje porodice pacijenta: ");
                                        zdravStanje = Console.ReadLine();

                                        Karton kartonn = new Karton(ime, prezime, jmbg, ppp, alerg, ranijeBolesti, zdravStanje);

                                        Console.WriteLine("karton pacijenta je uspjesno kreiran ");
                                        klnika17337.DodajKarton(kartonn);
                                    }


                                }
                                catch (System.ArgumentException ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                            }
                            //--UNOS HITNOG PACIJENTA--//
                            else
                            {
                                string ime, prezime, jmbg, adresa, spol, bracnoStanje, opisPrvePomoci, dat1, dat2;
                                DateTime datumRodjenja, prijem;
                                bool umro;
                                try
                                {
                                    Console.Write("Unesite opis prve pomoci: ");
                                    opisPrvePomoci = Console.ReadLine();
                                    Console.Write("Unesite ime: ");
                                    ime = Console.ReadLine();
                                    Console.Write("Unesite prezime: ");
                                    prezime = Console.ReadLine();
                                    Console.Write("Unesite datum rodjenja: ");
                                    dat1 = Console.ReadLine();
                                    if (!DateTime.TryParse(dat1, out datumRodjenja))
                                        throw new System.ArgumentException("Format datuma nije validan!");
                                    Console.Write("Unesite maticni broj: ");
                                    do
                                    {
                                        jmbg = Console.ReadLine();
                                        if (jmbg.Length != 13)
                                            Console.WriteLine("Jmbg treba da ima duzinu 13! Pokusaj ponovo");
                                    } while (jmbg.Length != 13);
                                    Console.Write("Unesite adresu pacijenta: ");
                                    adresa = Console.ReadLine();
                                    Console.Write("Unesite spol: ");
                                    spol = Console.ReadLine();
                                    Console.Write("Unesite bracno stanje: ");
                                    bracnoStanje = Console.ReadLine();
                                    Console.Write("Unesite datum prijema pacijenta: ");
                                    dat2 = Console.ReadLine();
                                    if (!DateTime.TryParse(dat2, out prijem))
                                        throw new System.ArgumentException("Format datuma nije validan!");
                                    umro = false;

                                    klnika17337.DodajPacijenta(new HitniPacijent(ime, prezime, jmbg, adresa, spol, bracnoStanje, datumRodjenja, prijem, umro, opisPrvePomoci));

                                    if (klnika17337.ImaLiVecKarton(jmbg))
                                        Console.WriteLine("Pacijent vec ima svoj karton!");
                                    else
                                    {
                                        Console.WriteLine("Pacijent nema svoj karton pa mu se kreira...");

                                        string  alerg, ranijebolesti, zdravStanje;
                                        List<Pregled> ppp = new List<Pregled>();
                                        Console.Write("Da li je pacijent alergican na nesto i na sta: ");
                                        alerg = Console.ReadLine();
                                        Console.Write("Da li je pacijent imao ranije bolesti i koje: ");
                                        ranijebolesti = Console.ReadLine();
                                        Console.Write("Kakvo je zdravstveno stanje porodice pacijenta: ");
                                        zdravStanje = Console.ReadLine();
                                        Karton kartonn = new Karton(ime, prezime, jmbg, ppp, alerg, ranijebolesti, zdravStanje);

                                        Console.WriteLine("karton pacijenta je uspjesno kreiran ");
                                        klnika17337.DodajKarton(kartonn);
                                    }

                                    Console.WriteLine("Da li je pacijent umro poslije pokusaja prve pomoci?(da/ne)");
                                    string umroo = Console.ReadLine();
                                    if (umroo == "da")
                                    {
                                        Console.WriteLine("Posto je pacijent umro, brisemo ga iz baze, i njegove preglede i karton");
                                        klnika17337.BrisiPacijenta(klnika17337.RedniBrojPacijenta(jmbg));
                                        klnika17337.ObrisiPregledeUMRLOG(jmbg);
                                        klnika17337.BrisiKarton(klnika17337.RedniBrojKartonaUmrlog(jmbg));
                                    }
                                }
                                catch (System.ArgumentException ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                            }

                        }
                        //--BRISANJE PACIJENTA--//
                        else 
                        {
                            if (klnika17337.DajBrojPacijenata() > 0)
                            {
                                klnika17337.IspisiPacijente();
                                do
                                {
                                    Console.WriteLine("Unesi redni broj pacijenta: ");
                                    pom = Console.ReadLine();
                                    if (!Int32.TryParse(pom, out izbor) || izbor < 1 || izbor > klnika17337.DajBrojPacijenata()) Console.WriteLine("Unos nije validan! Unesite ponovo.");
                                } while (!Int32.TryParse(pom, out izbor) || izbor < 1 || izbor > klnika17337.DajBrojPacijenata());

                                klnika17337.BrisiPacijenta(izbor);
                            }
                            else Console.WriteLine("Nema pacijenta u bazi!");
                        }
                        break;
                    case 2:
                        Console.WriteLine("\nUnesite maticni broj pacijenta za kojeg zelite dobiti raspored pregleda");
                        string mat;
                        do
                        {
                            mat = Console.ReadLine();
                            if (mat.Length != 13)
                                Console.WriteLine("Jmbg treba da ima duzinu 13! Pokusaj ponovo");
                        } while (mat.Length != 13);
                        if (klnika17337.ImaLiPregleda(mat) == true)
                            klnika17337.IspisiPregledeSaJMBG(mat);
                        else Console.WriteLine("\nDati pacijent nema zakazanih pregleda");
                        break;
                    case 3:
                        //--UNOS KARTONA--//
                        {
                            string ime, prez, jmbg, alerg, ranijebolesti, zdravStanje;
                            List<Pregled> ppp = new List<Pregled>();
                            Console.WriteLine("Kreiranje kartona pacijenta: ");
                            Console.Write("Unesite ime pacijenta: ");
                            ime = Console.ReadLine();
                            Console.Write("Unesite prezime pacijenta: ");
                            prez = Console.ReadLine();
                            Console.Write("Unesite jmbg pacijenta: ");
                            do
                            {
                                jmbg = Console.ReadLine();
                                if (jmbg.Length != 13)
                                    Console.WriteLine("Jmbg treba da ima duzinu 13! Pokusaj ponovo");
                            } while (jmbg.Length != 13);
                            Console.Write("Da li je pacijent alergican na nesto i na sta: ");
                            alerg = Console.ReadLine();
                            Console.Write("Da li je pacijent imao ranije bolesti i koje: ");
                            ranijebolesti = Console.ReadLine();
                            Console.Write("Kakvo je zdravstveno stanje porodice pacijenta: ");
                            zdravStanje = Console.ReadLine();
                            Karton kartonn = new Karton(ime, prez, jmbg, ppp, alerg, ranijebolesti, zdravStanje);

                            Console.WriteLine("karton pacijenta je uspjesno kreiran ");
                            klnika17337.DodajKarton(kartonn);
                        }
                        break;
                    case 4:
                        string izz;
                        int pretrazivanje;

                        Console.WriteLine("1. Pretrazi kartone po imenu pacijenta.");
                        Console.WriteLine("2. Pretrazi kartone po prezimenu pacijenta.");
                        Console.WriteLine("3. Pretrazi kartone po jmbg pacijenta.");
                        do
                        {
                            izz = Console.ReadLine();
                            if (!Int32.TryParse(izz, out pretrazivanje) || pretrazivanje < 1 || pretrazivanje > 3)
                                Console.WriteLine("Unos nije validan! Unesite ponovo.");
                        } while (!Int32.TryParse(izz, out pretrazivanje) || pretrazivanje < 1 || pretrazivanje > 3);

                        if (pretrazivanje == 1) //--PRETRAZIVANJE PACIJENATA PO IMENU--//
                        {
                            Console.WriteLine("Unesite ime pacijenta kojem treba naci karton: ");
                            string imePretraga = Console.ReadLine();
                            if (klnika17337.ImaLiVecKartonPoImenu(imePretraga) == true)
                            {
                                Console.WriteLine("Karton pronadjen: ");
                                klnika17337.IspisiKartonPoImenu(imePretraga);
                            }
                            else
                                Console.WriteLine("Nijedan karton nije pronadjen po imenu {0}", imePretraga);
                        }
                        else if (pretrazivanje == 2) //--PRETRAZIVANJE PACIJENATA PO PREZIMENU--//
                        {
                            Console.WriteLine("Unesite prezime pacijenta kojem treba naci karton: ");
                            string prezimePretraga = Console.ReadLine();
                            if (klnika17337.ImaLiVecKartonPoPrezimenu(prezimePretraga) == true)
                            {
                                Console.WriteLine("Karton pronadjen: ");
                                klnika17337.IspisiKartonPoPrezimenu(prezimePretraga);
                            }
                            else
                                Console.WriteLine("Nijedan karton nije pronadjen po prezimenu {0}", prezimePretraga);
                        }
                        else if (pretrazivanje == 3) //--PRETRAZIVANJE PACIJENATA PO JMBG-U--//
                        {
                            string jmbgPretraga;
                            Console.WriteLine("Unesite jmbg pacijenta kojem treba naci karton: ");
                            do
                            {
                                jmbgPretraga = Console.ReadLine();
                                if (jmbgPretraga.Length != 13)
                                    Console.WriteLine("Jmbg treba da ima duzinu 13! Pokusaj ponovo");
                            } while (jmbgPretraga.Length != 13);

                            if (klnika17337.ImaLiVecKarton(jmbgPretraga) == true)
                            {
                                Console.WriteLine("Karton pronadjen: ");
                                klnika17337.IspisiKartonPoJMBG(jmbgPretraga);
                            }
                            else
                                Console.WriteLine("Nijedan karton nije pronadjen po jmbg-u: {0}", jmbgPretraga);
                        }
                        break;
                    case 5:
                        //--REGISTROVANJE NOVOG PREGLEDA--//
                        string imeDoktora, prezimeDoktora, imeOrdinacije, h, imePacijenta, prezimePacijenta, zakljucak, terapija, da, cj, jmbgdok, jmbgpac, sifraord;
                        int sati;
                        double cijena;
                        DateTime datumPregleda;
                        Console.Write("Unesite ime doktora koji je obavio pregled: ");
                        imeDoktora = Console.ReadLine();
                        Console.Write("Unesite prezime doktora: ");
                        prezimeDoktora = Console.ReadLine();
                        Console.Write("Unesite jmbg doktora: ");
                        do
                        {
                            jmbgdok = Console.ReadLine();
                            if (jmbgdok.Length != 13)
                                Console.WriteLine("Jmbg treba da ima duzinu 13! Pokusaj ponovo");
                        } while (jmbgdok.Length != 13);
                        Console.Write("Unesite ime ordinacije gdje je izvrsen pregled: ");
                        imeOrdinacije = Console.ReadLine();
                        Console.Write("Unesite sifru ordinacije: ");
                        sifraord = Console.ReadLine();
                        Console.Write("Unesite ime pacijenta: ");
                        imePacijenta = Console.ReadLine();
                        Console.Write("Unesite preziime: ");
                        prezimePacijenta = Console.ReadLine();
                        Console.Write("Unesite jmbg pacijenta: ");
                        do
                        {
                            jmbgpac = Console.ReadLine();
                            if (jmbgpac.Length != 13)
                                Console.WriteLine("Jmbg treba da ima duzinu 13! Pokusaj ponovo");
                        } while (jmbgpac.Length != 13);
                        Console.Write("Unesite cijenu pregleda: ");
                        cj = Console.ReadLine();
                        cijena = Convert.ToDouble(cj);
                        Console.Write("Unesite zakljucak pregleda(dijagnoza): ");
                        zakljucak = Console.ReadLine();
                        Console.Write("Unesite terapiju za pacijenta: ");
                        terapija = Console.ReadLine();
                        Console.Write("Unesite datum pregleda: ");
                        da = Console.ReadLine();
                        if (!DateTime.TryParse(da, out datumPregleda))
                            throw new System.ArgumentException("Format datuma nije validan!");
                        do
                        { //--DA LI JE MOGUCE REGISTROVAT PREDLED U OVISNOSTI OD RADNOG VREMENA I ZAUZETOSTI--//
                            Console.Write("Unesite termin pregleda u satima(9h do 20h): ");
                            h = Console.ReadLine();
                            if (!Int32.TryParse(h, out sati) || sati < 9 || sati > 20)
                                Console.WriteLine("Termin nije u okviru radnog vremena klinike! Pokusajte ponovo");
                            if (klnika17337.SlobodanTermin(datumPregleda, sati) == false)
                                Console.WriteLine("Termin je vec zauzet, pokusajte ponovo");                             
                        } while (klnika17337.SlobodanTermin(datumPregleda, sati) == false);

                        Console.WriteLine("Termin je slobodan ");
                        klnika17337.DodajPregled(new Pregled(imeDoktora, prezimeDoktora, jmbgpac, imeOrdinacije, sifraord, imePacijenta, prezimePacijenta, jmbgpac, cijena, zakljucak, terapija, datumPregleda, sati));
                        Console.WriteLine("Pregled je uspjesno registrovan!");
                        break;

                    case 6:
                        string analiza;
                        int izborAnaliza;
                        do
                        {
                            Console.Write("\n1. Ispisi uposlenog sa max platom ");
                            Console.Write("\n2. Ispisi najredovnijeg pacijenta ");
                            Console.Write("\n3. Ispisi dosadasnji prihod klinike od pregleda ");
                            Console.Write("\n4. Ispisi racun \n");//receno u zadaci 
                            analiza = Console.ReadLine();
                            Int32.TryParse(analiza, out izborAnaliza);
                        } while (izborAnaliza < 1 || izborAnaliza > 4);
                        //--MAX PLATA UPOSLENOG--//
                        if (izborAnaliza == 1)
                        {
                            Console.WriteLine("\nIme i prezime uposlenog: " + klnika17337.UposleniSaMaxPlatom().Ime + " " + klnika17337.UposleniSaMaxPlatom().Prezime + " radi kao " + klnika17337.UposleniSaMaxPlatom().Pozicija + " a plata mu je: " + klnika17337.UposleniSaMaxPlatom().Plata);
                        }
                        //--NAJREDOVNIJI PACIJENT--//
                        else if (izborAnaliza == 2)
                        {
                            klnika17337.IspisiNajredovnijegPacijenta();
                        }
                        //--PRIHOD OD PREGLEDA--//
                        else if (izborAnaliza == 3)
                        {
                            Console.WriteLine("Od samih pregleda NasaMalaKlinika je dobila {0}KM", klnika17337.SumaSvihPregleda());
                        }
                        //--ISPIS RACUNA--//receno u zadaci
                        else
                        {
                            string jmbgNaplataa;
                            Console.Write("Unesite Jmbg pacijenta kojem zelite ispisati racun: ");
                            do
                            {
                                jmbgNaplataa = Console.ReadLine();
                                if (jmbgNaplataa.Length != 13)
                                    Console.WriteLine("Jmbg treba da ima duzinu 13! Pokusaj ponovo");
                            } while (jmbgNaplataa.Length != 13);
                            if (klnika17337.ImaLiVecKarton(jmbgNaplataa) == false)
                                Console.WriteLine("greska! pacijent sa tim jmbg nije u bazi. ");
                            else
                                Console.WriteLine("Pacijent ima {0}KM za platit", klnika17337.ZaPlatit(jmbgNaplataa));
                        }
                        break;
                    case 7:
                        double cijenaNaplata = 0;
                        string jmbgNaplata;
                        do {
                            Console.Write("Unesite Jmbg pacijenta koji zeli platiti usluge NaseMaleKlinike: ");
                            do
                            {
                                jmbgNaplata = Console.ReadLine();
                                if (jmbgNaplata.Length != 13)
                                    Console.WriteLine("Jmbg treba da ima duzinu 13! Pokusaj ponovo");
                            } while (jmbgNaplata.Length != 13);
                            if (klnika17337.ImaLiVecKarton(jmbgNaplata) == false)
                                Console.WriteLine("Pacijent s tim jmbg nije u bazi! Pokusajte ponovo");
                        } while (klnika17337.ImaLiVecKarton(jmbgNaplata) == false);      
                            int odabir;
                            string sodabir;
                            cijenaNaplata = klnika17337.ZaPlatit(jmbgNaplata);
                            Console.Write("\nNacin placanja: \n1. Gotovina \n2. Na Rate\n");
                            do
                            {
                                sodabir = Console.ReadLine();
                                 Int32.TryParse(sodabir, out odabir);
                                if(odabir<1 || odabir >2)
                                Console.WriteLine("Pogresan unos! pokusajte ponovo");
                            } while ( odabir < 1 || odabir > 2);

                            if (odabir == 1)//placanje gotovinom
                            {
                            if (klnika17337.BrojPregledaPacijenta(jmbgNaplata) > 3)

                            {//--DELEGAT I LAMBDA--// lokalna funkcija  za izracunavanje cijene za platiti gotovinom nakon obracunavnaja -15%, imamo uvid u to kako je izracunato, za razliku od poziva metoda koje se ne vide u program.cs
                                del delegat = x => x- x * 0.85;
                                double ukCijena = delegat(cijenaNaplata);
                                Console.WriteLine("Cijena za gotovinu je {0}KM, pošto ste stalni pacijent, na gotovinu dobijate -15%, tako da je vasa cijena {1}KM", cijenaNaplata, ukCijena);
                            }
                            else
                                Console.WriteLine("Cijena za gotovinu je {0}KM, pošto niste stalni pacijent, ne dobijate popust ", cijenaNaplata);
                            }
                            else  //placanje u ratama
                            {
                                if (klnika17337.BrojPregledaPacijenta(jmbgNaplata) > 3)
                                {
                                    string b;
                                    int brRata;
                                    Console.WriteLine("Ukupna cijena za rate je {0}KM, pošto ste stalni pacijent cijena ostaje ista ", cijenaNaplata);
                                    Console.WriteLine("Na koliko rata zelite platiti racun (max je 6)");
                                    do
                                    {
                                        b = Console.ReadLine();
                                        Int32.TryParse(b, out brRata);
                                        if(brRata<1 ||brRata >6)
                                        Console.WriteLine("pogresan unos! Pokusajte ponovo");
                                    } while ( brRata < 1 || brRata > 6);
                                    Console.WriteLine("Cijena za platiti prvu ratu je {0}KM, a broj preostalih rata je {1}", cijenaNaplata / brRata, brRata - 1);
                                }
                                else
                                {
                                    string b;
                                    int brRata;
                                    Console.WriteLine("Ukupna cijena za rate sa dodatnih +15% je {0}KM, pošto niste stalni pacjent ", cijenaNaplata * 1.15);
                                    Console.WriteLine("Na koliko rata zelite platiti racun (max je 6)");
                                    do {
                                         b = Console.ReadLine();
                                         Int32.TryParse(b, out brRata);
                                         if(brRata<1 || brRata>6)
                                        Console.WriteLine("pogresan unos! pokusajte ponovo");
                                    } while (brRata < 1 || brRata > 6);

                                    Console.WriteLine("Cijena za platiti prvu ratu je {0}KM, a broj preostalih rata je {1}", cijenaNaplata * 1.15 / brRata, brRata - 1);
                                }

                            }                        
                        break;
                    case 8: break;
                }
            } while (izbor != 8);
            Console.ReadLine();
        }
    }
}
