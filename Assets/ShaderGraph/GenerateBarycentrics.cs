using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Génère des coordonnées barycentriques par sommet pour un mesh donné.
/// À attacher sur un GameObject contenant un MeshFilter.
/// </summary>
[RequireComponent(typeof(MeshFilter))]
public class MeshBarycentricGenerator : MonoBehaviour
{
    [ContextMenu("Generate Barycentrics")]
    public void GenerateBarycentrics()
    {
        MeshFilter mf = GetComponent<MeshFilter>();
        if (mf == null || mf.sharedMesh == null)
        {
            Debug.LogError("❌ Aucun mesh trouvé sur " + name);
            return;
        }

        Mesh mesh = mf.sharedMesh;
        Mesh newMesh = new Mesh();
        newMesh.name = mesh.name + "_Wireframe";

        // On duplique toutes les données sauf les index
        newMesh.vertices = mesh.vertices;
        newMesh.normals = mesh.normals;
        newMesh.uv = mesh.uv;
        newMesh.colors = mesh.colors;
        newMesh.tangents = mesh.tangents;

        int[] triangles = mesh.triangles;
        Vector3[] verts = mesh.vertices;

        // On crée de nouvelles listes pour tout remapper sans partage de sommet
        List<Vector3> newVerts = new List<Vector3>();
        List<Vector3> barycentrics = new List<Vector3>();
        List<int> newTris = new List<int>();

        for (int i = 0; i < triangles.Length; i += 3)
        {
            int i0 = triangles[i];
            int i1 = triangles[i + 1];
            int i2 = triangles[i + 2];

            Vector3 v0 = verts[i0];
            Vector3 v1 = verts[i1];
            Vector3 v2 = verts[i2];

            // On assigne 1/0 barycentrique à chaque sommet du triangle
            newVerts.Add(v0);
            barycentrics.Add(new Vector3(1, 0, 0));
            newTris.Add(newVerts.Count - 1);

            newVerts.Add(v1);
            barycentrics.Add(new Vector3(0, 1, 0));
            newTris.Add(newVerts.Count - 1);

            newVerts.Add(v2);
            barycentrics.Add(new Vector3(0, 0, 1));
            newTris.Add(newVerts.Count - 1);
        }

        newMesh.SetVertices(newVerts);
        newMesh.SetTriangles(newTris, 0);
        newMesh.SetUVs(1, barycentrics); // barycentrics stockés dans TEXCOORD1 (ou TEXCOORD0 si tu veux)
        newMesh.RecalculateBounds();
        newMesh.RecalculateNormals();

        mf.sharedMesh = newMesh;

        Debug.Log($"✅ Barycentrics générés pour {name} ({newVerts.Count} sommets)");
    }
}