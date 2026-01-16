using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using Unity.VisualScripting;
using DG.Tweening;
using System.Collections.Generic;
using NUnit.Framework.Constraints;

[GeneratePropertyBag]
[NodeDescription(name: "ThrowCube", story: "[Self] Throw [n] [Cube] towards [Player]", category: "Action", id: "4e6fe6fea30c21692522a727dc985980")]
public partial class ThrowCubeAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    [SerializeReference] public BlackboardVariable<int> N;
    [SerializeReference] public BlackboardVariable<GameObject> Cube;
    [SerializeReference] public BlackboardVariable<Transform> Player;
    RubiksBoss rubiksCube;
    Player player;
    List<GameObject> cubesChilds = new List<GameObject>();
    List<GameObject> throwingCubes = new List<GameObject>();
    protected override Status OnStart()
    {
        player = Player.Value.GetComponent<Player>();
        rubiksCube = Self.Value.GetComponent<RubiksBoss>();

        for(int i = 0; i < rubiksCube.cubes.Count; i++)
        {
            cubesChilds.Add(rubiksCube.cubes[i]);
        }
        
        for(int i = 0; i < N.Value ; i++)
        {
            int rdmCube = Random.Range(0, cubesChilds.Count);
            throwingCubes.Add(cubesChilds[rdmCube]);
            cubesChilds.Remove(cubesChilds[rdmCube]);
        }
        //Faire plusieurs nodes, référencer la liste dans le blackboard
        //Utiliser la même liste dans les 2 nodes.

        for(int i = 0; i < throwingCubes.Count; i++)
        {
            int rdmCube = Random.Range(0, throwingCubes.Count);
            Cube.Value = throwingCubes[rdmCube];
            throwingCubes.Remove(throwingCubes[rdmCube]);


            Cube.Value.transform.DOMoveY(2f, 1f)
            .OnComplete(() => 
            {
            Cube.Value.transform.DOMove(new Vector3(Player.Value.transform.position.x + player.direction.x * 2,
            Player.Value.transform.position.y + player.direction.y + 1* 2,
            Player.Value.transform.position.z + player.direction.z * 2 ), 0.2f);
            });
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

