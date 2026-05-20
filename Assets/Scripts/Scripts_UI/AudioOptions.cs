using Unity.AppUI.UI;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class AudioOptions : MonoBehaviour
{
    public UnityEngine.UI.Button buttonToSelect;
    public UnityEngine.UI.Slider sliderMusic;
    public UnityEngine.UI.Slider sliderSFX;
    AudioManager audioManager;

    public void OnEnable()
    {
        buttonToSelect.Select();
    }
    void Start()
    {
        audioManager = AudioManager.Instance;
    }
    public void onMusicSelected()
    {
        sliderMusic.Select();
    }
    public void onSFXSelected()
    {
        sliderSFX.Select();
    }

    void Update()
    {
        audioManager.globalSfxVolume = sliderSFX.value;
    }
}
