using UnityEngine;

using System;
using System.Collections;

public static class Extensions
{
    public static string SplitStringBySpaces(this string value, int interval = 3)
    {
        string output = "";

        int i;

        for(i = 0; i < value.Length; i+= interval)
        {
            output += value.Substring(i, interval);
            output += " ";
        }

        return output;
    }

    public static string IntToLeadingZerosString(this int value, int length = 2)
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

    public static string FloatToLeadingZerosString(this float value, int length = 2)
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
