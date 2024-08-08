namespace Enigma
{
    public class Reflector
    {
        private Dictionary<char, char> mapping;

        public Reflector()
        {
            mapping = new Dictionary<char, char>();
            for (char i = 'A'; i < 'Z'; i++)
            {
                mapping[i] = i;
            }
        }

        public Reflector(List<string> pairs) : this()
        {
            foreach (var pair in pairs)
            {
                mapping[pair[0]] = pair[1];
                mapping[pair[1]] = pair[0];
            }
        }

        public char Reflect(char input)
        {
            return mapping[input];
        }
    }
}
