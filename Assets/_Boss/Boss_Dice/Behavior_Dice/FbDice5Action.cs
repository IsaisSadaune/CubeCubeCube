using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using System.Collections.Generic;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "FbDice5", story: "Activate Feedbacks on [Player] [UpLeft] [UpRight] [DownLeft] [DownRight]", category: "Action", id: "118575bd6b729420dbad60ef10197b04")]
public partial class FbDice5Action : Action
{
    [SerializeReference] public BlackboardVariable<Player> Player;
    [SerializeReference] public BlackboardVariable<FbSlabManager> UpLeft;
    [SerializeReference] public BlackboardVariable<FbSlabManager> UpRight;
    [SerializeReference] public BlackboardVariable<FbSlabManager> DownLeft;
    [SerializeReference] public BlackboardVariable<FbSlabManager> DownRight;

    protected override Status OnStart()
    {
        UpLeft.Value.ChangeColorSlab();
        UpRight.Value.ChangeColorSlab();
        DownLeft.Value.ChangeColorSlab();
        DownRight.Value.ChangeColorSlab();

        var l = ManagerUnderPlayer(Player.Value);
        foreach(var c in l)
            c.ChangeColorSlab();

        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        return Status.Success;
    }

    private List<FbSlabManager> ManagerUnderPlayer(Player p)
    {
        List<FbSlabManager> l = new();

        var c = Physics.OverlapSphere(p.transform.position, 1f);
        foreach(var _c in c)
        {
            _c.TryGetComponent<FbSlabManager>(out FbSlabManager playerSlab);
            l.Add(playerSlab);
        }

        return l;
    }
}

