using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma
{
    public class EnigmaConfig
    {
        public List<RotorConfig> Rotors { get; set; } = new List<RotorConfig>();
        public List<string> Reflector { get; set; } = new List<string>();
        public List<string> Plugboard { get; set; } = new List<string>();
    }

    public class RotorConfig
    {
        public string Wiring { get; set; } = string.Empty;
        public int Position { get; set; }
    }
}
