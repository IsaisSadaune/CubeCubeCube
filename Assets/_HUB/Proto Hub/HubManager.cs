using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HubManager : MonoBehaviour
{
    public bool asProc = false;
    public GameObject[] hubPrefabs;
    public Transform hubPos;
    public int hubPhase = 0;

    [ContextMenu("transition test")]
    public void TransitionIn()
    {
                SceneManager.LoadScene("Tutorial Scene");
    }

    //Lancer la fonction au moment de Load la scène HUB 
    public void UpdateHub()
    {
        switch(hubPhase)
        {
            case 0 :
                Instantiate(hubPrefabs[hubPhase], hubPos.position, Quaternion.identity);
            break;
            case 1 :
                Instantiate(hubPrefabs[hubPhase], hubPos.position, Quaternion.identity);
            break;
            case 2 :
                Instantiate(hubPrefabs[hubPhase], hubPos.position, Quaternion.identity);
            break;
        }
    }
}