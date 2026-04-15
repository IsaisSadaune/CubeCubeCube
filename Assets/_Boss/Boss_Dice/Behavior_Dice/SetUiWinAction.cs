using MoreMountains.Feedbacks;
using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "SetUIWin", story: "[MMFFeedbackUI] is played and update [score]", category: "Action", id: "83362e6f7c308df50ea329e2e77f5d85")]
public partial class SetUiWinAction : Action
{
    [SerializeReference] public BlackboardVariable<MMF_Player> MMFFeedbackUI;
    [SerializeReference] public BlackboardVariable<UIRankCalculScript> Score;
    protected override Status OnStart()
    {
        MMFFeedbackUI.Value.PlayFeedbacks();
        GameManager_Offi.Instance.EndBattle();
        Score.Value.CalculateAndDisplayVictoryDatas(GameManager_Offi.Instance.Temps, GameManager_Offi.Instance.NbParry, GameManager_Offi.Instance.NbHeal, GameManager_Offi.Instance.RagePerdue);
        GameManager_Offi.Instance.UpdateScore(1, GameManager_Offi.Instance.Temps, Score.Value.finalRank);
        Debug.Log(Score.Value.finalRank);
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

