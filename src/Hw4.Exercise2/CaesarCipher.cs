namespace Hw4.Exercise2;

internal class CaesarCipher
{
    internal char[] _alpha = Alphabet.GetAlphabet();
    internal string Encrypt(char[] message, int key)
    {
        var encMessage = new char[message.Length];
        for (var i = 0; i < message.Length; i++)
        {
            var index = Array.IndexOf(_alpha, message[i]);
            if (index == -1)
            {
                encMessage[i] = message[i];
            }
            else
            {
                index += key;
                if (index > _alpha.Length - 1)
                {
                    index -= _alpha.Length;
                }
                encMessage[i] = _alpha[index];
            }

        }
        return new string(encMessage);

    }
    internal string Decrypt(char[] message, int key)
    {
        var decMessage = new char[message.Length];
        for (var i = 0; i < message.Length; i++)
        {
            var index = Array.IndexOf(_alpha, message[i]);
            if (index == -1)
            {
                decMessage[i] = message[i];
            }
            else
            {
                index -= key;
                if (index < 0)
                {
                    index += _alpha.Length;
                }
                decMessage[i] = _alpha[index];
            }

        }
        return new string(decMessage);

    }
}
