using UnityEngine;

using System;
using System.Collections;

namespace com.playspal.core.utils.helpers
{
    public class TimeHelper
    {
        public static int GetUnixTimestamp()
        {
            return (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
        }

        public static string SecondsToFormatedMinutesString(float time)
        {
            time = time > 0 ? time : 0;

            string output = "";

            float seconds = Mathf.Floor(time);
            float minutes = Mathf.Floor(seconds / 60f);

            seconds -= minutes * 60;

            output += minutes.ToLeadingZerosString(2);
            output += ":";
            output += seconds.ToLeadingZerosString(2);

            return output;
        }

        public static string SecondsToFormatedHoursString(float time)
        {
            time = time > 0 ? time : 0;

            string output = "";

            float seconds = Mathf.Floor(time);
            float minutes = Mathf.Floor(seconds / 60f);
            float hours = Mathf.Floor(minutes / 60f);

            seconds -= minutes * 60;
            minutes -= hours * 60;

            output += hours.ToLeadingZerosString(2);
            output += ":";
            output += minutes.ToLeadingZerosString(2);
            output += ":";
            output += seconds.ToLeadingZerosString(2);

            return output;
        }
    }
}
