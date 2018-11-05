using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasaMalaKlinika
{
    public class Pregled:interfaceIspis //implementacija interfejsa u ovoj klasi 
    {
        private string imeDoktora;
        private string prezimeDoktora;
        private string jmbgdoktora;
        
        private string imeOrdinacije;
        private string sifraOrdinacije;

        private string imePacijenta;
        private string prezimePacijenta;
        private string jmbgPacijenta;

        private double cijena;
        static int trajanje=1;
        private string zakljucakDoktora;
        private string terapija;
        private DateTime danPregleda;
        private int vrijemeSati;

        
        public Pregled(string idoktora, string pdoktora, string pjmbgDoktora, string iordinacije, string psifraOrdinacije, string ipacijenta, string ppacijenta, string pjmbgPacijenta,double c, string zakljucak, string terap, DateTime datum, int pvrijemeSati)
        {
            ImeDoktora = idoktora;
            PrezimeDoktora = pdoktora;
            JmbgDoktora = pjmbgDoktora;
            ImeOrdinacije = iordinacije;
            sifraOrdinacije = psifraOrdinacije;
            ImePacijenta = ipacijenta;
            PrezimePacijenta = ppacijenta;
            JmbgPacijenta = pjmbgPacijenta;
            Cijena = c;
            ZakljucakDoktora = zakljucak;
            Terapija = terap;
            DanPregleda = datum;
            VrijemeSati = pvrijemeSati;

        }
        public Pregled(Pregled p)
        {
            ImeDoktora = p.ImeDoktora;
            PrezimeDoktora = p.PrezimeDoktora;
            JmbgDoktora = p.JmbgDoktora;
            ImeOrdinacije = p.ImeOrdinacije;
            sifraOrdinacije = p.sifraOrdinacije;
            ImePacijenta = p.ImePacijenta;
            PrezimePacijenta = p.PrezimePacijenta;
            JmbgPacijenta = p.JmbgPacijenta;
            Cijena = p.Cijena;
            ZakljucakDoktora = p.ZakljucakDoktora;
            Terapija = p.Terapija;
            DanPregleda = p.DanPregleda;
            VrijemeSati = p.VrijemeSati;
            

        }

        public string ImeDoktora { get; set; }
        public string PrezimeDoktora { get; set; }
        public string JmbgDoktora { get; set; }
        public string ImeOrdinacije { get; set; }
        public string SifraOrdinacije { get; set; }
        public string ImePacijenta { get; set; }
        public string PrezimePacijenta { get; set; }
        public string JmbgPacijenta { get; set; }
        public double Cijena { get; set; }
        public string ZakljucakDoktora { get; set; }
        public string Terapija { get; set; }
        public DateTime DanPregleda { get; set; }
        public int VrijemeSati { get; set; }

        public string ToString()
        {
            string s = "";
            s += "Ime i prezime doktora: " + ImeDoktora.ToString() +" " + PrezimeDoktora.ToString()+ "\nIme Ordinacije: "+ImeOrdinacije.ToString()+"\nIme i prezime pacijenta: "+ImePacijenta.ToString()+" "+PrezimePacijenta.ToString()+ "\nCijena pregleda: "+Cijena.ToString()+"\nZakljucak: "+ZakljucakDoktora.ToString()+"\nTerapaija: "+Terapija.ToString()+ "\nDatum pregleda: " + DanPregleda.Date.ToString("d")+"\nTermin (sati): "+VrijemeSati.ToString()+"\n";
            return s;
        }

       //metode interfejsa
        string interfaceIspis.IspisImeiPrezimePacijenta()
        {
            string s = "\nIme i prezime pacijenta: ";
            s += imePacijenta + " " + prezimePacijenta;
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
