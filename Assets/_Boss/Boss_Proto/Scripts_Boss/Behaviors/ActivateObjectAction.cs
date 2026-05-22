using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Activate Object", story: "Activate [Feedback] for [x] seconds", category: "Action", id: "f1ca201fdf85751f16e9acaa27bebd16")]
public partial class ActivateObjectAction : Action
{
    [SerializeReference] public BlackboardVariable<PreviFeedbackScript> Feedback;
    [SerializeReference] public BlackboardVariable<float> X;
    protected override Status OnStart()
    {
        Feedback.Value.SetFeedback(0.5f,0.5f,X.Value);
        Feedback.Value.gameObject.SetActive(true);
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

