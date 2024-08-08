namespace Enigma
{
    public static class Utils
    {
        public static bool IsEnglishLetter(this char c)
        {
            return (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z');
        }
    }
}
