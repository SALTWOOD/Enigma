namespace Enigma
{
    public class Plugboard
    {
        private Dictionary<char, char> mapping;

        public Plugboard()
        {
            this.mapping = new Dictionary<char, char>();
            for (char c = 'A'; c <= 'Z'; c++)
            {
                this.mapping[c] = c;
            }
        }

        public Plugboard(List<string> pairs) : this()
        {
            foreach (var pair in pairs)
            {
                this.mapping[pair[0]] = pair[1];
                this.mapping[pair[1]] = pair[0];
            }
        }

        public char Swap(char input)
        {
            return mapping[input];
        }
    }
}
