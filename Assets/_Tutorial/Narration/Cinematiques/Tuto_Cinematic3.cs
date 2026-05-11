using DG.Tweening;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Tuto_Cinematic3 : CinematicPlayer
{
    [SerializeField] List<Collider> WallsToCreatePermanently;
    [SerializeField] List<GameObject> ZonesToRemovePermanently;
    [SerializeField] List<GameObject> ZonesToRemoveTemporary;
    [SerializeField] List<Collider> WallsToRemoveAtTheEnd;

    public override void PlayCinematic()
    {
        var s = DOTween.Sequence();
        foreach(var z in WallsToCreatePermanently)
            z.gameObject.SetActive(true);
        foreach (var z in ZonesToRemovePermanently)
            s.Join(z.transform.DOScale(0, 1f));
        foreach (var z in ZonesToRemoveTemporary)
            s.Join(z.transform.DOScale(0, 1f));
    }

    public void UnlockZone()
    {
        foreach (var z in ZonesToRemoveTemporary)
            z.transform.DOScale(1, 1f);
        foreach(var z in WallsToRemoveAtTheEnd)
            z.gameObject.SetActive(false);
    }


}
