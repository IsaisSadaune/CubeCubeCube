using UnityEngine;

public class TextScroll_script : MonoBehaviour
{
    [SerializeField] private GameObject titleToInstantiate;
    [SerializeField] private ScriptToReferenceInstantPos parentTransformScript;
    [SerializeField] private float scrollSpeed;
    [SerializeField] private Transform instantiatePosition, destroyPosition;
    private bool hasInstantiated;

    private void Update()
    {
        if (transform.position.x <= 0 && !hasInstantiated)
        {
            hasInstantiated = true;
            Instantiate(titleToInstantiate, instantiatePosition.position, Quaternion.identity, parentTransformScript.parentTransform);
        }

        if (transform.position.x <= destroyPosition.position.x)
            Destroy(this.gameObject);

        transform.position = new Vector3(transform.position.x - scrollSpeed * Time.deltaTime, transform.position.y, transform.position.z);
    }
}
