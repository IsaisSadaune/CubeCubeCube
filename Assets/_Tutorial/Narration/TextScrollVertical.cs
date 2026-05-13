using UnityEngine;

public class TextScrollVertical : MonoBehaviour
{
    private float scrollSpeed = 6.5f;

    private void Update()
    {
        if (transform.position.y >= 50)
            Destroy(this.gameObject);

        transform.position = new Vector3(transform.position.x, transform.position.y + scrollSpeed * Time.deltaTime, transform.position.z);
    }
}
