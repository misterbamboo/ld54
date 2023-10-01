using UnityEngine;
using UnityEngine.UIElements;

public static class UIPosConverter
{
    private static readonly Vector3 conversionValue = new Vector3(5, 0, 5);

    public static Vector3 ToIndexPos(this Vector3 cursorPos)
    {
        return cursorPos + conversionValue;
    }

    public static Vector3 ToUIPos(this Vector3 indexPos)
    {
        return indexPos - conversionValue;
    }

    public static Vector3 Rotate(this Vector3 indexPos, float radAngle)
    {
        var degAngle = radAngle * Mathf.Rad2Deg;
        return Quaternion.Euler(0, degAngle, 0) * indexPos;
    }
}
