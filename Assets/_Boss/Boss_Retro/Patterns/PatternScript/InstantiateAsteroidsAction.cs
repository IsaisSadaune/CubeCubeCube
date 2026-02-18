using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[GeneratePropertyBag]
[NodeDescription(name: "InstantiateAsteroids", story: "Instantiate [AsteroidNbr] [AsteroïdPrefab] on [CircleCollider]", category: "Action", id: "9c2a9a182b0cdd447a21b3dcfe72c828")]
public partial class InstantiateAsteroidsAction : Action
{
    [SerializeReference] public BlackboardVariable<int> AsteroidNbr;
    [SerializeReference] public BlackboardVariable<GameObject> AsteroïdPrefab;
    [SerializeReference] public BlackboardVariable<GameObject> CircleCollider;

    SphereCollider spawnPos;
    protected override Status OnStart()
    {
        spawnPos = CircleCollider.Value.GetComponent<SphereCollider>();
        for(int i = 0; i < AsteroidNbr.Value; i++)
        {
            Vector3 randomPoint = Random.onUnitSphere;
            randomPoint.y = 0f;
            randomPoint.Normalize(); 
            Vector3 pos = spawnPos.bounds.center + randomPoint * spawnPos.bounds.extents.x;
            pos.y = 2f;
            RetroBoss.Instance.asteroidPattern(AsteroïdPrefab.Value, pos);
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

