using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HubManager : MonoBehaviour
{
    public bool asProc = false;

    [ContextMenu("transition test")]
    public void TransitionIn()
    {
                SceneManager.LoadScene("Tutorial Scene");
    }
}