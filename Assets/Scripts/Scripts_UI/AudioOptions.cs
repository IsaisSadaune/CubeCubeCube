using UnityEngine;

public class AudioOptions : MonoBehaviour
{
    public UnityEngine.UI.Slider sliderToSelect;

    public void OnEnable()
    {
        sliderToSelect.Select();
    }

    public void BackButtonPressed()
    {
        Debug.Log("Code pas encore ajoute");
    }
}
