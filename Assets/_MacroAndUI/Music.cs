using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioSource gameplayMusic;

    public void LaunchMusic()
    {
        gameplayMusic.Play();
    }
}
