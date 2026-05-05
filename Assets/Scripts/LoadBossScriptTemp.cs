using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadBossScriptTemp : MonoBehaviour
{
    public string sceneToLoad;
    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
