using Unity.AppUI.UI;
using Unity.VisualScripting;
using UnityEngine;

public class AudioOptions : MonoBehaviour
{
    bool musicSelected;
    public UnityEngine.UI.Button buttonToSelect;
    public UnityEngine.UI.Slider sliderMusic;
    public UnityEngine.UI.Slider sliderSFX;
    public void OnEnable()
    {
        buttonToSelect.Select();
    }
    public void onMusicSelected()
    {
        musicSelected = true;
        sliderMusic.Select();
    }
    public void onSFXSelected()
    {
        sliderSFX.Select();
    }
}
