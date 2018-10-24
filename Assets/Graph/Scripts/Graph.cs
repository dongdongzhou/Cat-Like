using UnityEngine;

public class Graph : MonoBehaviour
{
    private const float DomainSize = 2f;
    private const float HalfDomainSize = DomainSize / 2;
    public Transform PointPrefab;
    private Transform[] points;
    private FunctionSelector selector;


    [Range(10, 100)] public int resolution = 10;
    private float Step => DomainSize / resolution;
    private Vector3 Scale => Vector3.one * Step;


    // Start is called before the first frame update
    private void Awake()
    {
        selector = GetComponent<FunctionSelector>();

        points = new Transform[resolution * resolution];


        for (int i = 0; i < points.Length; i++)
        {
            Transform point = Instantiate(PointPrefab, transform, false);
            point.localScale = Scale;
            points[i] = point;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        float t = Time.time;

        float halfPrefabSize = PointPrefab.localScale.x / 2;

        for (int i = 0, z = 0; z < resolution; z++)
        {
            float v = (z + halfPrefabSize) * Step - HalfDomainSize;
            for (int x = 0; x < resolution; x++, i++)
            {
                float u = (x + halfPrefabSize) * Step - HalfDomainSize;
                points[i].localPosition = selector.MyFunction(u, v, t);
            }
        }
    }
}