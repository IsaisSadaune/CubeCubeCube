using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    int comboCount = 0;
    public BoxCollider[] attacksBoxCollider;
    [HideInInspector] public float lastAttackLaunch;
    [HideInInspector] public float lastComboEnd;
    public List<AttackSO> combo;
    Player player;

    void Start()
    {
        player = GetComponent<Player>();
        for (int i = 0; i < attacksBoxCollider.Length; i++)
        {
            combo[i].attackCollider = attacksBoxCollider[i];
        }
    }
    public void LaunchAttack()
    {
        if (Time.time - lastComboEnd > 0.5f && comboCount <= combo.Count)
        {
            CancelInvoke("EndCombo");
        }

        if (comboCount > combo.Count)
        {
            comboCount = 0;
            player.stateMachine.ChangeState(player.idleState);
        }
        if (Time.time - lastAttackLaunch >= 0.2f)
        {
            combo[comboCount].attackCollider.gameObject.SetActive(true);
            comboCount++;
            lastAttackLaunch = Time.time;

            //Fais une animation vite fais, pcq je dois faire en sorte que l'activation du collider soit une anim et pas un vieu setactive Sinon trop chiant
        }
    }

    public void StoppingAttack()
    {
        if (lastAttackLaunch < Time.time + 1f)
        {
            Invoke("EndCombo", 1);
            combo[comboCount - 1].attackCollider.gameObject.SetActive(false);
        }
    }

    void EndCombo()
    {
        comboCount = 0;
        lastComboEnd = Time.time;
        player.stateMachine.ChangeState(player.idleState);
    }
    
}