using UnityEngine;

public class AmbiantSound : MonoBehaviour
{
    AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
        AudioManager.Instance.ChangeSfxVolume += UpdateSfxVolume;
    }

    void UpdateSfxVolume()
    {
        source.volume = 1 * AudioManager.Instance.globalSfxVolume;
    }

    void OnDestroy()
    {
        AudioManager.Instance.ChangeSfxVolume -= UpdateSfxVolume;
    }
}
