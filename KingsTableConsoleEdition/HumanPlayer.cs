using System;
using KingsTableConsoleEdition.Interfaces;
namespace KingsTableConsoleEdition
{
    public class HumanPlayer : IPlayer
    {

        string name;
        int wins, draws, losses;

        public HumanPlayer()
        {
            wins = 0;
            draws = 0;
            losses = 0;
        }

        public void SetName(string playerName)
        {
            name = playerName;    
        }

        public string GetName()
        {
            return name;
        }

        public void AddWin()
        {
            wins++;
        }

        public int GetWins()
        {
            return wins;
        }

        public void AddDraw()
        {
            draws++;
        }

        public int GetDraws()
        {
            return draws;
        }

        public void AddLoss()
        {
            losses++;
        }

        public int GetLosses()
        {
            return losses;
        }
    }
}
