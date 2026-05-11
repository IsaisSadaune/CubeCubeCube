using DG.Tweening;
using UnityEngine;

public class Tuto_Cinematic2 : CinematicPlayer
{
    [SerializeField] private GameObject CubeInf;
    [SerializeField] private Player player;
    [SerializeField] private GameObject dialogue;
    [SerializeField] private GameObject dialogue2;

    public override void PlayCinematic()
    {

        Sequence s = DOTween.Sequence();
        //Le joueur ne peut pas bouger
        s.Append(CubeInf.transform.DOMoveY(3.4f, 1).SetEase(Ease.OutBack));
        s.Join(dialogue.transform.DOMoveY(8.4f, 1).SetEase(Ease.OutBack));
        s.Join(dialogue2.transform.DOMoveY(3.4f, 1).SetEase(Ease.OutBack));
        //Effet Glitch à ajouter
        s.Append(CubeInf.transform.DOMoveX(18, 0.5f).SetEase(Ease.InBack));
        s.Join(dialogue2.transform.DOMoveX(18, 0.5f).SetEase(Ease.InBack));
        s.Append(CubeInf.transform.DOMoveZ(35f,1f).SetEase(Ease.InBack))
            .OnComplete(() => CubeInf.SetActive(false));

        //Le joueur peut bouger
        throw new System.NotImplementedException();
    }
}
