using UnityEngine.UI;
using UnityEngine;
using MoreMountains.Feedbacks;

public class CreditsScript : MonoBehaviour
{
    [SerializeField] private Button continueButton;
    [SerializeField] MMF_Player exitAnim;

    public void SelectButton()
    {
        continueButton.Select();
    }

    public void OnContinueButton()
    {
        exitAnim.PlayFeedbacks();
    }
}
