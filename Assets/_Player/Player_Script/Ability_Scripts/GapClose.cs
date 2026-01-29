using UnityEngine;

public class GapClose : MonoBehaviour
{
    private Player player;
    [SerializeField] private GameObject boss;

    void Start()
    {
        player = GetComponent<Player>();
    }

    public void GapClosing()
    {
        float distance = Vector3.Distance(transform.position, boss.transform.position);
        Vector3 endPos = transform.position + player.direction * distance;

        transform.position = endPos;
        
        player.stateMachine.ChangeState(player.idleState);
    }
}
