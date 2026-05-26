using UnityEngine;

public class Node
{
    public Vector3 position;
    public float g;
    public float h;
    public float f;
    public Node parent;    

    public Node(Vector3 position)
    {
        this.position = position;
        g = 0;
        h = 0;
        f = 0;
        parent = null;
    }
}

