using System;
using Unity.Behavior;
using UnityEngine;
using DG.Tweening;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using DG.Tweening.Core;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Dice_6RotateTwice", story: "[Boss] Go to [Position] while [mode] rotates", category: "Action", id: "0966725af67a6a44d144b6d591d7ac0a")]
public partial class Dice6RotateTwiceAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Boss;
    [SerializeReference] public BlackboardVariable<Transform> Position;
    [SerializeReference] public BlackboardVariable<GameObject> Mode;
    private Sequence s;
    private Sequence r;

    private float time = 0.25f;
    protected override Status OnStart()
    {
        s = DOTween.Sequence();
        r = DOTween.Sequence();


        Quaternion rollDir = GetDiceRollRotation(
            Mode.Value.transform,
            Boss.Value.transform.position,
            Position.Value.transform.position
        );
        Quaternion targetRotation = Mode.Value.transform.localRotation * rollDir;

        s.Append(Boss.Value.transform.DOMove(Position.Value.transform.position, time).SetEase(Ease.OutQuint));
        r.Append(Mode.Value.transform.DOLocalRotateQuaternion(targetRotation, time).SetEase(Ease.OutQuint));
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        if(!s.IsPlaying() && !r.IsPlaying())
            return Status.Success;
        return Status.Running;
    }


    //Je teste Claude pour cette fonction, si elle est la quand vous lisez ce message c'est que ça marche bien
    public static Quaternion GetDiceRollRotation(Transform diceTransform, Vector3 currentPos, Vector3 targetPos)
    {
        Vector3 direction = (targetPos - currentPos).normalized;

        // On arrondit pour éviter les erreurs de virgule flottante
        float x = Mathf.Round(direction.x);
        float z = Mathf.Round(direction.z);

        // Rotation de 90° définie en ESPACE MONDE
        Quaternion worldRotation;

        if (z > 0)
            worldRotation = Quaternion.Euler(90, 0, 0);
        else if (z < 0)
            worldRotation = Quaternion.Euler(-90, 0, 0);
        else if (x > 0)
            worldRotation = Quaternion.Euler(0, 0, -90);
        else if (x < 0)
            worldRotation = Quaternion.Euler(0, 0, 90);
        else
            return Quaternion.identity;

        // On convertit en espace local du dé avant de retourner
        Quaternion localRotation = Quaternion.Inverse(diceTransform.rotation) * worldRotation * diceTransform.rotation;

        return localRotation;
    }
}

