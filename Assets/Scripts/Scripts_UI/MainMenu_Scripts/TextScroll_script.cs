using UnityEngine;

public class TextScroll_script : MonoBehaviour
{
    [SerializeField] private GameObject titleToInstantiate;
    [SerializeField] private Transform parentTransform;
    [SerializeField] private float scrollSpeed;
    private Vector3 instantiatePosition;
    private bool hasInstantiated;

    private void Start()
    {
        parentTransform = GameObject.Find("ScrollingText_Canva").transform;
        hasInstantiated = false;
        instantiatePosition = new Vector3(-600, transform.position.y, transform.position.z);
    }

    private void Update()
    {
        if (transform.position.x >= 0 && !hasInstantiated)
        {
            hasInstantiated = true;
            Instantiate(titleToInstantiate, instantiatePosition, Quaternion.identity, parentTransform);
        }

        if (transform.position.x >= 1200)
            Destroy(this.gameObject);

        transform.position = new Vector3(transform.position.x + scrollSpeed * Time.deltaTime, transform.position.y, transform.position.z);
    }
}
