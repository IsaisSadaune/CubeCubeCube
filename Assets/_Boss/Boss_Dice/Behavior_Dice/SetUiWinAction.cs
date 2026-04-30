using MoreMountains.Feedbacks;
using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "SetUIWin", story: "[MMFFeedbackUI] is played and update [score] for boss [numberBoss]", category: "Action", id: "83362e6f7c308df50ea329e2e77f5d85")]
public partial class SetUiWinAction : Action
{
    [SerializeReference] public BlackboardVariable<MMF_Player> MMFFeedbackUI;
    [SerializeReference] public BlackboardVariable<UIRankCalculScript> Score;
    [SerializeReference] public BlackboardVariable<int> NumberBoss;

    GameManager_Offi gm => GameManager_Offi.Instance;
    protected override Status OnStart()
    {

        //gm.EndBattle();
        MMFFeedbackUI.Value.PlayFeedbacks();
        gm.UpdateScore(NumberBoss, gm.Temps, Score.Value.finalRank);
        Score.Value.CalculateAndDisplayVictoryDatas(gm.Temps, gm.NbParry, gm.NbHeal, gm.RagePerdue, NumberBoss);

        //J'ai du le mettre une 2eme fois car on a mal combiné avec tom, normalement pas de bug mais c'est pas beau
        gm.UpdateScore(NumberBoss, gm.Temps, Score.Value.finalRank);
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

