using TMPro;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class SceneTransition : MonoBehaviour
{
    public string sceneName;
    public TextMeshProUGUI enterSceneText;
    public GameObject uiTransi;
    public Button yesButton;
    public Button noButton;
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            yesButton.onClick.RemoveAllListeners();
            noButton.onClick.RemoveAllListeners();
            enterSceneText.text = "";
            enterSceneText.text = sceneName + " ?";
            Player.Instance.playerInput.SwitchCurrentActionMap("UI");
            uiTransi.SetActive(true);
            yesButton.onClick.AddListener(GoIntoScene);
            noButton.onClick.AddListener(RefuseEnterScene);
            EventSystem.current.SetSelectedGameObject(yesButton.gameObject);
        }
    }

    public void GoIntoScene()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void RefuseEnterScene()
    {
        uiTransi.SetActive(false);
        Player.Instance.playerInput.SwitchCurrentActionMap("Gameplay");  
    }


}
