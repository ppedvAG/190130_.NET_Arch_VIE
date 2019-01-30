using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder_Demo
{
    public enum Oberflächenart { Unbehandelt,Gewachst,Lackiert};
    class Schrank
    {
        private Schrank(){}

        public int AnzahlTüren { get; set; }
        public Oberflächenart Oberfläche { get; set; }
        public string Farbe { get; set; }
        public bool Metallschienen { get; set; }
        public int AnzahlBöden { get; set; }
        public bool Kleiderstange { get; set; }

        public static SchrankBauer BaueSchrank() => new SchrankBauer();
        public class SchrankBauer
        {
            public SchrankBauer()
            {
                schrank = new Schrank();
            }
            private Schrank schrank;
            public SchrankBauer MitTüren(int anzahl)
            {
                schrank.AnzahlTüren = anzahl;
                return this;
            }
            public SchrankBauer MitOberfläche(Oberflächenart oberflächenart)
            {
                schrank.Oberfläche = oberflächenart;
                return this;
            }
            public SchrankBauer InFarbe(string farbe)
            {
                schrank.Farbe = farbe;
                return this;
            }
            public SchrankBauer HatMetallSchienen(bool schienenVorhanden)
            {
                schrank.Metallschienen = schienenVorhanden;
                return this;
            }
            public SchrankBauer MitBöden(int anzahlBöden)
            {
                schrank.AnzahlBöden = anzahlBöden;
                return this;
            }
            public SchrankBauer HatKleiderstange(bool kleiderstangeVorhanden)
            {
                schrank.Kleiderstange = kleiderstangeVorhanden;
                return this;
            }

            public Schrank KonstruiereSchrank()
            {
                if (schrank.AnzahlTüren < 2 || schrank.AnzahlTüren > 7)
                    throw new ArgumentException("Der Schrank darf nur zwischen 2 und 7 Türen haben");

                if (!string.IsNullOrEmpty(schrank.Farbe) && schrank.Oberfläche != Oberflächenart.Lackiert)
                    throw new ArgumentException("Nur ein lackierter Schrank darf eine Farbe haben");

                if (schrank.AnzahlBöden < 0 || schrank.AnzahlBöden > 6)
                    throw new ArgumentException("Der Schrank darf nur zwischen 0 und 6 Böden haben");

                return schrank;
            }
        }
    }
}
