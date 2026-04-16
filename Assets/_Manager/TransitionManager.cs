using UnityEngine;
using UnityEngine.SceneManagement;

public static class TransitionManager
{
    public static void GoToHub() => SceneManager.LoadScene("HubV1", LoadSceneMode.Single);
    public static void GoToBoss1() => SceneManager.LoadScene("Scene_DiceBoss_Actual", LoadSceneMode.Single);
}
