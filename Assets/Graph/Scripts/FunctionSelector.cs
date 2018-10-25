using UnityEngine;

public enum GraphFunctions
{
    Sine,
    Sine2D,
    MultiSine,
    MultiSine2D,
    Ripple,
    Cylinder,
    Sphere,
    Torus
}


public class FunctionSelector : MonoBehaviour

{
    public delegate Vector3 GraphFunction(float u, float v, float t);

    public const float pi = Mathf.PI;
    private GraphFunction[] GraphFuncs;
    public GraphFunction MyFunction;

    public GraphFunctions selectedFunction = GraphFunctions.Sine;

    [ConditionalField("selectedFunction", GraphFunctions.MultiSine)]
    public float secondaryFrequencyMultiplier = 2f;

    [ConditionalField("selectedFunction", GraphFunctions.MultiSine)]
    public float secondaryAmplitude = 0.5f;

    public Vector3 Sine(float x, float z, float t)
    {
        Vector3 p;
        p.x = x;
        p.y = Mathf.Sin(pi * (x + t));
        p.z = z;
        return p;
    }

    public Vector3 MultiSine(float x, float z, float t)
    {
        Vector3 p;
        p.x = x;
        float normalizationFactor = 1f / (1f + secondaryAmplitude);
        p.y = Mathf.Sin(pi * (x + t));
        p.y = Mathf.Sin(secondaryFrequencyMultiplier * pi * (x + t)) * secondaryAmplitude;
        p.y *= normalizationFactor;
        p.z = z;
        return p;
    }

    public Vector3 Sine2D(float x, float z, float t)
    {
        Vector3 p;
        p.x = x;
        p.y = Mathf.Sin(pi * (x + t));
        p.y += Mathf.Sin(pi * (z + t));
        p.y *= 0.5f;
        p.z = z;
        return p;
    }

    public Vector3 MultiSine2D(float x, float z, float t)
    {
        Vector3 p;
        p.x = x;
        p.y = 4f * Mathf.Sin(pi * (x + z + t * 0.5f));
        p.y += Mathf.Sin(pi * (x + t));
        p.y += Mathf.Sin(2f * pi * (z + 2f * t)) * 0.5f;
        p.y *= 1f / 5.5f;
        p.z = z;
        return p;
    }

    public Vector3 Ripple(float x, float z, float t)
    {
        Vector3 p;
        p.x = x;
        float d = Mathf.Sqrt(x * x + z * z);
        p.y = Mathf.Sin(pi * (4f * d - t));
        p.y /= 1f + 10f * d;
        p.z = z;
        return p;
    }

    public Vector3 Cylinder(float u, float v, float t)
    {
        Vector3 p;
        float r = 0.8f + Mathf.Sin(pi * (6f * u + 2f * v + t)) * 0.2f;
        p.x = r * Mathf.Sin(pi * u);
        p.y = v;
        p.z = r * Mathf.Cos(pi * u);
        return p;
    }

    public Vector3 Sphere(float u, float v, float t)
    {
        Vector3 p;
        float r = 0.8f + Mathf.Cos(pi * (6f * u + t)) * 0.1f;
        r += Mathf.Sin(pi * (4f * v + t)) * 0.1f;
        float s = r * Mathf.Cos(pi * 0.5f * v);
        p.x = s * Mathf.Sin(pi * u);
        p.y = r * Mathf.Sin(pi * 0.5f * v);
        p.z = s * Mathf.Cos(pi * u);
        return p;
    }

    public Vector3 Torus(float u, float v, float t)
    {
        Vector3 p;
        float r1 = 0.65f + Mathf.Sin(pi * (6f * u + t)) * 0.1f;
        float r2 = 0.2f + Mathf.Sin(pi * (4f * v + t)) * 0.05f;
        float s = r2 * Mathf.Cos(pi * v) + r1;
        p.x = s * Mathf.Sin(pi * u);
        p.y = r2 * Mathf.Sin(pi * v);
        p.z = s * Mathf.Cos(pi * u);
        return p;
    }

    private void Start()
    {
        GraphFuncs = new GraphFunction[]
                     {
                         Sine,
                         Sine2D,
                         MultiSine,
                         MultiSine2D,
                         Ripple,
                         Cylinder,
                         Sphere,
                         Torus
                     };
        MyFunction = GraphFuncs[(int) selectedFunction];
    }

    private void Update()
    {
        MyFunction = GraphFuncs[(int) selectedFunction];
    }
}