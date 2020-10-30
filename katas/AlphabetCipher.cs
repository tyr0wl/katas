using System;

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
            return Process(input, ApplyEncodingOffset);
        }

        public string Decode(string input)
        {
            return Process(input, ApplyDecodingOffset);
        }

        private char ApplyEncodingOffset(char input, int offset)
        {
            var encryptedChar = input - offset;
            if (encryptedChar < 'a')
            {
                encryptedChar += 26;
            }

            return (char)encryptedChar;
        }

        private char ApplyDecodingOffset(char input, int offset)
        {
            var encryptedChar = input + offset;
            if (encryptedChar > 'z')
            {
                encryptedChar -= 26;
            }

            return (char)encryptedChar;
        }

        private string Process(string input, Func<char, int, char> applyOffset)
        {
            var substitutedInput = SubstituteInputWithKeyword(input);
            var encryptedInput = string.Empty;
            for (var index = 0; index < input.Length; index++)
            {
                var offset = 'z' - substitutedInput[index] + 1;
                encryptedInput += applyOffset(input[index], offset);
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
