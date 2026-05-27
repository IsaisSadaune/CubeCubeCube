using UnityEngine;
using UnityEngine.UI;

public class AudioSlidersScript : MonoBehaviour
{
    [SerializeField] private Slider musicSlider, sfxSlider; 
    void Start()
    {
        musicSlider.value = AudioManager.Instance.globalMusicVolume;
        sfxSlider.value = AudioManager.Instance.globalSfxVolume;
    }

    public void SliderMusicChangeValue()
    {
        AudioManager.Instance.globalMusicVolume = musicSlider.value;

    }

    public void SliderSfxChangeValue()
    {
        AudioManager.Instance.globalSfxVolume = sfxSlider.value;
    }
}
