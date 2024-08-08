namespace Enigma
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Rotor rotor1 = new Rotor("EKMFLGDQVZNTOWYHXUSPAIBRCJ", 17);  // Rotor I
            Rotor rotor2 = new Rotor("AJDKSIRUXBLHWTMCQGZNPYFVOE", 5);   // Rotor II
            Rotor rotor3 = new Rotor("BDFHJLCPRTXVZNYEIWGAKMUSQO", 22);  // Rotor III
            string reflector = "YRUHQSLDPXNGOKMIEBFZCWVJAT";             // Reflector B

            Enigma enigma = new Enigma(new List<Rotor> { rotor1, rotor2, rotor3 }, reflector);
            string plaintext = "HELLOWORLD";
            string ciphertext = enigma.Encode(plaintext);
            Console.WriteLine($"Plaintext: {plaintext}");
            Console.WriteLine($"Ciphertext: {ciphertext}");
        }
    }
}
