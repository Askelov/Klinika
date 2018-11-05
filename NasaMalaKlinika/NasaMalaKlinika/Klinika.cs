using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasaMalaKlinika
{
    public class Klinika
    {
        private List<Pacijent> pacijenti;
        private List<Karton> kartoni;
        private List<Uposleni> uposlenici;
        private List<Pregled> pregledi;

        public Klinika()
        {
            pacijenti = new List<Pacijent>();
            kartoni = new List<Karton>();
            uposlenici = new List<Uposleni>();
            pregledi = new List<Pregled>();
    }
        //--PACIJENTI--/

        public void DodajPacijenta(Pacijent p)
        {
            pacijenti.Add(p);
        }

        public void BrisiPacijenta(int i)
        {
            pacijenti.RemoveAt(i - 1);
        }

        public void IspisiPacijente()
        {
            int i = 1;
            Console.WriteLine("Pacijenti:");
            foreach (Pacijent p in pacijenti) {
                Console.WriteLine("{0}. " + p.ToString(), i);
                i++;
            }
        }

        public void IspisiNajredovnijegPacijenta()
        {
            int br = 0;
            foreach (Karton k in kartoni)
            {
                if (k.Pregledi.Count > br)
                    br = k.Pregledi.Count;
            }
            string jmbg = "";
            foreach(Karton k in kartoni)
            {
                if (k.Pregledi.Count == br)
                    jmbg = k.JmbgPacijenta;
            }
            foreach(Pacijent p in pacijenti)
            {
                if (p.Jmbg == jmbg)
                {
                    Console.WriteLine("Pacijent ima {0} pregleda " + p.ToString(),br);
                }
            }
        }

        public int RedniBrojPacijenta(string jmbg)
        {
            int i = 0;

            foreach (Pacijent p in pacijenti)
            {
                if (p.Jmbg == jmbg) return i;
                i++;
            }
            return 0;
        }

        public int DajBrojPacijenata()
        {
            return pacijenti.Count;
        }

        public Pacijent DajPacijenta(int i)
        {
            return pacijenti[i - 1];
        }

        //--UPOSLENI--//

        public void DodajUposlenog(Uposleni u)
        {
            uposlenici.Add(u);
        }

        public void BrisiUposlenog(int u)
        {
            uposlenici.RemoveAt(u - 1);
        }

        public void IspisiUposlene()
        {
            int i = 1;
            Console.WriteLine("Uposlenici:");
            foreach(Uposleni u in uposlenici)
            {
                Console.WriteLine("{0}. " + u.ToString(), i);
                i++;
            }
        }

        public Uposleni DajUposlenog(int i)
        {
            return uposlenici[i];
        }

        public double ProsjecnaPlata()
        {
            double prosjek = 0;
            foreach (Uposleni u in uposlenici)
            {
                prosjek += u.Plata;
            }
            prosjek = prosjek / uposlenici.Count;
            return prosjek;
        }

       public Uposleni UposleniSaMaxPlatom()
        {
            double max = uposlenici[0].Plata;
            foreach(Uposleni u in uposlenici)
            {
                if (u.Plata > max) max = u.Plata;
            }
            foreach(Uposleni u in uposlenici)
            {
                if (max == u.Plata) return u;
            }

            return uposlenici[0];
        }

        public int DajBrojUposlenih()
        {
            return uposlenici.Count;
        }

        //--PREGLEDI--//

        public void DodajPregled(Pregled pre)
        {
            pregledi.Add(pre);
        }

        public double ZaPlatit(string jmbg)
        {
            double suma = 0;
            foreach(Pregled p in pregledi)
            {
                suma = suma + p.Cijena;
            }
            return suma;
        }

        public double SumaSvihPregleda()
        {
            double suma = 0;
            foreach (Pregled p in pregledi)
            {
                suma = suma + p.Cijena;
            }
            return suma;
        }

        public bool SlobodanTermin(DateTime datum, int terminSati)
        {
           foreach(Pregled p in pregledi)
            {
                if (p.DanPregleda == datum && p.VrijemeSati == terminSati)
                { Console.WriteLine("Termin je zauzet, ukucajte novi termin. ");
                    return false; }
            }
            return true;
        }
        
        public bool ImaLiPregleda(string jmbg)
        {
            foreach (Pregled p in pregledi)
            {
                if (p.JmbgPacijenta == jmbg)
                    return true;
            }
            return false;
        }

        public void IspisiPregledeSaJMBG(string jmbg)
        { int i = 1;
            foreach(Pregled p in pregledi)
            {
                if (p.JmbgPacijenta == jmbg)
                {
                    Console.WriteLine("{0}. "+p.ToString(),i);
                    i++;
                }
            }
        }
        public void IspisiPreglede()
        {
                int i = 1;
                Console.WriteLine("Pregledi: ");
                foreach (Pregled p in pregledi)
                {
                    Console.WriteLine("{0}. " + p.ToString(), i);
                    i++;
                }
        }
        public void BrisiPregled(int k)
        {
            pregledi.RemoveAt(k - 1);
        }
        public void ObrisiPregledeUMRLOG(string jmbg)
        {
                int i = 0;

                foreach (Pregled k in pregledi)
                {
                if (k.JmbgPacijenta == jmbg)
                    BrisiPregled(i);
                    
                }
                
            
        }
      


        //--KARTONI--//

        public void DodajKarton(Karton k)
        {
            kartoni.Add(k);
        }

        public int BrojPregledaPacijenta(string jmbg) {
            foreach (Karton k in kartoni)
            {
                if (k.JmbgPacijenta == jmbg)
                    return k.Pregledi.Count;
            }
            return 0;

        }

        public void IspisiKartonPoJMBG(string jmbg)
        {
            foreach (Karton k in kartoni)
            {
                if (k.JmbgPacijenta == jmbg)
                    Console.WriteLine(k.ToString());


            }

        }

        public bool ImaLiVecKartonPoImenu(string ime)
        {
            foreach (Karton k in kartoni)
            {
                if (k.Ime == ime)
                    return true;
            }
            return false;
        }
        public void IspisiKartonPoImenu(string ime)
        {
            foreach (Karton k in kartoni)
            {
                if (k.Ime == ime)
                    Console.WriteLine(k.ToString());


            }

        }

        public bool ImaLiVecKartonPoPrezimenu(string prezime)
        {
            foreach (Karton k in kartoni)
            {
                if (k.Prezime == prezime)
                    return true;
            }
            return false;
        }
        public void IspisiKartonPoPrezimenu(string prezime)
        {
            foreach (Karton k in kartoni)
            {
                if (k.Prezime == prezime)
                    Console.WriteLine(k.ToString());


            }

        }


        public bool ImaLiVecKarton(string jmbg)
        {
            foreach (Karton k in kartoni)
            {
                if (k.JmbgPacijenta == jmbg)
                    return true;
            }
            return false;
        }

        public void BrisiKarton(int k)
        {
            kartoni.RemoveAt(k - 1);
        }

        public int RedniBrojKartonaUmrlog(string jmbg)
        {
            int i = 0;
            foreach (Karton k in kartoni)
            {
                if (k.JmbgPacijenta == jmbg)
                    return i;
                i++;
            }
            return 0;
        }
        public void IspisiKartone()
        {
            int i = 1;
            Console.WriteLine("Kartoni:");
            foreach (Karton k in kartoni)
            {
                Console.WriteLine("{0}. " + k.ToString(), i);
                i++;
            }
        }

        public int DajBrojKartona()
        {
            return kartoni.Count;
        }

        public Karton DajKarton(int i)
        {
            return kartoni[i - 1];
        }
    }
}
