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
            s.Join(z.transform.DOMoveY(z.transform.position.y - 35f, 1f));
        foreach (var z in ZonesToRemoveTemporary)
            s.Join(z.transform.DOMoveY(z.transform.position.y - 35f, 1f));
    }

    public virtual void UnlockZone()
    {
        foreach (var z in ZonesToRemoveTemporary)
        {
            //var tmp = z.transform.position+ new Vector3(0f,35f,0f);
            z.transform.DOMoveY(z.transform.position.y + 35f, 1f);
        }
        foreach (var z in WallsToRemoveAtTheEnd)
            z.gameObject.SetActive(false);
    }

    public virtual void ActivateGlitchToHit()
    {

    }

}
