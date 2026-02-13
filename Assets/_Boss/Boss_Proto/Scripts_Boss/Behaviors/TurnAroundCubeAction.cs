
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using DG.Tweening;

[GeneratePropertyBag]
[NodeDescription(name: "TurnAroundCube", story: "Cubes Turn Around [Self]", category: "Action", id: "9e1fc4f74911adfd86dd8fa56d6a3147")]
public partial class TurnAroundCubeAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;

    
    protected override Status OnStart()
    {
        Self.Value.transform.DORotate(1080f * Vector3.one, 5f);
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        return Status.Success;
    }

    protected override void OnEnd()
    {
        
    }




    // public class Ellipse
    // {
    //     public float xAxis;
    //     public float yAxis;

    // public Ellipse(float yAxis, float xAxis)
    //     {
    //         this.xAxis = xAxis;
    //         this.yAxis = yAxis;
    //     }

    //     public Vector2 Evaluate(float t)
    // {
    //     float angle = Mathf.Deg2Rad * 360f * t;
    //     float x = Mathf.Sin(angle) * xAxis;
    //     float y = Mathf.Cos(angle) * yAxis;

    //     return new Vector2(x,y);
    // }
    //}
    }


