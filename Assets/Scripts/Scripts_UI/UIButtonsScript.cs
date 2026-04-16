using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtonsScript : MonoBehaviour
{

    public void SendToSceneDependingGameState()
    {
        //Check si le joueur se trouve dans le HUB
        if (SceneManager.GetActiveScene().name == "Nom de la scene HUB 1" || SceneManager.GetActiveScene().name == "Nom de la scene HUB 2" 
            || SceneManager.GetActiveScene().name == "Nom de la scene HUB 3")
            SceneManager.LoadScene("MainMenuScene");
        else
        {
            switch (GameManager_Offi.Instance.act)
            {
                case 0:
                    //SceneManager.LoadScene(tutoSceneName);
                    break;

                case (GameManager_Offi.GameProgression)1:
                    //SceneManager.LoadScene(hub1SceneName);
                    break;

                case (GameManager_Offi.GameProgression)2:
                    //SceneManager.LoadScene(hub2SCeneName);
                    break;

                case (GameManager_Offi.GameProgression)3:
                    //SceneManager.LoadScene(hubFinalSceneName);
                    break;

                default:
                    //SceneManager.LoadScene(tutoSceneName);
                    break;
            }
        }
    }

    public void RestartSceneButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGameButton()
    {
        Application.Quit();
    }
}
