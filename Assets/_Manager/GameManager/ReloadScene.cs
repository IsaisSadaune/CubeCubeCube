using MoreMountains.Tools;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadScene : MonoBehaviour
{

    public void Awake()
    {
        Time.timeScale = 1;
    }
    public void ReloadTuto()
    {
        var actualScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(actualScene.name);
    }
}
