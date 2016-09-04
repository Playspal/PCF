using UnityEngine;
using System.Collections;
using System;
using System.Xml.Serialization;
using System.IO;

namespace com.playspal.core.utils
{
    public class Serialization
    {
        public static string IntArrayToString(int[] input)
        {
            int i;
            string output = "";

            for(i = 0; i < input.Length; i++)
            {
                output += i > 0 ? "," : "";
                output += input[i];
            }

            return output;
        }

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

        public static string ObjectToXML<T>(T input)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(input.GetType());

            using (StringWriter textWriter = new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, input);
                return textWriter.ToString();
            }
        }

        public static object XMLToObject(string objectData, Type type)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(type);

            using (TextReader textReader = new StringReader(objectData))
            {
                return xmlSerializer.Deserialize(textReader);
            }
        }
    }
}
