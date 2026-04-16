using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtonsScript : MonoBehaviour
{
    
    public void MainMenuPlayButtonPressed()
    {

    }
    public void SendToSceneButton(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void RestartSceneButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitToHubButton()
    {
        Debug.Log("Envoyer le joueur au HUB");
    }
}
