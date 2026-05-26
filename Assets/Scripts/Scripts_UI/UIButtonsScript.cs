using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIButtonsScript : MonoBehaviour
{

    public void Awake()
    {

    }
    public void SendToHUBDependingGameState()
    {
        Time.timeScale = 1f;
        switch (GameManager_Offi.Instance.act)
        {
            case 0:
                SendToGivenScene("TutorialScene");
                break;

            case (GameProgression)1:
                SendToGivenScene("Final_Hub1");
                break;

            case (GameProgression)2:
                SendToGivenScene("Final_Hub2");
                break;

            case (GameProgression)3:
                SendToGivenScene("Final_Hub2");
                break;

            default:
                SendToGivenScene("TutorialScene");
                break;
        }
    }

    public void SendToGivenScene(string sceneToSendTo)
    {
        Time.timeScale = 1f;
        GameManager_Offi.Instance.LoadCoroutineScene(sceneToSendTo);
        //SceneManager.LoadScene(sceneToSendTo);
    }

    public void RestartSceneButton()
    {
        SendToGivenScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGameButton()
    {
        Time.timeScale = 1f;
        //Check si le joueur se trouve dans le HUB
        if (SceneManager.GetActiveScene().name == "Final_Hub1" || SceneManager.GetActiveScene().name == "Final_Hub2" || SceneManager.GetActiveScene().name == "TutorialScene")
        {
            SendToGivenScene("MainMenuScene");
            return;
        }
        else if (SceneManager.GetActiveScene().name == "RetroBoss" || SceneManager.GetActiveScene().name == "Scene_DiceBoss_Actual")
            SendToHUBDependingGameState();
        else
            Application.Quit();
    }
}