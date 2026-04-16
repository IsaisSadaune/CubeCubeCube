using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtonsScript : MonoBehaviour
{
    public void ContinueToHubButtonPressed()
    {
        Debug.Log("Envoyer le joueur au HUB et sauvegarder le jeu");
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
