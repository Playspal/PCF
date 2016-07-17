using UnityEngine;
using System.Collections;
using System;

namespace com.playspal.core.utils
{
    public class Serialization
    {
        public static int[] StringToIntArray(string input)
        {
            string[] items = input.Split(new string[] { "," }, StringSplitOptions.None);

            int i;
            int[] output = new int[items.Length];

            for (i = 0; i < items.Length; i++)
            {
                if (string.IsNullOrEmpty(items[i]))
                {
                    continue;
                }

                output[i] = int.Parse(items[i]);
            }

            return output;
        }
    }
}
