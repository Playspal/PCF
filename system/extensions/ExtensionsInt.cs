using System.Text;

public static class ExtensionsInt
{
    /// <summary>
    /// Convert to string with leading zeros.
    /// If length of original value same or bigger than length parameter, zeros will be not added
    /// </summary>
    /// <param name="length">Target string length</param>
    public static string ToLeadingZerosString(this int value, int length = 2)
    {
        StringBuilder stringBuilder = new StringBuilder();

        string valueAsString = value.ToString();
        int i;

        length -= valueAsString.Length;

        for (i = 0; i < length; i++)
        {
            stringBuilder.Append("0");
        }

        stringBuilder.Append(valueAsString);

        return stringBuilder.ToString();
    }
}
