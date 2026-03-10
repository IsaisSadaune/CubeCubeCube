using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using System.Collections.Generic;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "DiceShowFace", story: "Show [Number] from [Faces] on Pattern", category: "Action", id: "efc6b69891f1b18f1bf2b8d7bda568e3")]
public partial class DiceShowFaceAction : Action
{
    [SerializeReference] public BlackboardVariable<int> Number;
    [SerializeReference] public BlackboardVariable<List<GameObject>> Faces;

    private float _timer;
    private const float Duration = ConstantsDice.timeShowingNumber;

    protected override Status OnStart()
    {
        Faces.Value[Number.Value-1].SetActive(true);
        _timer = 0f;
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        _timer += Time.deltaTime;
        if(_timer > Duration)
            return Status.Success;
        return Status.Running;
    }

    protected override void OnEnd()
    {
        Faces.Value[Number.Value - 1].SetActive(false);
    }

}

