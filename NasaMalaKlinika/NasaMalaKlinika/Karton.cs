using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasaMalaKlinika
{
    public class Karton:interfaceIspis
    {
        private string ime;
        private string prezime;
        private string jmbgPacijenta;
        private List<Pregled> pregledi;
        private string alergija;
        private string ranijeBolesti;
        private string zdravstvenoStanjePorodice;
       

        
        public Karton(string pime, string pprezime, string pjmbgPacijenta,List<Pregled> ppregledi ,string palergija, string pranijeBolesti, string pzdravstvenoStanjePacijenta )
        {
            Ime = pime;
            Prezime = pprezime;
            JmbgPacijenta = pjmbgPacijenta;
            Pregledi = ppregledi;
            Alergija = palergija;
            RanijeBolesti = pranijeBolesti;
            ZdravstvenoStanjePorodice = pzdravstvenoStanjePacijenta;
        }

        
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string JmbgPacijenta { get; set; }
        public List<Pregled> Pregledi { get; set; }
        public string Alergija { get; set; }
        public string RanijeBolesti { get; set; }
        public string ZdravstvenoStanjePorodice { get; set; }


        public string ToString()
        {
            string s = "";
            s += "jmbg pacijenta: " + JmbgPacijenta.ToString() + "\n ime i prezime pacijenta: " + Ime.ToString()  + Prezime.ToString() + "\nAlergija: "+Alergija.ToString() + "\nRanije Bolesti: "+RanijeBolesti.ToString()+"\nZdravstveno stanje porodice: " +ZdravstvenoStanjePorodice.ToString()+"\n";
            return s;
        }

        //metode interfejsa
          string interfaceIspis.IspisImeiPrezimePacijenta()
        {
             string s = "\nIme i Prezime Pacijenta: ";
             s += ime + " " + prezime;
             return s;
        }
        string interfaceIspis.IspisJMBG()
        {
            string s = "\nJMBG pacijenta: ";
            s += jmbgPacijenta;
            return s;
        }
    }
}
