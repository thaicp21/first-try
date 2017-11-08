using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib
{
    public class Game
    {
        public string Team1 { get; set; }
        public string Team2 { get; set; }
        public int Team1Score { get; set; }
        public int Team2Score { get; set; }

        public Game() { }

        public Game (string team1, string team2, int team1score, int team2score)
        {
            this.Team1 = team1;
            this.Team2 = team2;
            this.Team1Score = team1score;
            this.Team2Score = team2score;
        }

        public override string ToString()
        {
            return string.Format("{0} ({1}) - {2} ({3})", Team1, Team1Score, Team2, Team2Score);
        }
    }
}
