using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "SetAestheticNumber", story: "[Aesthetic] set to [LastPattern]", category: "Action", id: "f09465d95e3a92470bd34b58a0c1b352")]
public partial class SetAestheticNumberAction : Action
{
    [SerializeReference] public BlackboardVariable<AestheticManager> Aesthetic;
    [SerializeReference] public BlackboardVariable<PatternDiceEnum> LastPattern;
    protected override Status OnStart()
    {
        SetAesthetic();
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        return Status.Success;
    }

    protected override void OnEnd()
    {
    }


    private void SetAesthetic()
    {
        switch (LastPattern.Value)
        {
            case PatternDiceEnum.One :
                Aesthetic.Value.Set1();
                break;
            case PatternDiceEnum.Two :
                Aesthetic.Value.Set2();
                break;
            case PatternDiceEnum.Three :
                Aesthetic.Value.Set3();
                break;
            case PatternDiceEnum.Four :
                Aesthetic.Value.Set4();
                break;
            case PatternDiceEnum.Five :
                Aesthetic.Value.Set5();
                break;
            case PatternDiceEnum.Six :
                Aesthetic.Value.Set6();
                break;
        }
    }
}