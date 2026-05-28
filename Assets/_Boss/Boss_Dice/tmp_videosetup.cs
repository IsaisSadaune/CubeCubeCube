using UnityEngine;
using UnityEngine.Video;

public class tmp_videosetup : MonoBehaviour
{
    [SerializeField] Boss_Variables bv;
    [SerializeField] VideoPlayer video;
    void Update()
    {
        video.targetCameraAlpha = 0f;
        if(bv.HP<75)
        {
            video.targetCameraAlpha = 1f - bv.HP / 75f;
        }
    }
}
