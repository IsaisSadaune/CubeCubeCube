using System;
using DG.Tweening;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using Unity.Collections;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "CubesAway", story: "[Self] going Up then Throw Cubes away", category: "Action", id: "c5189bd014afaeaccae8ecb3e17f52ec")]
public partial class CubesAwayAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;

    RubiksBoss rubiks;
    bool next = false;
    protected override Status OnStart()
    {
        rubiks = Self.Value.GetComponent<RubiksBoss>();
        Self.Value.transform.DOMoveY(1f, 1f)
        .OnComplete(() =>
        {

            for(int i = 0; i < rubiks.cubes.Count; i++)
            {
            Vector3 initPos = rubiks.cubes[i].transform.position; 
            Vector3 direction = new Vector3(rubiks.cubes[i].transform.position.x - Self.Value.transform.position.x,
            rubiks.cubes[i].transform.position.y - Self.Value.transform.position.y + 1.05f,
            rubiks.cubes[i].transform.position.z - Self.Value.transform.position.z);
        
            rubiks.cubes[i].transform.DOMove(direction * 5f, 2f);
            }
            });
        
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

