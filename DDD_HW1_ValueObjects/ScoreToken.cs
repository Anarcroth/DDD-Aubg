using System;
using System.Collections.Generic;
using System.Text;

namespace DDD_HW1_ValueObjects
{
    class ScoreToken
    {
        private readonly int Score;

        public ScoreToken(int s)
        {
            Score = s;
        }

        public int GetScore { get { return Score; } }

        public override bool Equals(object obj)
        {
            var snum = obj as ScoreToken;
            if (snum.Score == this.Score)
            {
                return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Score.GetHashCode();
        }

        public static bool operator !=(ScoreToken scoreToke1, ScoreToken scoreToken2)
        {
            if (scoreToke1.Score != scoreToken2.Score)
            {
                return true;
            }
            return false;
        }

        public static bool operator ==(ScoreToken scoreToken1, ScoreToken scoreToken2)
        {
            if (scoreToken1.Score == scoreToken2.Score)
            {
                return true;
            }
            return false;
        }
    }
}
