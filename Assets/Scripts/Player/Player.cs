using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.Rendering.DebugUI;

public class Player : MonoBehaviour, IDamageable
{
    #region States
    public PlayerStateMachine stateMachine { get; set; }
    public IdleState idleState { get; set; }
    public WalkingState walkingState { get; set; }
    public DashState dashState { get; set; }
    public AttackState attackState { get; set; }
    public ShieldState shieldState { get; set; }
    public InteractState interactState { get; set; }
    #endregion

    #region Movement Variables
    [Header("Movement Variables")]
    public float speed = 5f;
    public float dashForce = 10f;
    public float dashDuration = 0.5f;
    public float dashCooldown = 0.5f;
    [HideInInspector] public Vector2 moveInput;
    public Vector3 direction { get; private set; }

    #endregion

    #region Components
    public Rigidbody rb { get; private set; }
    [Header("InputActions")]
    public PlayerInput playerInput { get; private set; }


    #endregion

    #region Others Variables
    [HideInInspector] public bool canDash = true;
    [HideInInspector] public bool isGrounded = true;
    public Dash dash { get; private set; }
    public Vector3 dashDirection { get; private set; }
    public Attack attack { get; private set; }
    public int comboCount { get; set; }
    [Header("Attack Variables")]
    public List<AttackSO> combo;
    public BoxCollider[] attacksCollider;
    public string[] attacksAnimation;

    [SerializeField] private float timeBeforeNextCombo;
    [SerializeField] private float timeBeforeNextAttack;
    public Coroutine resetCombo { get; set; }
    public float lastComboEnd { get; set; }
    public float lastAttack { get; set; }

    [Header("Shield Variables")]
    public GameObject shield;

    [Header("Interaction Variables")]
    public TextMeshProUGUI emptyText;
    public Dialogue_Manager dialogue_Manager { get; set; }
    public float timeBetweenLetter { get; set; }
    private bool talkingTrigger;

    #endregion

    #region Animation Triggers
    public Animator animator;
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
        attackState = new AttackState(this, stateMachine);
        shieldState = new ShieldState(this, stateMachine);
        interactState = new InteractState(this, stateMachine);
    }

    private void Start()
    {
        hitbox = GetComponent<CapsuleCollider>();
        attack = GetComponent<Attack>();
        animator = GetComponent<Animator>();
        dash = GetComponent<Dash>();
        stateMachine.Initialize(idleState);
        rb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
        dialogue_Manager = GetComponent<Dialogue_Manager>();


        for (int i = 0; i < combo.Count; i++)
        {
            combo[i].attackCollider = attacksCollider[i];
        }
    }

    private void Update()
    {
        stateMachine.currentPlayerState.FrameUpdate();
    }
    private void FixedUpdate()
    {
        stateMachine.currentPlayerState.PhysicsUpdate();
        dashDirection = new Vector3(moveInput.x, 0, moveInput.y);
    }

    #region ControllerFunctions
    public void Move(InputAction.CallbackContext context)
    {
            moveInput = context.ReadValue<Vector2>();
            direction = new Vector3(moveInput.x, 0, moveInput.y);
    }

    public void Dash(InputAction.CallbackContext context)
    {
        //Debug.Log($"Dashing {context.performed}");
        if (context.performed && isGrounded && canDash && stateMachine.currentPlayerState != attackState)
        {

            //Récupérer la position du joystick à ce moment là pour que le dash ne soit pas lié avec la position mais le joystick uniquement == fluidifie le dash
            stateMachine.ChangeState(dashState);
        }
    }

    public void Attack(InputAction.CallbackContext context)
    {
        if (context.performed && Time.time > (lastComboEnd + timeBeforeNextCombo) && Time.time > (lastAttack + timeBeforeNextAttack) && stateMachine.currentPlayerState != attackState)
        {
            stateMachine.ChangeState(attackState);
        }
    }
    public void Defense(InputAction.CallbackContext context)
    {
        if (context.performed && stateMachine.currentPlayerState != attackState)
        {
            stateMachine.ChangeState(shieldState);
        }

        if (context.canceled && stateMachine.currentPlayerState == shieldState)
        {
            stateMachine.ChangeState(idleState);
        }
    }

    public void Interact(InputAction.CallbackContext context)
    {
        if (context.performed && talkingTrigger)
        {
            timeBetweenLetter = 0.1f;
            stateMachine.ChangeState(interactState);
        }
    }

    public void Next(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            //if (dialogue_Parameters.dialogue_Index < dialogue_Parameters.dialogue_content.Length - 1 && emptyText.text == dialogue_Parameters.dialogue_content[dialogue_Parameters.dialogue_Index])
            //{
            //    dialogue_Parameters.dialogue_Index++;
            //    dialogue_Manager.SetDialogue();
            //}
            //else if(dialogue_Parameters.dialogue_Index == dialogue_Parameters.dialogue_content.Length - 1)
            //{
            //    stateMachine.ChangeState(idleState);
            //}

        }
    }
    public void FastWritting(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            timeBetweenLetter = 0.02f;
        }
        if (context.canceled)
        {
            timeBetweenLetter = 0.1f;
        }
    }

    public IEnumerator resetingCombo()
    {
        yield return new WaitForSeconds(2f);
        comboCount = 0;
    }

    public IEnumerator resetingDash()
    {
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }
    #endregion



    //tmp var isais
    private float cdIFrames = 1f;
    private float cdCantMove = 0.5f;
    private CapsuleCollider hitbox;
    [SerializeField] private HP_Test hps;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Interact")
        {
            talkingTrigger = true;
            //dialogue_Parameters = other.gameObject.GetComponent<Dialogues_Parameters>();
        }

        //ISAIS : ajout du trigger Boss 
        //C'EST DEGUEULASSE !!!!!!!!!!!!
        if (other.CompareTag("Boss"))
        {
            Vector3 kbDir = -(other.transform.position - transform.position);
            kbDir = new Vector3(kbDir.x, 0, kbDir.z).normalized;
            //Debug.Log(kbDir);
            rb.AddForce(kbDir * 200);
            //Debug.Break();
            TakeDamage(0);
            StartCoroutine(cdDamage());
        }
    }

    //tout pareil qu'au dessus : c'pa'bo
    IEnumerator cdDamage()
    {
        hitbox.enabled = false;
        playerInput.enabled = false;
        //playerInput.SwitchCurrentActionMap("UI");
        yield return new WaitForSeconds(cdCantMove);
        playerInput.enabled = true;
        //playerInput.SwitchCurrentActionMap("Gameplay");
        yield return new WaitForSeconds(cdIFrames);
        hitbox.enabled = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Interact")
        {
            talkingTrigger = false;
        }
    }
    //ISAIS : Implémentation de l'interface
    public void TakeDamage(int dgt)
    {
        Debug.Log("joueur prend dgts");
        hps.LoseHP(dgt);
    }

    public void Die()
    {
        Destroy(gameObject);
    }


}