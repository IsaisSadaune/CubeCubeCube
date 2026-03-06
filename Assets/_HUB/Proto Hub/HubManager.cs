
using UnityEngine;
using UnityEngine.SceneManagement;


public class HubManager : MonoBehaviour
{
    public bool asProc = false;
    

    [ContextMenu("transition test")]

    void Start()
    {
        
    }
    public void TransitionIn()
    {
        SceneManager.LoadScene("Tutorial Scene");
    }

    
}