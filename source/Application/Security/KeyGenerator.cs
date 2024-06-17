namespace Application.Security
{
    public static class KeyGenerator
    {

        public static Guid GenerateGuid()
        {
            return Guid.NewGuid();
        }

        public static string GenerateGuidString()
        {
            return Guid.NewGuid().ToString();
        }

        public static Guid GenerateConcurrencyStamp()
        {
            return GenerateGuid();
        }

        public static string GenerateConcurrencyStampString()
        {
            return GenerateGuid().ToString();
        }

        public static string GenerateSecurityStamp()
        {
            var guid = GenerateGuid();
            return String.Concat(Array.ConvertAll(guid.ToByteArray(), b => b.ToString("X2")));
        }

        public static string GenerateLessonCode()
        {
            return GenerateRandomCode(12, includeNumbers: true, includelowercases: false, includeuppercases: true, includesymbols: false);
        }

        public static string GenerateRandomCode(uint length, bool includeNumbers = true, bool includelowercases = true, bool includeuppercases = true, bool includesymbols = true)
        {
            List<char> keyChars = new List<char>();

            if (includeNumbers)
                for (int i = 48; i <= 57; ++i)
                {
                    keyChars.Add((char)(i));
                }

            if (includelowercases)
                for (int i = 97; i <= 122; ++i)
                {
                    keyChars.Add((char)(i));
                }

            if (includeuppercases)
                for (int i = 65; i <= 90; ++i)
                {
                    keyChars.Add((char)(i));
                }

            if (includesymbols)
            {
                for (int i = 33; i <= 47; ++i)
                {
                    keyChars.Add((char)(i));
                }

                for (int i = 91; i <= 95; ++i)
                {
                    keyChars.Add((char)(i));
                }
            }


            string result = string.Empty;

            if (keyChars.Count <= 0 || length <= 0) return result;

            Random random = new Random(DateTime.Now.Millisecond);

            for (int i = 0; i < length; ++i)
            {
                result += keyChars[random.Next(0, keyChars.Count)];
            }
            return result;
        }
    }
}
