using UnityEngine;

public class InteractState : PlayerState
{
    public InteractState(Player player, PlayerStateMachine stateMachine) : base(player, stateMachine)
    {

    }

    public override void EnterState()
    {
        base.EnterState();
        player.rb.linearVelocity = new Vector3(Vector3.zero.x, player.rb.linearVelocity.y, Vector3.zero.z);
        player.playerInput.SwitchCurrentActionMap("UI");
        player.dialogueCanvas.SetActive(true);
        player.pnjSprite.sprite = player.pnj.pnj_Sprite;
        player.pnj.emptyNameText.text = player.pnj.gameObject.name;
        player.pnj.ShowText();
    }

    public override void ExitState()
    {
        player.pnj.StopAllCoroutines();
        player.pnj.emptyDialogueText.text = "";
        player.pnj.emptyNameText.text = "";
        player.pnj.textEnded = false;
        player.dialogueCanvas.SetActive(false);
        player.playerInput.SwitchCurrentActionMap("Gameplay");
        base.ExitState();    
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
