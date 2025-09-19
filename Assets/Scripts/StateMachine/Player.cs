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
    public Vector2 moveInput { get; private set; }
    public Vector3 direction { get; private set; }
    #endregion
    #region Components
    public Rigidbody rb{ get; private set; }
    #endregion
    #region Others Variables
    public bool canDash = true;
    public Dash dash{ get; private set; }
    #endregion
    #region Animation Triggers

    private void AnimationTriggerEvent(AnimationTriggerType triggerType)
    {

    }
    public enum AnimationTriggerType
    { }
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
        dash = GetComponent<Dash>();
        stateMachine.Initialize(idleState);
        rb = GetComponent<Rigidbody>();
    }

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
    #endregion
}