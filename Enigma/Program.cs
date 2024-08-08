namespace Enigma
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var enigma = new Enigma(File.OpenRead("config.json"));

            Console.WriteLine("Enter text to encrypt:");
            string? plaintext = Console.ReadLine();
            string ciphertext = enigma.Encrypt(plaintext ?? string.Empty);

            Console.WriteLine("Ciphertext: " + ciphertext);
        }
    }
}
