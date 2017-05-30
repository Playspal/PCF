using System;

public static class ActionExtensions
{
    public static void InvokeIfNotNull<T>(this Action<T> action, T obj)
    {
        if (action != null)
        {
            action(obj);
        }
    }

    public static void InvokeIfNotNull(this Action action)
    {
        if (action != null)
        {
            action();
        }
    }

    public static T InvokeIfNotNull<T>(this Func<T> action)
    {
        if (action != null)
        {
            return action();
        }

        return default(T);
    }
}
