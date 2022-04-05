namespace Hw4.Exercise1;

internal static class Settings
{
    internal static string? GetStrFrom(string[] text)
    {
        return text.Length < 2 ? null : (text.Where(str => str.Contains("From")).ToList().First()?[11..]);

    }
    internal static string? GetStrTo(string[] text)
    {
        return text.Length < 2 ? null : (text.Where(str => str.Contains("To")).ToList().First()?[9..]);

    }
}
