using System.Diagnostics;
using System.Text;
using Common;
namespace Hw4.Exercise1;

public sealed class PrimesApplication
{
    private readonly IFileSystemProvider _fileSystemProvider;

    public PrimesApplication(IFileSystemProvider fileSystemProvider)
    {
        _fileSystemProvider = fileSystemProvider;
    }

    /// <summary>
    /// Runs application.
    /// </summary>
    public ReturnCode Run()
    {
        var stopWatch = Stopwatch.StartNew();

        if (!_fileSystemProvider.Exists("app.settings"))
        {
            stopWatch.Stop();
            var result = Result.GetErrorResult("missing", stopWatch.Elapsed.ToString());

            var bytes = Encoding.UTF8.GetBytes(result);
            using var ms = new MemoryStream(bytes);

            _fileSystemProvider.Write("results.json", ms);

            return ReturnCode.Error;
        }

        using var inputFile = _fileSystemProvider.Read("app.settings");
        using var sr = new StreamReader(inputFile);
        var text = sr.ReadToEnd().Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

        var parseFrom = int.TryParse(Settings.GetStrFrom(text), out var from);
        var parseTo = int.TryParse(Settings.GetStrTo(text), out var to);

        if (!parseFrom && !parseTo)
        {
            stopWatch.Stop();
            var result = Result.GetErrorResult("corrupted", stopWatch.Elapsed.ToString());

            var bytes = Encoding.UTF8.GetBytes(result);
            using var ms = new MemoryStream(bytes);

            _fileSystemProvider.Write("results.json", ms);

            return ReturnCode.Error;
        }

        var primes = string.Empty;

        if (from > to)
        {
            stopWatch.Stop();
            var result = Result.GetSuccessResult(from, to, primes, stopWatch.Elapsed.ToString());

            var bytes = Encoding.UTF8.GetBytes(result);
            using var ms = new MemoryStream(bytes);

            _fileSystemProvider.Write("results.json", ms);

            return ReturnCode.Success;
        }
        else
        {
            for (var i = from; i <= to; i++)
            {
                if (IsPrimeNumber(i))
                {
                    primes += $"{i},";
                }
            }

            stopWatch.Stop();
            var result = Result.GetSuccessResult(from, to, primes.Trim(','), stopWatch.Elapsed.ToString());

            var bytes = Encoding.UTF8.GetBytes(result);
            using var ms = new MemoryStream(bytes);

            _fileSystemProvider.Write("results.json", ms);

            return ReturnCode.Success;
        }

    }
    public static bool IsPrimeNumber(int number)
    {
        if (number <= 1)
        {
            return false;
        }

        for (var i = 2; i <= number / 2; i++)
        {
            if (number % i == 0)
            {
                return false;
            }
        }
        return true;
    }

}
