using UnityEngine;
using Unity.Cinemachine;

public class CameraShakeScript : CinemachineImpulseSource
{
    void Update()
    {
        if(Input.GetKey(KeyCode.Backspace))
        {
            Debug.Log("Try shake");
            GenerateImpulse(); 
        }        
    }
}
