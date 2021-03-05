using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleVersion.Utils
{
    public static class NameRefactorer
    {
        public static string GetFullName(string firstName, string middleName, string lastName)
        {
            if (middleName == null)
            {
                return $"{firstName} {lastName}";
            }

            return $"{firstName} {middleName} {lastName}";
        }

        public static string MakeFirstLetterUpperCase(string name)
        {
            if (name == null)
            {
                return null;
            }

            name = name.ToLower();

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < name.Length; i++)
            {
                if (i == 0)
                {
                    sb.Append(char.ToUpper(name[0]));
                }
                else
                {
                    sb.Append(name[i]);
                }
            }

            return sb.ToString();
        }
    }
}
