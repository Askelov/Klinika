using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasaMalaKlinika
{
    public partial class HitniPacijent : Pacijent//jedna mora biti partial
    {
        private bool umro;
        private string opisPrvePomoci;

        public HitniPacijent(string pime, string pprezime, string pjmbg, string padresa, string pspol, string pbracnoStanje, DateTime pdatumRodenja, DateTime pprijem, bool pumro, string popisPrvePomoci) : base(pime, pprezime, pjmbg, padresa, pspol, pbracnoStanje, pdatumRodenja, pprijem)
        {
            Umro = pumro;
            OpisPrvePomoci = popisPrvePomoci;
        }

        public HitniPacijent(Pacijent p, bool pumro, string popisPrvePomoci) : base(p)
        {
            Umro = pumro;
            OpisPrvePomoci = popisPrvePomoci;
        }
    }

    public partial class HitniPacijent : Pacijent
    {
        public bool Umro
        {
            get
            {
                return umro;
            }

            set
            {
                umro = value;
            }
        }

        public string OpisPrvePomoci
        {
            get
            {
                return opisPrvePomoci;
            }

            set
            {
                opisPrvePomoci = value;
            }
        }

        public override string ToString()
        {
            string s = "";
            s += Ime.ToString() + " " + Prezime.ToString() + "\nJMBG: " + Jmbg.ToString() + "\nAdresa stanovanja:  " + Adresa.ToString() + "\nSpol: " + Spol.ToString() + "\nBracno stanje: " + BracnoStanje.ToString() + "\nDatum rodjenja: " + DatumRodjenja.Date.ToString("d") + "\nDatum prijema: " + Prijem.Date.ToString("d") + "\nZiv: "+Umro.ToString()+ "\nOpis prve pomoci: "+ OpisPrvePomoci.ToString()+"\n";
            return s;
        }

        
    }
}
