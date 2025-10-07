using UnityEngine;

public class Boss_Variables : MonoBehaviour
{
    [SerializeField] private float MaxHP;
    public float HP { get; private set; }
    public bool isSlimy { get; private set; }
    public bool isDestroying { get; private set; }
    public void SetSlimy()
    {
        isSlimy = true;
    }
    public void StopSlimy()
    {
        isSlimy = false;
    }

    public void SetDestroying() => isDestroying = true;
    public void StopDestroying() => isDestroying = false;
}
