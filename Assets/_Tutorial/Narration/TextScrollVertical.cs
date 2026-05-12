using UnityEngine;

public class TextScrollVertical : MonoBehaviour
{
    [SerializeField] private float scrollSpeed;
    [SerializeField] private Transform destroyPosition;

    private void Update()
    {
        if (transform.position.y >= destroyPosition.position.y)
            Destroy(this.gameObject);

        transform.position = new Vector3(transform.position.x, transform.position.y + scrollSpeed * Time.deltaTime, transform.position.z);
    }
}
