using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasaMalaKlinika
{
    public class Uposleni: Osoba
    {
        private string sifra;
        private double plata;
        private string pozicija;

        public Uposleni(string pime, string pprezime, string pjmbg, string padresa, string pspol, string pbracnoStanje, DateTime pdatumRodenja, string psifra, double pplata, string ppozicija) : base(pime, pprezime, pjmbg, padresa, pspol, pbracnoStanje, pdatumRodenja)
        {
            Sifra = psifra;
            Plata = pplata;
            Pozicija = ppozicija;
        }

        public string Sifra
        {
            get
            {
                return sifra;
            }

            set
            {
                sifra = value;
            }
        }

        public string Pozicija
        {
            get
            {
                return pozicija;
            }

            set
            {
                pozicija = value;
            }
        }

        public double Plata
        {
            get
            {
                return plata;
            }

            set
            {
                plata = value;
            }
        }
        public override string ToString()
        {
            string s = "";
            s += Ime.ToString() + " " + Prezime.ToString() + "\nJMBG: " + Jmbg.ToString() + "\nAdresa stanovanja:  " + Adresa.ToString() + "\nSpol: " + Spol.ToString() + "\nBracno stanje: " + BracnoStanje.ToString() + "\nDatum rodjenja: " + DatumRodjenja.Date.ToString("d") + "\nSifra: " + Sifra.ToString() + "\nPlata: " + Plata.ToString() + "\nPozicija: " + Pozicija.ToString() + "\n";
            return s;
        }

        
    }
}
