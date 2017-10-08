public static class ExtensionsString
{
    /// <summary>
    /// Adds spaces with provided interval
    /// </summary>
    public static string SplitBySpaces(this string value, int interval = 3)
    {
        string output = "";

        int i;

        for (i = 0; i < value.Length; i += interval)
        {
            output += value.Substring(i, interval);
            output += " ";
        }

        return output;
    }
}
