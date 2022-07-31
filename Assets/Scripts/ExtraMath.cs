using UnityEngine;

public static class ExtraMath
{

    // ----- ACERCARSE DE "A" A "B" LA CANTIDAD "C" -----

    public static float Approach(float a, float b, float c)
    {
        if (Mathf.Abs(b - a) <= c)
        {
            return b;
        }
        else
        {
            return a + Mathf.Sign(b - a) * c;
        }
    }

    public static Vector3 Approach(Vector3 a, Vector3 b, Vector3 c)
    {
        return new Vector3(Approach(b.x, a.x, c.x), Approach(b.y, a.y, c.y), Approach(b.z, a.z, c.z));
    }

    public static Vector3 Approach(Vector3 a, Vector3 b, float c)
    {
        if ((b - a).magnitude <= c)
        {
            return b;
        }
        else
        {
            return a + (b - a).normalized * c;
        }
    }

    public static Vector2 Approach(Vector2 a, Vector2 b, Vector2 c)
    {
        return new Vector2(Approach(b.x, a.x, c.x), Approach(b.y, a.y, c.y));
    }

    public static Vector2 Approach(Vector2 a, Vector2 b, float c)
    {
        if ((b - a).magnitude <= c)
        {
            return b;
        }
        else
        {
            return a + (b - a).normalized * c;
        }
    }
}
