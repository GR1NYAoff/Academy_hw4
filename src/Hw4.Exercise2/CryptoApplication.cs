using System.Text;
using Common;
namespace Hw4.Exercise2;

public class CryptoApplication
{
    private readonly IFileSystemProvider _fileSystemProvider;

    public CryptoApplication(IFileSystemProvider fileSystemProvider)
    {
        _fileSystemProvider = fileSystemProvider;
    }

    /// <summary>
    /// Runs crypto application.
    /// </summary>
    /// <param name="args">Command line arguments</param>
    /// <returns>
    /// Returns <see cref="ReturnCode.Success"/> in case of successful encrypt/decrypt process.
    /// Returns <see cref="ReturnCode.InvalidArgs"/> in case of invalid <paramref name="args"/>.
    /// </returns>
    public ReturnCode Run(string[] args)
    {
        var inputFile = args.ElementAtOrDefault(0) ?? "input.txt";
        var parseOffset = int.TryParse(args.ElementAtOrDefault(1) ?? "3", out var offset);
        var mode = args.ElementAtOrDefault(2) ?? "enc";

        var encMode = mode.Contains("enc", StringComparison.CurrentCultureIgnoreCase);
        var decMode = mode.Contains("dec", StringComparison.CurrentCultureIgnoreCase);

        if (!parseOffset || !inputFile.Contains(".txt") || !(encMode || decMode))
            return ReturnCode.InvalidArgs;
        else if (!_fileSystemProvider.Exists(inputFile))
            return ReturnCode.Error;

        using var inpFileStream = _fileSystemProvider.Read(inputFile);
        using var sr = new StreamReader(inpFileStream);
        var text = sr.ReadToEnd();

        var caesarCipher = new CaesarCipher();
        var result = string.Empty;

        if (mode is "enc")
            result = caesarCipher.Encrypt(text.ToCharArray(), offset);
        else if (mode is "dec")
            result = caesarCipher.Decrypt(text.ToCharArray(), offset);
        else
            return ReturnCode.InvalidArgs;

        var bytes = Encoding.UTF8.GetBytes(result);
        var ms = new MemoryStream(bytes);

        var outputFileName = $"{inputFile}.{mode}";
        _fileSystemProvider.Write(outputFileName, ms);

        return ReturnCode.Success;

    }
}
