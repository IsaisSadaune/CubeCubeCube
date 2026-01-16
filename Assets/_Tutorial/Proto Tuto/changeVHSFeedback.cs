using DG.Tweening;
using UnityEngine;
using UnityEngine.Rendering;

public class changeVHSFeedback : MonoBehaviour
{
    [SerializeField] private Volume volume;
    [SerializeField] private VHSProVolumeComponent volumeComponent;
    public float min, max, time; 
    private void Start()
    {
        volume.profile.TryGet<VHSProVolumeComponent>(out volumeComponent);
        min = volumeComponent.bleedAmount.value;
    }
    private void Update()
    {
        DOTween.To( () => volumeComponent.bleedAmount.value, x=> volumeComponent.bleedAmount.value = x, max, time);
    }
}
