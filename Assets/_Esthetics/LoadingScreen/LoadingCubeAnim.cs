using System.Transactions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class LoadingCubeAnim : MonoBehaviour
{
    public Material OutlineMat;
    public float lineWidth;

    [Header ("Loading Animation")]
    public Vector3 rotationSpeed = new Vector3(15f, 45f, 0f);
    public bool autoFill = true;
    public float autoFillDuration;
    public float progress = 0f;

    public LineRenderer[] lines {get; private set;}
    private Vector3[] starts;
    private Vector3[] ends;
    private float fillTimer;

     private static readonly int[,] EdgePairs =
    {
        {0,1},{1,2},{2,3},{3,0},   // face arrière (4 arêtes)
        {0,4},{1,5},{2,6},{3,7},   // piliers verticaux (4 arêtes)
        {4,5},{5,6},{6,7},{7,4}    // face avant (4 arêtes)
    };

    void Start()
    {
        transform.GetChild(0).gameObject.SetActive(false);

        Bounds b = transform.GetComponent<MeshFilter>().sharedMesh.bounds;

        Vector3[] ordered = new Vector3[8]
        {
            CornerOf(b, transform, -1,-1,-1), CornerOf(b, transform,  1,-1,-1),
            CornerOf(b, transform,  1, 1,-1), CornerOf(b, transform, -1, 1,-1),
            CornerOf(b, transform, -1,-1, 1), CornerOf(b, transform,  1,-1, 1),
            CornerOf(b, transform,  1, 1, 1), CornerOf(b, transform, -1, 1, 1)
        };
        int edgeCount = EdgePairs.GetLength(0);
        lines = new LineRenderer[edgeCount];
        starts = new Vector3[edgeCount];
        ends = new Vector3[edgeCount];

        for (int i=0; i < edgeCount; i++)
        {
            GameObject go = new GameObject($"Edge_{i:D2}");
            go.transform.SetParent(transform, false);

            LineRenderer lr = go.AddComponent<LineRenderer>();
            lr.material = OutlineMat;
            lr.startWidth = lineWidth;
            lr.endWidth = lineWidth;
            lr.positionCount = 2;
            lr.useWorldSpace = false;
            lr.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
            lr.enabled = false;

            starts[i] = ordered[EdgePairs[i, 0]];
            ends[i] = ordered[EdgePairs[i, 1]];

            lr.SetPosition(0, starts[i]);
            lr.SetPosition(1, ends[i]);

            lines[i] = lr;
        }
    }

    void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime, Space.Self);

        if (autoFill)
        {
            fillTimer += Time.deltaTime;
            progress = Mathf.Clamp01(fillTimer / autoFillDuration);
        }

        UpdateEdges();
    }

    void UpdateEdges()
    {
        float edgeProgress = progress * lines.Length;

        for(int i = 0; i < lines.Length; i++)
        {
            float lit = edgeProgress - i;

            if(lit <= 0f)
            {
                lines[i].enabled = false;
                continue;
            }

            lines[i].enabled = true;

            float alpha = Mathf.Clamp01(lit);

            lines[i].SetPosition(1, Vector3.Lerp(starts[i], ends[i], alpha));
        }
    }

    public void SetProgress(float value)
    {
        autoFill = false;
        progress = Mathf.Clamp01(value);
    }

    void OnDisable()
    {
        transform.rotation = Quaternion.Euler(0f,0f,0f);
        progress = 0f;
        fillTimer = 0f;
        autoFill = true;
        for(int i = 0; i < lines.Length; i++)
        {
            Debug.Log("eh");
            lines[i].SetPosition(1, starts[i]);
            lines[i].enabled = false;  
        }
    }
    
    Vector3 CornerOf(Bounds b, Transform cube, int sx, int sy, int sz)
    {
        Vector3 localPoint = b.center + Vector3.Scale(b.extents, new Vector3(sx, sy, sz));
 
        return transform.InverseTransformPoint(cube.TransformPoint(localPoint));
    }

}
