using System.Collections;
using DG.Tweening;
using UnityEngine;

public class LoadingBackground : MonoBehaviour
{
    [SerializeField] private GameObject titleToInstantiate;
    [SerializeField] private ScriptToReferenceInstantPos parentTransformScript;
    [SerializeField] private float scrollSpeed;
    [SerializeField] private Transform instantiatePosition, destroyPosition;
    private bool hasInstantiated;

    private void Update()
    {
        if (parentTransformScript.scrollingEnabled)
        {
            if (transform.position.y <= 0 && !hasInstantiated)
            {
                hasInstantiated = true;
                GameObject go = Instantiate(titleToInstantiate, instantiatePosition.position, Quaternion.identity, parentTransformScript.parentTransform);
                go.transform.rotation = Quaternion.Euler(0f,0f,90f);
            }

            if (transform.position.y <= destroyPosition.position.y)
                Destroy(this.gameObject);

            transform.position = new Vector3(transform.position.x, transform.position.y - scrollSpeed * Time.deltaTime, transform.position.z);
        }
    }

}
