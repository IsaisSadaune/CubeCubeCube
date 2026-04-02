using UnityEngine;
using UnityEngine.UIElements;

public class SkyboxRotate : MonoBehaviour
{
    private Material _skybox;
    public float _rotationSpeed = 2f;

    void Start()
    {
        _skybox = Instantiate(RenderSettings.skybox);
        RenderSettings.skybox = _skybox;
    }

    void Update()
    {
        RotateSkybox(Time.timeSinceLevelLoad * _rotationSpeed);
    }

    private void RotateSkybox(float angle)
    {
        _skybox.SetFloat("_Rotation", angle);
    }
}
