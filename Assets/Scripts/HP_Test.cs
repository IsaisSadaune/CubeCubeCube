using UnityEngine;

public class HP_Test : MonoBehaviour
{
    private float hp_max = 100;
    float current_hp;
    public Player player;

    void Start()
    {
        current_hp = hp_max;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Attack")
        {
            current_hp -= player.combo[player.comboCount].damage;
            Debug.Log(current_hp);
        }   
    }
}
