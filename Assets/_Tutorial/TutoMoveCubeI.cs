using DG.Tweening;
using UnityEngine;

public class TutoMoveCubeI : MonoBehaviour
{
    [SerializeField] private GameObject CubeI;
    private float timeToDisapear = 8f;



    [ContextMenu("disapear")]
    public void CubeDisapear()
    {
        CubeI.transform.DOMoveY(transform.position.y - 100, timeToDisapear);
    }
}
