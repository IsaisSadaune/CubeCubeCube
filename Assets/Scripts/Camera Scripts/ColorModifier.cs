using UnityEngine;
using DG.Tweening;
public class ColorModifier : MonoBehaviour
{
    private Sequence s;
    public Color[] colors;
    private int index = 0;
    private void Start()
    {
        Camera.main.DOColor(colors[0], 15f).SetLoops(-1);
    }



}
