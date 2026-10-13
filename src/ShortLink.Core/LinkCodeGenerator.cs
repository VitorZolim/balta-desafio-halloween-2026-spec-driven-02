using System.Security.Cryptography;

namespace ShortLink.Core;

public static class LinkCodeGenerator
{
    public const int Length = 7;
    private const string Alphabet = "ABCDEFGHJKLMNPQRSTUVWXYZ23456789";

    public static string Generate()
    {
        var chars = new char[Length];

        for (var i = 0; i < Length; i++)
        {
            chars[i] = Alphabet[RandomNumberGenerator.GetInt32(Alphabet.Length)];
        }

        return new string(chars);
    }

    public static bool IsValid(string code)
    {
        if (string.IsNullOrWhiteSpace(code) || code.Length != Length)
        {
            return false;
        }

        foreach (var character in code)
        {
            if (!Alphabet.Contains(character))
            {
                return false;
            }
        }

        return true;
    }
}
