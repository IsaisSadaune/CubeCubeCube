using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionSceneHub : MonoBehaviour
{
    [SerializeField] private HubManager hb;
    private void OnTriggerEnter(Collider other)
    {
        if (!hb.asProc)
            hb.TransitionIn();
    }
}
