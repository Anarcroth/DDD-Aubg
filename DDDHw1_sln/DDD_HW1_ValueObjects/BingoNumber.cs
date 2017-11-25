using System;
using System.Collections.Generic;
using System.Text;

namespace DDD_HW1_ValueObjects
{
    class BingoNumber
    {
        private readonly int Number;

        public BingoNumber(int n)
        {
            Number = n;
        }

        public int GetNumber { get { return Number; } }

        public override bool Equals(object obj)
        {
            var bnum = obj as BingoNumber;
            if (bnum.Number == this.Number)
            {
                return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Number.GetHashCode();
        }

        public static bool operator !=(BingoNumber bingoNumber1, BingoNumber bingoNumber2)
        {
            if (bingoNumber1.Number != bingoNumber2.Number)
            {
                return true;
            }
            return false;
        }

        public static bool operator ==(BingoNumber bingoNumber1, BingoNumber bingoNumber2)
        {
            if (bingoNumber1.Number == bingoNumber2.Number)
            {
                return true;
            }
            return false;
        }
    }
}
