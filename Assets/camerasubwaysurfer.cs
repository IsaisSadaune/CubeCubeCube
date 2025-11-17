using UnityEngine;

public class camerasubwaysurfer : MonoBehaviour
{
    public float speed = 5f;
    public Vector3 v;
    void Update()
    {
        transform.Rotate(v * speed * Time.deltaTime);
    }
}
