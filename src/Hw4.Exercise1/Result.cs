namespace Hw4.Exercise1;

internal static class Result
{
    internal static string GetSuccessResult(int from, int to, string primes, string dur)
    {
        var successResult = "{" +
            "\n  \"success\": true," +
            "\n  \"error\": null," +
           $"\n  \"range\": \"{from}-{to}\"," +
           $"\n  \"duration\": \"{dur}\"," +
           $"\n  \"primes\": [{primes}]" +
            "\n}";

        return successResult;

    }
    internal static string GetErrorResult(string str, string dur)
    {
        var errorResult = "{" +
            "\n  \"success\": false," +
           $"\n  \"error\": \"app.settings is {str}\"," +
           $"\n  \"duration\": \"{dur}\"," +
           $"\n  \"primes\": null" +
            "\n}";

        return errorResult;

    }
}
