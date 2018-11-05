using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasaMalaKlinika
{
    public class Pacijent: Osoba
    {
        private DateTime prijem;

        public Pacijent(string pime, string pprezime, string pjmbg, string padresa, string pspol, string pbracnoStanje, DateTime pdatumRodenja, DateTime pprijem) : base(pime, pprezime, pjmbg, padresa, pspol, pbracnoStanje, pdatumRodenja)
        {
            prijem = pprijem;
        }

        public Pacijent(Pacijent p) : base(p.Ime, p.Prezime, p.Jmbg, p.Adresa, p.Spol, p.BracnoStanje, p.DatumRodjenja)
        {
           Prijem = p.Prijem;
        }

        public DateTime Prijem
        {
            get
            {
                return prijem;
            }

            set
            {
                prijem = value;
            }
        }

        public override string ToString()
        {
            string s = "";
            s += "\n"+Ime.ToString() + " " + Prezime.ToString() + "\nJMBG: " + Jmbg.ToString() + "\nAdresa stanovanja:  " + Adresa.ToString()+ "\nSpol: " + Spol.ToString()+ "\nBracno stanje: " + BracnoStanje.ToString() + "\nDatum rodjenja: " + DatumRodjenja.Date.ToString("d")+"\n";
            return s;
        }

       
    }
}
