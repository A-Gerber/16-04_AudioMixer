using UnityEngine;

public static class VolumeConverter
{
    private static float MinValue = 0.0001f;
    private static float Coefficient = 20f;

    public static float �onvertValue(float value)
    {
        return Mathf.Log10(Mathf.Max(MinValue, value)) * Coefficient;
    }
}