using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasaMalaKlinika
{
    public abstract class Osoba //apstraktna klasa
    {
        private string ime;
        private string prezime;
        private string jmbg;
        private string adresa;
        private string spol;
        private string bracnoStanje;
        private DateTime datumRodjenja;

        public Osoba(string pime, string pprezime, string pjmbg, string padresa, string pspol, string pbracnoStanje, DateTime pdatumRodenja )
        {
            Ime = pime;
            Prezime = pprezime;
            Jmbg = pjmbg;
            Adresa = padresa;
            Spol = pspol;
            BracnoStanje = pbracnoStanje;
            DatumRodjenja = pdatumRodenja;
        }

        public string Ime
        {
            get
            {
                return ime;
            }
            set
            {
                ime = value;
            }
        }

        public string Prezime
        {
            get
            {
                return prezime;
            }
            set
            {
                prezime = value;
            }
        }

        public string Jmbg
        {
            get
            {
                return jmbg;
            }
            set
            {
                jmbg = value;
            }
        }

        public DateTime DatumRodjenja
        {
            get
            {
                return datumRodjenja;
            }
            set
            {
                datumRodjenja = value;
            }
        }

        public string Adresa
        {
            get
            {
                return adresa;
            }
            set
            {
                adresa = value;
            }
        }

        public string Spol
        {
            get
            {
                return spol;
            }
            set
            {
                spol = value;
            }
        }

        public string BracnoStanje
        {
            get
            {
                return bracnoStanje;
            }
            set
            {
                bracnoStanje = value;
            }
        }

        public override abstract string ToString();
       
    }
}
