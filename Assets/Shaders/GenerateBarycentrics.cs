using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(MeshFilter))]
public class GenerateBarycentrics : MonoBehaviour
{
    public bool generateOnStart = false;

    void Start()
    {
        if (generateOnStart)
            ApplyBarycentrics();
    }

    public void ApplyBarycentrics()
    {
        MeshFilter mf = GetComponent<MeshFilter>();
        if (mf == null || mf.sharedMesh == null)
        {
            Debug.LogWarning("Aucun MeshFilter ou Mesh trouvé sur l’objet.");
            return;
        }

        // Dupliquer le mesh pour ne pas écraser l’original
        Mesh mesh = Instantiate(mf.sharedMesh);
        mesh.name = mf.sharedMesh.name + "_Barycentric";

        int[] tris = mesh.triangles;
        Vector3[] barycentrics = new Vector3[mesh.vertexCount];

        for (int i = 0; i < tris.Length; i += 3)
        {
            barycentrics[tris[i]] = new Vector3(1, 0, 0);
            barycentrics[tris[i + 1]] = new Vector3(0, 1, 0);
            barycentrics[tris[i + 2]] = new Vector3(0, 0, 1);
        }

        mesh.SetUVs(1, new System.Collections.Generic.List<Vector3>(barycentrics));
        mf.sharedMesh = mesh;

        Debug.Log($"✅ Coordonnées barycentriques générées pour {mesh.vertexCount} sommets !");
    }
}