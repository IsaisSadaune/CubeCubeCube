using UnityEngine;

[CreateAssetMenu(menuName = "Combo_Attacks")]
public class AttackSO : ScriptableObject
{
    public int damage;
    public string animName;
    public BoxCollider attackCollider;
}
