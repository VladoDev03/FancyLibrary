using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Utils
{
    public static class PasswordManager
    {
        private const int MinPasswordLength = 7;
        private const int MinSymbolsCount = 1;
        private const int MinNumbersCount = 1;
        private const int MinUpperCaseLettersCount = 1;
        private const int MinLowerCaseLettersCount = 1;

        public static bool IsPasswordValid(string password)
        {
            if (password.Length < MinPasswordLength)
            {
                throw new ArgumentException(string.Format(ExceptionsTexts.ShorterPassword, MinPasswordLength));
            }
            if (password.Where(x => char.IsUpper(x)).ToArray().Length < MinUpperCaseLettersCount)
            {
                throw new ArgumentException(string.Format(ExceptionsTexts.LessUpperCase, MinUpperCaseLettersCount));
            }
            if (password.Where(x => char.IsLower(x)).ToArray().Length < MinLowerCaseLettersCount)
            {
                throw new ArgumentException(string.Format(ExceptionsTexts.LessLowerCase, MinLowerCaseLettersCount));
            }
            if (password.Where(x => char.IsDigit(x)).ToArray().Length < MinNumbersCount)
            {
                throw new ArgumentException(string.Format(ExceptionsTexts.LessDigits, MinNumbersCount));
            }
            if (password.Where(x => char.IsSymbol(x)).ToArray().Length < MinSymbolsCount)
            {
                throw new ArgumentException(string.Format(ExceptionsTexts.LessSymbols, MinSymbolsCount));
            }

            return true;
        }

        public static string EncodePassword(string password)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = password.Length - 1; i >= 0; i--)
            {
                if (i % 2 == 0)
                {
                    sb.Append((char)(password[i] + 1));
                }
                else if (i % 3 == 0)
                {
                    sb.Append((char)(password[i] + 2));
                }
                else if (i % 5 == 0)
                {
                    sb.Append((char)(Math.Abs(password[i] - 7)));
                }
                else
                {
                    sb.Append((char)(password[i] + 5));
                }
            }

            return sb.ToString();
        }
    }
}
