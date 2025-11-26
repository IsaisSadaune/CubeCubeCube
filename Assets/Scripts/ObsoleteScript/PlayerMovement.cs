using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float dashForce = 10f;
    [SerializeField] private float dashDuration = 0.5f;
    [SerializeField] private float dashCooldown = 0.5f;

    bool canDash = true;
    private Rigidbody rb;
    [HideInInspector] public Vector2 moveInput;
    private Vector3 direction;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();

        direction = new Vector3(moveInput.x, 0, moveInput.y);

        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 0.15f);
        //Debug.Log($"Move Input : {moveInput}");
    }

    public void Dash(InputAction.CallbackContext context)
    {
        Debug.Log($"Dashing {context.performed}");
        if (context.performed)
        {

            //direction = new Vector3(moveInput.x, 0, moveInput.y);


            if (canDash)
            {
                StartCoroutine(Dash());
            }
        }
    }

    void Update()
    {
        Vector3 move = new Vector3(moveInput.x, 0, moveInput.y);
        rb.linearVelocity = move * speed;

    }

    IEnumerator Dash()
    {
        canDash = false;
        RaycastHit hit;
        float startTime = Time.time;
        Vector3 startPos = rb.position;
        Vector3 endPos;




        if (Physics.Raycast(transform.position, rb.transform.forward, out hit, 5f))
        {
            endPos = hit.point * 0.9f;
        }
        else
        {
            endPos = rb.position + rb.transform.forward * dashForce;
        }



        while (Time.time < startTime + dashDuration)
        {

            float t = (Time.time - startTime) / dashDuration;
            rb.MovePosition(Vector3.Lerp(startPos, endPos, t));
            yield return null;
        }
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;

    }
}
