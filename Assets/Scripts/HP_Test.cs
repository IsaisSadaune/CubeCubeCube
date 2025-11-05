using UnityEngine;

public class HP_Test : MonoBehaviour
{
    private float hp_max = 15;
    float current_hp;
    public Player player;

    void Start()
    {
        current_hp = hp_max;
    }

    public void LoseHP(int x)
    {
        current_hp -= x;
        if(current_hp <=0)
        {
            current_hp = 0;
            KillPlayer();
        }
    }

    private void KillPlayer()
    {
        Destroy(player.gameObject);
    }
}
