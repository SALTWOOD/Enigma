using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma
{
    public class Enigma
    {
        private List<Rotor> rotors;
        private string reflector;

        public Enigma(List<Rotor> rotors, string reflector)
        {
            this.rotors = rotors;
            this.reflector = reflector;
        }

        public string Encode(string text)
        {
            char[] result = new char[text.Length];
            for (int i = 0; i < text.Length; i++)
            {
                char c = text[i];
                foreach (var rotor in rotors)
                {
                    c = rotor.Encode(c);
                }
                c = reflector[c - 'A'];
                for (int j = rotors.Count - 1; j >= 0; j--)
                {
                    c = rotors[j].Encode(c, reverse: true);
                }
                result[i] = c;
                if (rotors[0].Step())
                {
                    if (rotors[1].Step())
                    {
                        rotors[2].Step();
                    }
                }
            }
            return new string(result);
        }
    }
}
