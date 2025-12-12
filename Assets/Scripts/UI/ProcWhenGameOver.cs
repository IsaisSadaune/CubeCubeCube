using DG.Tweening;
using UnityEngine;

public class ProcWhenGameOver : MonoBehaviour
{
    [ContextMenu("test")]
    public void OnDeathPlayer()
    {
        transform.DOShakeScale(10f);
        transform.DOBlendableScaleBy(Vector3.one * 10f, 10f);
        transform.DOScale(10f, 10f);
    }
}
