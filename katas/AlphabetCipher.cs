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
            return input;
        }
    }
}
