using Unity.VisualScripting;
using UnityEngine;

public class HP_Test : MonoBehaviour
{
    [SerializeField] private int hp_max;
    int current_hp;
    public Player player;
    [SerializeField] private UI_Player uip;

    void Start()
    {
        current_hp = hp_max;
        uip.SetHps(current_hp);
    }

    public void LoseHP(int x)
    {
        current_hp -= x;
        uip.RemoveHP(x);

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
