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
        Vector3 arrivalPos = boss.transform.position + transform.forward * 2;
        Vector3 dir = boss.transform.position - transform.position;

        arrivalPos.y = transform.position.y;
        transform.position = arrivalPos + Vector3.forward * 3;
    }
}
