using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DDD_HW1_ValueObjects
{
    class Player
    {
        public string Name { get; set; }

        public int Hits { get; set; }

        public List<ScoreToken> Score { get; set; }

        public List<BingoNumber> CardNumbers { get; set; }

        public Player()
        {
            Score = new List<ScoreToken>();
            CardNumbers = new List<BingoNumber>(25);
        }

        public int GetPlayerFinalScore()
        {
            return Score.Sum(Score => Score.GetScore);
        }
    }
}
