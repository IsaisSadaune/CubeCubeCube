using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

public class WallConditional : MonoBehaviour
{
    private float upWallDistance = 1f;
    private float timeToMove = 0.5f;
    [SerializeField] private Transform newRespawnPoint;
    [SerializeField] private RespawnBoxScript rbs;
    [SerializeField] private bool hasProc = false;

    [SerializeField] private List<Transform> itemsToRemove;
    [SerializeField] private List<Transform> itemsToActivate;


    //[ContextMenu("SetWall")]
    //public void SetWall()
    //{
    //    if (!WallSet)
    //    {
    //        wall.transform.DOMoveY(wall.transform.position.y + upWallDistance, timeToMove);
    //        rbs.SetNewSpawnPoint(newRespawnPoint);
    //        WallSet = true;
    //    }
    //}

    [ContextMenu("Proc")]
    public void RemoveZone()
    {
        if (!hasProc)
        {
            foreach (Transform t in itemsToRemove)
            {

                t.transform.DOScale(0, timeToMove);
                rbs.SetNewSpawnPoint(newRespawnPoint);
                hasProc = true;
            }
            foreach (Transform t in itemsToActivate)
            {
                t.gameObject.SetActive(true);
            }
        }
    }

}
