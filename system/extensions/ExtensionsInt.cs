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

    /// <summary>
    /// Puts variable's value to Unity PlayerPrefs
    /// </summary>
    /// <param name="id">Unique Id of variable</param>
    public static void CacheSave(this int value, string id)
    {
        UnityEngine.PlayerPrefs.SetInt(id, value);
        UnityEngine.PlayerPrefs.Save();
    }

    /// <summary>
    /// Get value from Unity PlayerPrefs by unique Id
    /// </summary>
    /// <param name="id">Unique Id of variable</param>
    /// <param name="valueDefault">That value will be returned if PlayerPreft not contain provided Id</param>   
    public static int CacheLoad(this int value, string id, int valueDefault = 0)
    {
        return UnityEngine.PlayerPrefs.GetInt(id, valueDefault);
    }
}
