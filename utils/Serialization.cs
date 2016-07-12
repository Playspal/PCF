using UnityEngine;
using System.Collections;

namespace com.playspal.core.utils
{
    public class Serialization
    {
        public static string IntArrayToString(int[] array)
        {
            string output = "";

            int i;

            for (i = 0; i < array.Length;i++ )
            {
                if(array[i] == 0)
                {
                    continue;
                }

                output += i + ":" + array[i] + ";";
            }
            Debug.LogError(output);
            return output;
        }

        public static int[] StringToIntArray(string input, int length)
        {
            Debug.LogError(input);
            int[] output = new int[length];

            string[] items = input.Split(';');
            string[] temp;

            int i;
            int key;
            int value;

            for(i = 0; i < items.Length; i++)
            {
                temp = items[i].Split(':');

                if (temp == null || temp.Length != 2)
                {
                    continue;
                }

                key = int.Parse(temp[0]);
                value = int.Parse(temp[1]);

                output[key] = value;
            }

            return output;
        }
    }
}