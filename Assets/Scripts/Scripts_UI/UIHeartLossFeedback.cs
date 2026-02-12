using MoreMountains.Feedbacks;
using UnityEngine;
using UnityEngine.UI;

public class UIHeartLossFeedback : MonoBehaviour
{
    private Image image;
    [SerializeField] private Color startColor;
    [SerializeField] private MMF_Player hpLossFeedback;

    private void Start()
    {
        hpLossFeedback = GetComponent<MMF_Player>();
        image = GetComponent<Image>();
    }

    private void OnEnable()
    {
        Debug.Log("Awake");
        image.color = startColor;
    }

    public void TriggerHPLossFeedback()
    {
        hpLossFeedback.PlayFeedbacks();
    }
}
