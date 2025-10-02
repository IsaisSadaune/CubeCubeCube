using UnityEngine;

public class SwitchCameraScript : MonoBehaviour
{
    public GameObject[] camerasArray;
    public int cameraToSetActive;
    private int currentlyEnabledCamera;

    private void Start()
    {
        currentlyEnabledCamera = cameraToSetActive - 1;

        camerasArray[currentlyEnabledCamera].gameObject.SetActive(true);

        for (int i = 0; i < camerasArray.Length; i++)
            if (i != currentlyEnabledCamera)
                camerasArray[i].gameObject.SetActive(false);
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            SwapCamera();
        }
    }

    private void SwapCamera()
    {
        if (camerasArray != null && camerasArray.Length > 0)
        {
            camerasArray[currentlyEnabledCamera].gameObject.SetActive(false);
            currentlyEnabledCamera = (currentlyEnabledCamera + 1) % camerasArray.Length;
            camerasArray[currentlyEnabledCamera].gameObject.SetActive(true);
        }
    }
}
