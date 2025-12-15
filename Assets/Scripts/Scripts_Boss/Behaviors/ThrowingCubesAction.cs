using System;
using DG.Tweening;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "ThrowingCubes", story: "[Cube] Throw Childs Away in Seconds", category: "Action", id: "c13b1bfac2204e9a8a2f1af0c57aa518")]
public partial class ThrowingCubesAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Cube;
    private bool test = false;
    RubiksBoss rubiks;
    
    protected override Status OnStart()
    {
        rubiks = Cube.Value.GetComponent<RubiksBoss>();
        Debug.Log("b");
        
        for(int i = 0; i < rubiks.cubes.Count; i++)
        {
            Debug.Log("a");
            Vector3 initPos = rubiks.cubes[i].transform.position; 
            Vector3 direction = new Vector3(rubiks.cubes[i].transform.position.x - Cube.Value.transform.position.x,
            rubiks.cubes[i].transform.position.y - Cube.Value.transform.position.y + 1.05f,
            rubiks.cubes[i].transform.position.z - Cube.Value.transform.position.z);
            
            

            Sequence pattern = DOTween.Sequence();

            pattern.Append(rubiks.cubes[i].transform.DOMove(direction * 20f, 2f)).Join(rubiks.cubes[i].transform.DORotate(360*Vector3.one, 2f, RotateMode.LocalAxisAdd))
            .Append(rubiks.cubes[i].transform.DOMove(initPos, 1f)).Join(rubiks.cubes[i].transform.DORotate(360*Vector3.one, 1f, RotateMode.LocalAxisAdd));
               
        }
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

