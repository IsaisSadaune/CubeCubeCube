using UnityEngine;

public class LeavingTutorial : MonoBehaviour
{
    [SerializeField] private UIButtonsScript transi;
    public void ImLeavinTuto()
    {
        GameManager_Offi.Instance.TutoFinished();
        transi.SendToHUBDependingGameState();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            ImLeavinTuto();
    }
}
