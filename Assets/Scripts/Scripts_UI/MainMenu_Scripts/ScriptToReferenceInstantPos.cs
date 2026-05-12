using UnityEngine;

public class ScriptToReferenceInstantPos : MonoBehaviour
{
    public Transform parentTransform { get; private set; }
    public bool scrollingEnabled { get; private set; }

    private void Awake()
    {
        parentTransform = GetComponent<Transform>();
    }

    public void EnableScrolling()
    {
        scrollingEnabled = true;
    }
}
