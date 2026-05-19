using UnityEngine;

public class AudioOptions : MonoBehaviour
{
    bool musicSelected;
    public void onMusicSelected()
    {
        musicSelected = true;
    }

    void Update()
    {
        if(musicSelected)
        {
            
        }
    }
}
