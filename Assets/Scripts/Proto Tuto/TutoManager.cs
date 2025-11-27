using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutoManager : MonoBehaviour
{
    public static TutoManager Instance { get; private set; }
    [SerializeField] private Image img;
    public bool asProc = false;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(Instance);
    }

    public void TransitionIn()
    {
        asProc = true;
        img.DOFade(1, 1).OnComplete(
            () =>
            {
                SceneManager.LoadScene("ProtoBossBattle");
                TransitionOut();
            }
        );
    }

    public void TransitionOut()
    {
        img.DOFade(0, 1);
    }
}
