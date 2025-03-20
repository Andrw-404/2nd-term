namespace BWT
{
    using System.Text;
    public class BWTAlgorithm
    {
        public static (string, int) FrontBWT(string input)
        {
            int lengthOfString = input.Length;
            string[] rotations = new string[lengthOfString];

            for (int i = 0; i < lengthOfString; ++i)
            {
                rotations[i] = input.Substring(i) + input.Substring(0, i);
            }

            Array.Sort(rotations);

            string transformed = new string(rotations.Select(s => s[lengthOfString - 1]).ToArray());
            int bwtIndex = Array.IndexOf(rotations, input);

            return (transformed, bwtIndex);
        }

        public static string InverseBWT(string bwtString, int originalIndex)
        {
            int lengthOfBWTString = bwtString.Length;

            string[] table = new string[lengthOfBWTString];
            for (int i = 0; i < lengthOfBWTString; ++i)
            {
                table[i] = string.Empty;
            }

            for (int q = 0; q < lengthOfBWTString; ++q)
            {
                for (int k = 0; k < lengthOfBWTString; ++k)
                {
                    table[k] = bwtString[k] + table[k];
                }

                Array.Sort(table);
            }

            return table[originalIndex];
        }
    }
}