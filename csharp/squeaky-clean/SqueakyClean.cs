using System;
using System.Text;

public static class Identifier
{
    public static string Clean(string identifier)
    {
        StringBuilder sb = new StringBuilder();

        // Replace control characters with "CTRL"
        for (int i = 0; i < identifier.Length; i++)
        {
            char c = identifier[i];

            if (c == ' ')
            {
                sb.Append(" ");
            }
            if (char.IsControl(c))
            {
                sb.Append("CTRL");
            }
            if (c == '-')
            {
                if (i + 1 < identifier.Length)
                {
                    sb.Append(Char.ToUpper(identifier[i + 1]));
                    i++;
                }

            }
            if ('α' <= c && c <= 'ω')
            {
                continue;
            }
            if (char.IsLetter(c))
            {
                sb.Append(c);
            }
        }

        return sb.ToString();
    }
}
