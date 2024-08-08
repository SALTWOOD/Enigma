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
        private int position;

        public Rotor()
        {
            this.wiring = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            this.position = 0;
        }

        public Rotor(string wiring, int position)
        {
            this.wiring = wiring;
            this.position = position;
        }

        public void Rotate()
        {
            position = (position + 1) % 26;
        }

        public char Forward(char input)
        {
            int index = (input - 'A' + position) % 26;
            return wiring[index];
        }

        public char Reverse(char input)
        {
            int index = wiring.IndexOf(input);
            index = (index - position + 26) % 26;
            return (char)('A' + index);
        }
    }
}
