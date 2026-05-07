using System.Collections;
using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioSource gameplayMusic;

    void Start()
    {
        gameplayMusic = GetComponent<AudioSource>();
    }

    public void PitchIncreasing()
    {
        gameplayMusic.pitch = 1f;
    }

    public void PitchDecreasing()
    {
        StartCoroutine(PitchDecreaser());
    }

    IEnumerator PitchDecreaser()
    {
        while(gameplayMusic.pitch > 0f)
        {
            gameplayMusic.pitch -= 0.05f;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
