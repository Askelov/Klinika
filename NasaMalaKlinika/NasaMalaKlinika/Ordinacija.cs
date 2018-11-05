using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasaMalaKlinika
{
    public class Ordinacija
    {
        private string sifraOrdinacije;
        private string imeOrdinacije;
        private bool aparatRadi;
        private string jmbgDoktora;

        public Ordinacija(string psifra, string pime, bool pradi, string doc)
        {
            SifraOrdinacije = psifra;
            ImeOrdinacije = pime;
            AparatRadi = pradi;
            JmbgDoktora = doc;
        }

        public string SifraOrdinacije { get; set; }
        public string ImeOrdinacije { get; set; }
        public bool AparatRadi { get; set; }
        public string JmbgDoktora { get; set; }

        public string ToString()
        {
            string s = "";
            s += "Sifra ordinacije: "+SifraOrdinacije.ToString() + "\nIme ordinaicje: " + ImeOrdinacije.ToString() + "\nDoktor u Ordinaciji " + JmbgDoktora.ToString();
            return s;
        }

    }
}
