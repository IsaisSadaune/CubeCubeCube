using UnityEngine;

public class Boss_Variables : MonoBehaviour
{
    [SerializeField] private float MaxHP;
    public float HP { get; private set; }
    public bool isSlimy { get; private set; }
    public void SetSlimy()
    {
        isSlimy = true;
    }
    public void StopSlimy()
    {
        isSlimy = false;
    }
}
