namespace BWT;

public static class BWTAlgorithm
{
    public static (string, int) FrontBWT(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return (string.Empty, -1);
        }

        int lengthOfString = input.Length;
        var indices = new int[lengthOfString];

        for (int i = 0; i < lengthOfString; ++i)
        {
            indices[i] = i;
        }

        Array.Sort(indices, (a, b) =>
        {
            for (int i = 0; i < lengthOfString; ++i)
            {
                char charA = input[(a + i) % lengthOfString];
                char charB = input[(b + i) % lengthOfString];
                if (charA != charB)
                {
                    return charA.CompareTo(charB);
                }
            }

            return 0;
        });

        var bwtChars = new char[lengthOfString];
        int bwtIndex = -1;

        for (int i = 0; i < lengthOfString; ++i)
        {
            int rotationsStartIndex = indices[i];

            bwtChars[i] = input[(rotationsStartIndex + lengthOfString - 1) % lengthOfString];

            if (rotationsStartIndex == 0)
            {
                bwtIndex = i;
            }
        }

        string transformedString = new string(bwtChars);
        return (transformedString, bwtIndex);
    }

    public static string InverseBWT(string bwtString, int originalIndex)
    {
        if (string.IsNullOrEmpty(bwtString) || originalIndex < 0)
        {
            return string.Empty;
        }

        int lengthOfBWTString = bwtString.Length;

        var result = new char[lengthOfBWTString];
        var next = new int[lengthOfBWTString];

        Dictionary<char, int> counts = new Dictionary<char, int>();
        foreach (char symbol in bwtString)
        {
            if (counts.ContainsKey(symbol))
            {
                counts[symbol]++;
            }
            else
            {
                counts[symbol] = 1;
            }
        }

        var sortedChars = counts.Keys.OrderBy(c => c).ToList();

        Dictionary<char, int> startPos = new Dictionary<char, int>();
        int pos = 0;
        foreach (char symbol in sortedChars)
        {
            startPos[symbol] = pos;
            pos += counts[symbol];
        }

        Dictionary<char, int> tmpCount = new Dictionary<char, int>(startPos);
        for (int i = 0; i < lengthOfBWTString; ++i)
        {
            char symbol = bwtString[i];
            next[i] = tmpCount[symbol];
            tmpCount[symbol]++;
        }

        int current = originalIndex;
        for (int i = lengthOfBWTString - 1; i >= 0; --i)
        {
            result[i] = bwtString[current];
            current = next[current];
        }

        return new string(result);
    }
}