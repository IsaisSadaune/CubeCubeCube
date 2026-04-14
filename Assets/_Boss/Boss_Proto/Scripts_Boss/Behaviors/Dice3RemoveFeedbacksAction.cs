using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using System.Collections.Generic;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Dice3_RemoveFeedbacks", story: "Remove [Feedback1] [Feedback2] [Feedback3] [Feedback4] [Feedback5]", category: "Action", id: "47f350620238a9db3440c1645bb3a702")]
public partial class Dice3RemoveFeedbacksAction : Action
{
    [SerializeReference] public BlackboardVariable<PreviFeedbackScript> Feedback1;
    [SerializeReference] public BlackboardVariable<PreviFeedbackScript> Feedback2;
    [SerializeReference] public BlackboardVariable<PreviFeedbackScript> Feedback3;
    [SerializeReference] public BlackboardVariable<PreviFeedbackScript> Feedback4;
    [SerializeReference] public BlackboardVariable<PreviFeedbackScript> Feedback5;
    protected override Status OnStart()
    {
        if(Feedback1.Value != null && Feedback1.Value.gameObject.activeSelf)
            Feedback1.Value.HardStop();
        if(Feedback2.Value != null && Feedback2.Value.gameObject.activeSelf)
            Feedback2.Value.HardStop();
        if(Feedback3.Value != null && Feedback3.Value.gameObject.activeSelf)
            Feedback3.Value.HardStop();
        if(Feedback4.Value != null && Feedback4.Value.gameObject.activeSelf)
            Feedback4.Value.HardStop();
        if(Feedback5.Value != null && Feedback5.Value.gameObject.activeSelf)
            Feedback5.Value.HardStop();

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

