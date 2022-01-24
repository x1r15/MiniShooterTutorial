using UnityEngine;

public static class VectorsExtension
{
    public static Vector3 WithAxis(this Vector3 vector, Axis axis, float value)
    {
        return new Vector3(
            axis == Axis.X ? value : vector.x,
            axis == Axis.Y ? value : vector.y,
            axis == Axis.Z ? value : vector.z
            );
    }

    public static Vector3 WithZ(this Vector2 vector, float value)
    {
        return new Vector3(vector.x, vector.y, value);
    }
}

public enum Axis
{
    X, Y, Z
}