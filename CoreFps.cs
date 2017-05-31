using UnityEngine;

public class CoreFps
{
    public static float Value = 0;

    private static float _deltaTime = 0;

    public static void Update()
    {
        _deltaTime += (Time.deltaTime - _deltaTime) * 0.1f;

        Value = 1.0f / _deltaTime;
    }
}
