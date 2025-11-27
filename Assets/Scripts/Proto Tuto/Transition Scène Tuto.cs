using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionScèneTuto : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if(!TutoManager.Instance.asProc)
            TutoManager.Instance.TransitionIn();
    }
}
