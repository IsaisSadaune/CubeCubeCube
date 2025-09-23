using UnityEngine;

[CreateAssetMenu(menuName = "Combo_Attacks")]
public class AttackSO : ScriptableObject
{
    public float damage;
    public BoxCollider attackCollider;
}
