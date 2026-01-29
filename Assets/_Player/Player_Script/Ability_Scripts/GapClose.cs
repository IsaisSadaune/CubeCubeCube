using UnityEngine;

public class GapClose : MonoBehaviour
{
    private Player player;
    public int damage;
    [SerializeField] private GameObject boss;
    public GameObject hitPrevi; 
    public GameObject posPrevi; 

    void Start()
    {
        player = GetComponent<Player>();
        Vector3 endPos = transform.forward * 12;
        posPrevi.transform.position = new Vector3(endPos.x, -2f, endPos.z);
    }

    public void GapClosing()
    {
        Vector3 endPos = transform.forward * 12;

        RaycastHit hit;
        Physics.Raycast(endPos, Vector3.down, out hit);
        if(hit.collider.tag == "Ground")
        {
            transform.position = new Vector3(transform.forward.x * 10, transform.position.y, transform.forward.z * 10);
            player.stateMachine.ChangeState(player.idleState);
        }
        else
            player.stateMachine.ChangeState(player.idleState);

    }
}
