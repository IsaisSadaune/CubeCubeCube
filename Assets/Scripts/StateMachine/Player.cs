using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    #region States
    public PlayerStateMachine stateMachine { get; set; }
    public IdleState idleState { get; set; }
    public WalkingState walkingState { get; set; }
    public DashState dashState{ get; set; }
    #endregion
    #region Movement Variables
    public float speed = 5f;
    public float dashForce = 10f;
    public float dashDuration = 0.5f;
    public float dashCooldown = 0.5f;
    [HideInInspector] public Vector2 moveInput;
    [HideInInspector] public Vector3 direction;
    #endregion
    #region Components
    [HideInInspector] public Rigidbody rb;
    bool canDash;
    #endregion
    private void Awake()
    {
        stateMachine = new PlayerStateMachine();
        idleState = new IdleState(this, stateMachine);
        walkingState = new WalkingState(this, stateMachine);
        dashState = new DashState(this, stateMachine);
        
    }
    private void Start()
    {
        stateMachine.Initialize(idleState);
        rb = GetComponent<Rigidbody>();
    }

    #region Animation Triggers

    private void AnimationTriggerEvent(AnimationTriggerType triggerType)
    {

    }
    public enum AnimationTriggerType
    { }
    #endregion
    private void Update()
    {
        stateMachine.currentPlayerState.FrameUpdate();
    }
    private void FixedUpdate()
    {
        stateMachine.currentPlayerState.PhysicsUpdate();
    }

    #region ControllerFunctions
    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();

        direction = new Vector3(moveInput.x, 0, moveInput.y);

        //Debug.Log($"Move Input : {moveInput}");
    }

    public void Dash(InputAction.CallbackContext context)
    {
        Debug.Log($"Dashing {context.performed}");
        if (context.performed)
        {
            stateMachine.ChangeState(dashState);
        }
    }
    public void StartDash()
    {
        StartCoroutine(Dash());
    }
    #endregion

    #region Coroutines
    public IEnumerator Dash()
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
        stateMachine.ChangeState(idleState);
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;

    }
    #endregion
}
