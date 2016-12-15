using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BullsAndCows
{
    public class Mustery
    {
        public string number;
        public int moves;
        public string Number
        {
            set
            {
                number = value;
            }
            get
            {
                return number;
            }
        }
        public int Moves
        {
            set
            {
                moves = value;
            }
            get
            {
                return moves;
            }
        } 
    }
}
