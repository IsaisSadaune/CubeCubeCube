using UnityEngine;

public class MeshHeightCalculator : MonoBehaviour
{
    public Mesh mesh;
    public float height;
    public Material mat;
    public int matIndex;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mesh = gameObject.GetComponent<MeshFilter>().mesh;
        mat = gameObject.GetComponent<MeshRenderer>().materials[matIndex];
    }

    // Update is called once per frame
    void Update()
    {
        height = mesh.bounds.size.y;
        mat.SetFloat("_Height", height);
    }
}
