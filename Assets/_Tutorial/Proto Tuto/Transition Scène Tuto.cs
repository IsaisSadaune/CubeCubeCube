using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionScèneTuto : MonoBehaviour
{
    public UIButtonsScript uib;

    private void OnTriggerEnter(Collider other)
    {
        uib.SendToHUBDependingGameState();
    }
}
