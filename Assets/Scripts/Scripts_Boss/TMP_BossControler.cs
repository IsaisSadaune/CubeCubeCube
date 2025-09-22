using System.Collections;
using UnityEngine;

public class TMP_BossControler : MonoBehaviour
{
    private Rigidbody rb;
    bool isMoving;
    [SerializeField] private float speed;
    [SerializeField] private float cooldown;
    bool isCooldown;
    [SerializeField] private Transform destination1;
    [SerializeField] private Transform destination2;

    private Transform destination;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        //DashBoss();
    }


    [ContextMenu("dash")]
    public void DashBoss()
    {
        if (!isMoving && !isCooldown)
        {
            isMoving = true;
            if (destination != destination1) destination = destination1;
            else destination = destination2;
        }
    }

    private void FixedUpdate()
    {
        /*
        if (!isCooldown)
        {
            if (isMoving)
            {
                Debug.Log((rb.position - destination.position).magnitude);
                rb.MovePosition(rb.position + (destination.position - transform.position).normalized * speed * Time.fixedDeltaTime);
                if ((rb.position - destination.position).magnitude < 0.25f)
                {
                    isMoving = false;
                    rb.position = destination.position;
                    StartCoroutine(Cooldown());
                }
            }
        }*/
    }


    private IEnumerator Cooldown()
    {
        isCooldown = true;
        yield return new WaitForSeconds(cooldown);
        isCooldown = false;
        DashBoss();
    }
}
