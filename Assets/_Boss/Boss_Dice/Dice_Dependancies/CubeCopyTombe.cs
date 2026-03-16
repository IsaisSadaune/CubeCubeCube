using UnityEngine;
using DG.Tweening;

public class CubeCopyTombe : MonoBehaviour
{

    public void Falling(float endYPos, float time)
    {
        transform.DOMoveY(endYPos, time).SetEase(Ease.InOutQuint).OnComplete( () => Destroy(gameObject));
    }
}
