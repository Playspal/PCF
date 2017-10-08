using System.Text;

public static class ExtensionsFloat
{
    /// <summary>
    /// Convert to string with leading zeros.
    /// If length of original value same or bigger than length parameter, zeros will be not added
    /// </summary>
    /// <param name="length">Target string length</param>
    public static string ToLeadingZerosString(this float value, int length = 2)
    {
        string valueAsString = value.ToString();
        int i;

        length -= valueAsString.Length;

        for (i = 0; i < length; i++)
        {
            valueAsString = "0" + valueAsString;
        }

        return valueAsString;
    }
}