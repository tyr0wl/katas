namespace katas
{
    public class AlphabetCipher
    {
        private readonly string _keyword;

        public AlphabetCipher(string keyword)
        {
            _keyword = keyword;
        }

        public string Encode(string input)
        {
            var substitutedInput = SubstituteInputWithKeyword(input);
            var encryptedInput = string.Empty;
            for (var index = 0; index < input.Length; index++)
            {
                var offset = 'z' - substitutedInput[index] + 1;
                var encryptedChar = input[index] - offset;
                if (encryptedChar < 'a')
                {
                    encryptedChar += 26;
                }

                encryptedInput += (char)encryptedChar;
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
