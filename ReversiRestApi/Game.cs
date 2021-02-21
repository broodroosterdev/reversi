using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Innofactor.EfCoreJsonValueConverter;

namespace ReversiRestApi
{
    public class Game : IGame
    {
        [NotMapped]
        private static readonly List<(int, int)> Sides = new List<(int, int)>()
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
        [Key]
        public string Token { get; set; } 
        
        public string Description { get; set; }
        public string Player1Token { get; set; }
        public string? Player2Token { get; set; }
        
        [JsonField]
        public Color[,] Board { get; set; }
        public Color Turn { get; set; }
        
        [NotMapped]
        public Color NotTurn => Turn == Color.White ? Color.Black : Color.White;
        
        [JsonField]
        public Result? Result { get; set; }
        
        public Game()
        {
            Board = new Color[8, 8];
            //Bij reversi begint zwart als eerste
            Turn = Color.Black;
            FillWithNone();
            PlaceStartStones();
            //PrintBord();
        }

        private void PlaceStartStones()
        {
            Board[3, 3] = Color.White;
            Board[3, 4] = Color.Black;
            Board[4, 3] = Color.Black;
            Board[4, 4] = Color.White;
        }

        private void FillWithNone()
        {
            for (int rij = 0; rij < 8; rij++)
            {
                for (int kolom = 0; kolom < 8; kolom++)
                {
                    Board[rij, kolom] = Color.None;
                }
            }
        }

        private void PrintBoard()
        {
            for (int rij = 0; rij < 8; rij++)
            {
                for (int kolom = 0; kolom < 8; kolom++)
                {
                    switch (Board[rij,kolom])
                    {
                        case Color.None: 
                            Console.Write("O ");
                            break;
                        case Color.White: 
                            Console.Write("W ");
                            break;
                        case Color.Black: 
                            Console.Write("Z ");
                            break;
                    }
                }
                Console.WriteLine();
            }
        }

        public bool Pass()
        {
            Turn = NotTurn;
            return true;
        }

        public bool Ended()
        {
            var plekkenOver = EmptySpacesLeft();
            if (plekkenOver.Count == 0) return true;
            return false;
        }

        public Color DominantColor()
        {
            int countWit = 0;
            int countZwart = 0;
            for (var rij = 0; rij < 8; rij++)
            {
                for (var kolom = 0; kolom < 8; kolom++)
                {
                    switch (Board[rij,kolom])
                    {
                        case Color.White: { countWit++; break; }
                        case Color.Black: { countZwart++; break; }
                    }
                }
            }
            //Als er nog geen steen gelegd is
            if (countWit == 2 && countZwart == 2) return Color.None;
            //Controleer of het niet gelijk staat
            if (countWit == countZwart) return Color.None;
            //Anders, kijk welke steen het meeste voorkomt
            return countWit > countZwart ? Color.White : Color.Black;
        }

        public List<(int, int)> EmptySpacesLeft()
        {
            List<(int, int)> plekken = new List<(int, int)>(); 
            for (var rij = 0; rij < 8; rij++)
            {
                for (var kolom = 0; kolom < 8; kolom++)
                {
                    if (Board[rij, kolom] == Color.None && MovePossible(rij, kolom))
                        plekken.Add((rij, kolom));
                }
            }
            return plekken;
        }

        public bool MovePossible(int rijZet, int kolomZet)
        {
            if (rijZet < 0 || rijZet > 7) return false;
            if (kolomZet < 0 || kolomZet > 7) return false;
            if (!StonesWillBeTurned(rijZet, kolomZet)) return false;

            return Board[rijZet, kolomZet] == Color.None;
        }

        private bool StonesWillBeTurned(int rijZet, int kolomZet)
        {
            //Voor elke steen, controleer of er een steen van eigen kleur aan de andere kant zit
            int omgedraaideStenen = 0;
            foreach (var (kantX, kantY) in Sides)
            {
                var mogelijkeRij = rijZet + kantY;
                var mogelijkeKolom = kolomZet + kantX;
                //Controleer of er stenen van een andere kleur om de positie zitten
                if(!onBoard(mogelijkeRij, mogelijkeKolom) || Board[mogelijkeRij, mogelijkeKolom] != NotTurn) continue;
                //Als dat het geval is, tel de stenen
                omgedraaideStenen += CalculateTurningStones(mogelijkeRij, mogelijkeKolom, kantY, kantX).Count;
            }
            //Als er minimaal 1 steen wordt omgedraaid
            return omgedraaideStenen > 0;
        }

        private void TurnStones(int rijZet, int kolomZet)
        {
            //Draai eerst de steen zelf om
            Board[rijZet, kolomZet] = Turn;
            //Ga daarna alle kanten langs
            foreach (var (kantX, kantY) in Sides)
            {
                var mogelijkeRij = rijZet + kantY;
                var mogelijkeKolom = kolomZet + kantX;
                //Controleer of er stenen van een andere kleur om de positie zitten
                if(!onBoard(mogelijkeRij, mogelijkeKolom) || Board[mogelijkeRij, mogelijkeKolom] != NotTurn) continue;
                //Als dat het geval is, zoek al die stenen op 
                var stenen = CalculateTurningStones(mogelijkeRij, mogelijkeKolom, kantY, kantX);
                foreach (var (steenRij, steenKolom) in stenen)
                {
                    //En draai ze om naar de kleur van de speler
                    Board[steenRij, steenKolom] = Turn;
                }
            }
        }

        private List<(int, int)> CalculateTurningStones(int beginRij, int beginKolom, int rijRichting, int kolomRichting)
        {
            var x = beginKolom;
            var y = beginRij;
            List<(int, int)> omdraaiendeStenen = new List<(int, int)>();

            while (Board[y, x] == NotTurn)
            {
                x += kolomRichting;
                y += rijRichting;
                if (!onBoard(y, x)) break;
            }
            
            if (!onBoard(y, x)) return omdraaiendeStenen;
            if (Board[y, x] == Turn)
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

        private bool onBoard(int rij, int kolom)
        {
            return rij >= 0 && rij <= 7 && kolom >= 0 && kolom <= 7;
        }

        public bool DoMove(int rijZet, int kolomZet)
        {
            if (!MovePossible(rijZet, kolomZet)) return false;
            TurnStones(rijZet, kolomZet);
            Turn = NotTurn;
            if (!MovePossible(rijZet, kolomZet))
                ChooseWinner();
            return true;
        }

        public bool Resign()
        {
            var aanDeBeurt = Turn == Color.White ? Player1Token : Player2Token;
            Result = new Result(aanDeBeurt, ResultType.Resigned);
            return true;
        }

        private void ChooseWinner()
        {
            var dominantColor = DominantColor();
            if (dominantColor == Color.None)
            {
                Result = new Result("", ResultType.Draw);
            }
            else
            {
                var winner = DominantColor() == Color.White ? Player1Token : Player2Token;
                Result = new Result(winner, ResultType.Won);
            }
        }
    }
}