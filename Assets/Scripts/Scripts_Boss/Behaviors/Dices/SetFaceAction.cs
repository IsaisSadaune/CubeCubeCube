using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "SetFace", story: "Set Face [Boss1Face] and [Boss2Face]", category: "Action", id: "4e288a2182c04e9a651ef27507f26a9f")]
public partial class SetFaceAction : Action
{
    [SerializeReference] public BlackboardVariable<NumberDice> Boss1Face;
    [SerializeReference] public BlackboardVariable<NumberDice> Boss2Face;

    protected override Status OnStart()
    {
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        int two = UnityEngine.Random.Range(1, 7);
        if (two == 2)
        {
            Boss1Face.Value = NumberDice.Two;
            Boss2Face.Value = NumberDice.Two;
        }
        else
        {
            int dice1 = UnityEngine.Random.Range(0, 5);
            int dice2 = UnityEngine.Random.Range(0, 5);
            if (dice1 >= 1) dice1++;
            if (dice2 >= 1) dice2++;
            Boss1Face.Value = (NumberDice)dice1;
            Boss2Face.Value = (NumberDice)dice2;

        }


            Debug.Log("Dé 1 : " + Boss1Face.Value + " | Dé 2 : " + Boss2Face.Value);    
            return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

