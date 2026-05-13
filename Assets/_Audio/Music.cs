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
        StartCoroutine(PitchDecreaser(0f));
    }

    public void PitchDeathLevel()
    {
        StartCoroutine(PitchDecreaser(0.4f));
    }

    IEnumerator PitchDecreaser(float pitchTarget)
    {
        while(gameplayMusic.pitch > pitchTarget)
        {
            gameplayMusic.pitch -= 0.05f;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
