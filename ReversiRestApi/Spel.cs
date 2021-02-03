using System;
using System.Collections.Generic;

namespace ReversiRestApi
{
    public class Spel : ISpel
    {
        private static readonly List<(int, int)> Kanten = new List<(int, int)>()
        {
            (0, 1),
            (1, 1),
            (1, 0),
            (1, -1),
            (0, -1),
            (-1, -1),
            (-1, 0),
            (-1, 1)
        };

        public int ID { get; set; }
        public string Omschrijving { get; set; }
        public string Token { get; set; }
        public string Speler1Token { get; set; }
        public string Speler2Token { get; set; }
        public Kleur[,] Bord { get; set; }
        public Kleur AandeBeurt { get; set; }
        public Kleur NietAanDeBeurt => AandeBeurt == Kleur.Wit ? Kleur.Zwart : Kleur.Wit;
        public Spel()
        {
            Bord = new Kleur[8, 8];
            //Bij reversi begint zwart als eerste
            AandeBeurt = Kleur.Zwart;
            VulMetGeen();
            ZetBeginStenen();
            PrintBord();
        }

        private void ZetBeginStenen()
        {
            Bord[3, 3] = Kleur.Wit;
            Bord[3, 4] = Kleur.Zwart;
            Bord[4, 3] = Kleur.Zwart;
            Bord[4, 4] = Kleur.Wit;
        }

        private void VulMetGeen()
        {
            for (int rij = 0; rij < 8; rij++)
            {
                for (int kolom = 0; kolom < 8; kolom++)
                {
                    Bord[rij, kolom] = Kleur.Geen;
                }
            }
        }

        private void PrintBord()
        {
            for (int rij = 0; rij < 8; rij++)
            {
                for (int kolom = 0; kolom < 8; kolom++)
                {
                    switch (Bord[rij,kolom])
                    {
                        case Kleur.Geen: 
                            Console.Write("O ");
                            break;
                        case Kleur.Wit: 
                            Console.Write("W ");
                            break;
                        case Kleur.Zwart: 
                            Console.Write("Z ");
                            break;
                    }
                }
                Console.WriteLine();
            }
        }

        public bool Pas()
        {
            AandeBeurt = NietAanDeBeurt;
            return true;
        }

        public bool Afgelopen()
        {
            var plekkenOver = LegePlekkenOver();
            if (plekkenOver.Count == 0) return true;
            return false;
        }

        public Kleur OverwegendeKleur()
        {
            int countWit = 0;
            int countZwart = 0;
            for (var rij = 0; rij < 8; rij++)
            {
                for (var kolom = 0; kolom < 8; kolom++)
                {
                    switch (Bord[rij,kolom])
                    {
                        case Kleur.Wit: { countWit++; break; }
                        case Kleur.Zwart: { countZwart++; break; }
                    }
                }
            }
            //Als er nog geen steen gelegd is
            if (countWit == 2 && countZwart == 2) return Kleur.Geen;
            //Anders, kijk welke steen het meeste voorkomt
            return countWit > countZwart ? Kleur.Wit : Kleur.Zwart;
        }

        public List<(int, int)> LegePlekkenOver()
        {
            List<(int, int)> plekken = new List<(int, int)>(); 
            for (var rij = 0; rij < 8; rij++)
            {
                for (var kolom = 0; kolom < 8; kolom++)
                {
                    if (Bord[rij, kolom] == Kleur.Geen && ZetMogelijk(rij, kolom))
                        plekken.Add((rij, kolom));
                }
            }
            return plekken;
        }

        public bool ZetMogelijk(int rijZet, int kolomZet)
        {
            if (rijZet < 0 || rijZet > 7) return false;
            if (kolomZet < 0 || kolomZet > 7) return false;
            if (!stenenWordenOmgedraaid(rijZet, kolomZet)) return false;

            return Bord[rijZet, kolomZet] == Kleur.Geen;
        }

        private bool stenenWordenOmgedraaid(int rijZet, int kolomZet)
        {
            //Voor elke steen, controleer of er een steen van eigen kleur aan de andere kant zit
            int omgedraaideStenen = 0;
            foreach (var (kantX, kantY) in Kanten)
            {
                var mogelijkeRij = rijZet + kantY;
                var mogelijkeKolom = kolomZet + kantX;
                //Controleer of er stenen van een andere kleur om de positie zitten
                if(!opBord(mogelijkeRij, mogelijkeKolom) || Bord[mogelijkeRij, mogelijkeKolom] != NietAanDeBeurt) continue;
                //Als dat het geval is, tel de stenen
                omgedraaideStenen += berekenOmdraaiendeStenen(mogelijkeRij, mogelijkeKolom, kantY, kantX).Count;
            }
            //Als er minimaal 1 steen wordt omgedraaid
            return omgedraaideStenen > 0;
        }

        private void draaiStenenOm(int rijZet, int kolomZet)
        {
            //Draai eerst de steen zelf om
            Bord[rijZet, kolomZet] = AandeBeurt;
            //Ga daarna alle kanten langs
            foreach (var (kantX, kantY) in Kanten)
            {
                var mogelijkeRij = rijZet + kantY;
                var mogelijkeKolom = kolomZet + kantX;
                //Controleer of er stenen van een andere kleur om de positie zitten
                if(!opBord(mogelijkeRij, mogelijkeKolom) || Bord[mogelijkeRij, mogelijkeKolom] != NietAanDeBeurt) continue;
                //Als dat het geval is, zoek al die stenen op 
                var stenen = berekenOmdraaiendeStenen(mogelijkeRij, mogelijkeKolom, kantY, kantX);
                foreach (var (steenRij, steenKolom) in stenen)
                {
                    //En draai ze om naar de kleur van de speler
                    Bord[steenRij, steenKolom] = AandeBeurt;
                }
            }
        }

        private List<(int, int)> berekenOmdraaiendeStenen(int beginRij, int beginKolom, int rijRichting, int kolomRichting)
        {
            var x = beginKolom;
            var y = beginRij;
            List<(int, int)> omdraaiendeStenen = new List<(int, int)>();

            while (Bord[y, x] == NietAanDeBeurt)
            {
                x += kolomRichting;
                y += rijRichting;
                if (!opBord(y, x)) break;
            }
            
            if (!opBord(y, x)) return omdraaiendeStenen;
            if (Bord[y, x] == AandeBeurt)
            {
                while (true)
                {
                    x -= kolomRichting;
                    y -= rijRichting;
                    omdraaiendeStenen.Add((y,x));
                    if (x == beginKolom && y == beginRij) break;
                }
            }

            return omdraaiendeStenen;
        }

        private bool opBord(int rij, int kolom)
        {
            return rij >= 0 && rij <= 7 && kolom >= 0 && kolom <= 7;
        }

        public bool DoeZet(int rijZet, int kolomZet)
        {
            if (!ZetMogelijk(rijZet, kolomZet)) return false;
            draaiStenenOm(rijZet, kolomZet);
            AandeBeurt = NietAanDeBeurt; 
            return true;
        }
    }
}