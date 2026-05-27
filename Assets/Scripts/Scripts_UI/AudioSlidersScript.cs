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
        Debug.Log("New music value : " + musicSlider.value);
    }
}
