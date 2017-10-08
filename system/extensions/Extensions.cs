using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

using System.Text;

public static class Extensions
{
    /// <summary>
    /// Removes first item in list and returns it value
    /// </summary>
    public static T Shift<T>(this List<T> list)
    {
        if (list.Count > 0)
        {
            T output = list[0];
            list.RemoveAt(0);

            return output;
        }

        return default(T);
    }

    /// <summary>
    /// Removes last item in list and returns it value
    /// </summary>
    public static T Pop<T>(this List<T> list)
    {
        if (list.Count > 0)
        {
            T output = list[list.Count - 1];
            list.RemoveAt(list.Count - 1);

            return output;
        }

        return default(T);
    }

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
