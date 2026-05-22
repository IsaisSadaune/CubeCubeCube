using MoreMountains.Feedbacks;
using UnityEngine;
using UnityEngine.UI;

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
