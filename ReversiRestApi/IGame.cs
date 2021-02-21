using System;

namespace ReversiRestApi
{
    public interface IGame
    {
        //het unieke token van het spel
        string Token { get; set; }
        string Description { get; set; }
        string? Player1Token { get; set; }
        string? Player2Token { get; set; }
        Color[,] Board { get; set; }   
        Color Turn { get; set; }  
        bool Pass(); 
        bool Ended();
        bool Resign();
        
        //welke kleur het meest voorkomend op het speelbord
        Color DominantColor();
        
        //controle of op een bepaalde positie een zet mogelijk is
        bool MovePossible(int rijZet, int kolomZet);
        bool DoMove(int rijZet, int kolomZet);
    }
}