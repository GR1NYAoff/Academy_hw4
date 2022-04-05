namespace Hw4.Exercise2;

internal static class Alphabet
{
    internal static char[] GetAlphabet()
    {
        var alphabet = new char[72];

        for (var i = 0; i < 26; i++)
        {
            alphabet[i] = Convert.ToChar(97 + i);
        }
        for (var i = 0; i < 10; i++)
        {
            alphabet[i + 26] = Convert.ToChar(48 + i);
        }
        for (var i = 0; i < 26; i++)
        {
            alphabet[i + 36] = Convert.ToChar(65 + i);
        }
        for (var i = 0; i < 10; i++)
        {
            alphabet[i + 62] = Convert.ToChar(48 + i);
        }

        return alphabet;
    }
}
