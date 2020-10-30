namespace katas
{
    public class AlphabetCipher
    {
        private const string Alphabet = "abcdefghijklmnopqrstuvwxyz";
        private readonly char[][] _substitutionChart = CreateSubstitutionChart();

        private readonly string _keyword;

        public AlphabetCipher(string keyword)
        {
            _keyword = keyword;
        }

        private static char[][] CreateSubstitutionChart()
        {
            var substitutionChart = new char[Alphabet.Length][];
            for (var index = 0; index < Alphabet.Length; index++)
            {
                var index2 = index;
                substitutionChart[index] = new char[Alphabet.Length];

                for (var indexJ = 0; indexJ < Alphabet.Length; indexJ++)
                {
                    var shiftedIndex = index2 + indexJ;
                    if (shiftedIndex >= Alphabet.Length)
                    {
                        index2 -= 26;
                        shiftedIndex = 0;
                    }

                    substitutionChart[index][indexJ] = Alphabet[shiftedIndex];
                }
            }

            return substitutionChart;
        }

        public string Encode(string input)
        {
            var substitutedInput = SubstituteInputWithKeyword(input);
            var encryptedInput = string.Empty;
            for (var index = 0; index < input.Length; index++)
            {
                encryptedInput += _substitutionChart[input[index] % 32 - 1][substitutedInput[index] % 32 - 1];
            }

            return encryptedInput;
        }

        private string SubstituteInputWithKeyword(string input)
        {
            string substitutedInput = null;
            var keywordIndex = 0;

            for (var index = 0; index < input.Length; index++)
            {
                if (keywordIndex == _keyword.Length)
                {
                    keywordIndex = 0;
                }

                substitutedInput += _keyword[keywordIndex];
                keywordIndex++;
            }

            return substitutedInput;
        }
    }
}
