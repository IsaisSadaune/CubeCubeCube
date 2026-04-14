using UnityEngine;

public class ScriptToReferenceInstantPos : MonoBehaviour
{
    public Transform parentTransform { get; private set; }

    private void Awake()
    {
        parentTransform = GetComponent<Transform>();
    }
}
