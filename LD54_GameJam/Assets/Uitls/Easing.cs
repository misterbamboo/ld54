using UnityEngine;

public class Easing 
{
    public static float EaseOut(float t, float pow)
    {
        return Flip(Pow(Flip(t), pow));
    }

    private static float Pow(float x, float pow)
    {
        return Mathf.Pow(x, pow);
    }

    private static float Flip(float x)
    {
        return 1 - x;
    }
}
