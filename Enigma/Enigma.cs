using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Enigma
{
    public class Enigma
    {
        private List<Rotor> rotors;
        private Reflector reflector;
        private Plugboard plugboard;

        public Enigma(FileStream stream)
        {
            StreamReader sr = new StreamReader(stream);
            var config = JsonConvert.DeserializeObject<EnigmaConfig>(sr.ReadToEnd());
            if (config == null) throw new Exception("Cannot read config.");
            rotors = new List<Rotor>();
            foreach (var rotorConfig in config.Rotors)
            {
                rotors.Add(new Rotor(rotorConfig.Wiring, rotorConfig.Position));
            }

            reflector = new Reflector(config.Reflector);
            plugboard = new Plugboard(config.Plugboard);
        }

        public Enigma(List<Rotor> rotors, Reflector reflector, Plugboard? plugboard = null)
        {
            this.rotors = rotors;
            this.reflector = reflector;
            this.plugboard = plugboard ?? new Plugboard();
        }

        public string Encrypt(string input)
        {
            char[] output = new char[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];
                if (!char.IsLetter(c))
                {
                    output[i] = c;
                    continue;
                }

                bool isUpper = char.IsUpper(c);
                char letter = char.ToUpper(c);

                rotors[0].Rotate();

                letter = plugboard.Swap(letter);
                foreach (var rotor in rotors)
                {
                    letter = rotor.Forward(letter);
                }
                letter = reflector.Reflect(letter);
                for (int j = rotors.Count - 1; j >= 0; j--)
                {
                    letter = rotors[j].Reverse(letter);
                }
                letter = plugboard.Swap(letter);

                output[i] = isUpper ? letter : char.ToLower(letter);
            }

            return new string(output);
        }
    }
}
