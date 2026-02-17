using System.Collections.Generic;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using Unity.VisualScripting;


[GeneratePropertyBag]
[NodeDescription(name: "InstantiateAsteroids", story: "Instantiate [n] [AsteroïdPrefab] in [Asteroïds] at [Position]", category: "Action", id: "94363bcb777e165269f70cb2d1ee4227")]
public partial class InstantiateAsteroidsAction : Action
{
    [SerializeReference] public BlackboardVariable<int> N;
    [SerializeReference] public BlackboardVariable<GameObject> AsteroïdPrefab;
    [SerializeReference] public BlackboardVariable<List<GameObject>> Asteroïds;
    [SerializeReference] public BlackboardVariable<List<GameObject>> Position;

    List<Vector3> possiblePosition = new List<Vector3>();
    protected override Status OnStart()
    {
        for(int i = 0; i< Position.Value.Count; i++)
        {
            possiblePosition.Add(Position.Value[i].transform.position);
        }

        for(int i = 0; i < N; i++)
        {
            int rdm = Random.Range(0, possiblePosition.Count);
            Vector3 pos = possiblePosition[rdm];
            possiblePosition.Remove(possiblePosition[rdm]);
            GameObject j = RetroBoss.Instance.asteroidPattern(AsteroïdPrefab.Value, pos);
            Asteroïds.Value.Add(j);
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

