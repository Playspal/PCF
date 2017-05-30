using UnityEngine;

namespace com.playspal.core.utils.helpers
{
    public class UnityFileSystemHelper
    {
        public static string RootDirectory
        {
            get
            {
                string output = "";

                if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
                {
                    output = Application.persistentDataPath + "/";
                }
                else
                {
                    output = Application.dataPath + "/";
                }

                return output;
            }
        }
    }
}
