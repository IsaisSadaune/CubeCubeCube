using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

public class RoomToLock : RoomManager
{
    [SerializeField] List<Collider> WallsToCreatePermanently;
    [SerializeField] List<GameObject> ZonesToRemovePermanently;
    [SerializeField] List<GameObject> ZonesToRemoveTemporary;
    [SerializeField] List<Collider> WallsToRemoveAtTheEnd;


    public override void EnteredInRoom()
    {
        var s = DOTween.Sequence();
        foreach (var z in WallsToCreatePermanently)
            z.gameObject.SetActive(true);
        foreach (var z in ZonesToRemovePermanently)
            s.Join(z.transform.DOMoveY(z.transform.position.y - 35f, 1f));
        foreach (var z in ZonesToRemoveTemporary)
            s.Join(z.transform.DOMoveY(z.transform.position.y - 35f, 1f));
    }

    public virtual void UnlockZone()
    {
        Sequence s = DOTween.Sequence();
        foreach (var z in ZonesToRemoveTemporary)
        {
            //var tmp = z.transform.position+ new Vector3(0f,35f,0f);
            s.Join(z.transform.DOMoveY(z.transform.position.y + 35f, 1f));
        }
        s.OnComplete(() =>
        {
            foreach (var z in WallsToRemoveAtTheEnd)
                z.gameObject.SetActive(false);
        }
        );
    }


}
