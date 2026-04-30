using UnityEngine;

public class DetectorWallTuto : MonoBehaviour
{
    [SerializeField] private WallConditional wc; //normalement toujours le parent
    private bool hasProc = false;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("aaa");
        if(!hasProc && other.CompareTag("Player"))
        {
            hasProc = true;
            wc.RemoveZone();
        }
    }
}
