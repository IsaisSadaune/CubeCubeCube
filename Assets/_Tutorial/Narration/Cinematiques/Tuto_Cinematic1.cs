using DG.Tweening;
using System.Collections;
using UnityEngine;

public class Tuto_Cinematic1 : RoomManager
{
    [SerializeField] private GameObject CubeInf1;
    [SerializeField] private Player player;
    [SerializeField] private GameObject dialogue;

    public override void EnteredInRoom()
    {
        //Sequence s = DOTween.Sequence();
        ////Le joueur ne peut pas bouger
        //s.Append(CubeInf1.transform.DOMoveY(15f, 1).SetEase(Ease.OutBack));
        //s.AppendCallback(() => dialogue.SetActive(true));
        //s.AppendInterval(1f);
        //s.AppendCallback(() => dialogue.SetActive(false));
        //s.AppendInterval(0.5f);
        ////Cube Disparait (leger glitch) et se désactive
        //s.Append(CubeInf1.transform.DOMoveZ(-25f, 1).SetEase(Ease.InBack))
        //    .OnComplete(() => CubeInf1.SetActive(false));

        //Test 2
        Sequence s = DOTween.Sequence();
        //Le joueur ne peut pas bouger
        s.Append(CubeInf1.transform.DOMoveY(15f, 1).SetEase(Ease.OutBack));
        s.Join(dialogue.transform.DOMoveY(15f,1).SetEase(Ease.OutBack));
        s.AppendInterval(1.5f);
        //Effet Glitch à ajouter
        s.Append(CubeInf1.transform.DOMoveZ(-25f, 1).SetEase(Ease.InBack))
            .OnComplete(() => CubeInf1.SetActive(false));

        //Le joueur peut bouger
        throw new System.NotImplementedException();
    }
}
