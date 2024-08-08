namespace Enigma
{
    public class Rotor
    {
        private string wiring;
        private int position;

        public char Current => wiring[position];

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

        public bool Rotate()
        {
            position = (position + 1) % 26;
            if (position == 0) return true;
            return false;
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
