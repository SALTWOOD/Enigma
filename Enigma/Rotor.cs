using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma
{
    public class Rotor
    {
        private string wiring;
        private int notch;
        private int position;

        public Rotor(string wiring, int notch)
        {
            this.wiring = wiring;
            this.notch = notch;
            this.position = 0;
        }

        public char Encode(char c, bool reverse = false)
        {
            int offset = (c - 'A' + position) % 26;
            if (reverse)
            {
                return (char)(((wiring.IndexOf((char)('A' + offset)) - position + 26) % 26) + 'A');
            }
            else
            {
                return (char)((((wiring[offset] - 'A') - position + 26) % 26) + 'A');
            }
        }

        public bool Step()
        {
            position = (position + 1) % 26;
            return position == notch;
        }
    }

}
