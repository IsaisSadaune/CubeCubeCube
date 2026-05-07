using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtonsScript : MonoBehaviour
{

    public void SendToHUBDependingGameState()
    {
        Time.timeScale = 1f;
        switch (GameManager_Offi.Instance.act)
        {
            case 0:
                SceneManager.LoadScene("Final_Hub2");
                break;

            case (GameProgression)1:
                SceneManager.LoadScene("Final_Hub2");
                break;

            case (GameProgression)2:
                SceneManager.LoadScene("Final_Hub2");
                break;

            case (GameProgression)3:
                SceneManager.LoadScene("Final_Hub2");
                break;

            default:
                SceneManager.LoadScene("Final_Hub2");
                break;
        }
    }

    public void SendToGivenScene(string sceneToSendTo)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneToSendTo);
    }

    public void RestartSceneButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGameButton()
    {
        Time.timeScale = 1f;
        //Check si le joueur se trouve dans le HUB
        if (SceneManager.GetActiveScene().name == "Final_Hub1" || SceneManager.GetActiveScene().name == "Final_Hub2" || SceneManager.GetActiveScene().name == "Final_Hub3")
        {
            SceneManager.LoadScene("MainMenuScene");
            return;
        }
        else if (SceneManager.GetActiveScene().name == "")
            SendToHUBDependingGameState();
        else
            Application.Quit();
    }
}