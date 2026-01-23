using MoreMountains.Feedbacks;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour, IDamageable
{
    public HP_Test hps {get ; set;}
    #region States
    public PlayerStateMachine stateMachine { get; set; }
    public IdleState idleState { get; set; }
    public WalkingState walkingState { get; set; }
    public DashState dashState { get; set; }
    public AttackState attackState { get; set; }
    public ShieldState shieldState { get; set; }
    #endregion

    #region Movement Variables
    [Header("Movement Variables")]
    public float speed = 5f;
    public float dashForce = 10f;
    public float dashDuration;
    public float dashTimer { get; set; }
    public float dashCooldown;
    public float bufferTimer;
    private float dashBuffer;
    [HideInInspector] public Vector2 moveInput;
    public Vector3 direction { get; set; }

    #endregion

    #region Components
    public Rigidbody rb { get; private set; }
    [Header("InputActions")]
    public PlayerInput playerInput { get; private set; }
    public ParticleSystem dust;

    #endregion
    #region Feedbacks
    [Header("Feedbacks References")]
    public MMF_Player deathFeedback;
    public MMF_Player dmgFeedback;
    public AudioSource dashSound;
    #endregion

    #region Others Variables
    public InputActionReference moveRef;

    [Header("Menu Variables")]
    public PauseMenu pauseMenu;
    public int buttonSelected { get; set; }

    public bool isDead { get; set; }
    [HideInInspector] public bool canDash = true;
    [HideInInspector] public bool isGrounded = true;
    public Dash dash { get; private set; }
    public Vector3 dashDirection { get; private set; }
    public Attack attack { get; private set; }
    public int comboCount { get; set; }

    [Header("Attack Variables")]
    private float attackBuffer;
    [SerializeField] private float bufferAttackTimer;
    public List<AttackSO> combo;
    public bool bossHit = false;
    public BoxCollider[] attacksCollider;
    public string[] attacksAnimation;

    [SerializeField] private float timeBeforeNextCombo;
    [SerializeField] private float timeBeforeNextAttack;
    public Coroutine resetCombo { get; set; }
    public float lastComboEnd { get; set; }
    public float lastAttack { get; set; }

    [Header("Shield Variables")]

    public GameObject shield;
    public float shieldActivation { get; set; }
    [SerializeField] private float parryTiming;

    [Header("Interaction Variables")]
    public TextMeshProUGUI emptyText;
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
    }

    private void Start()
    {

        attack = GetComponent<Attack>();
        animator = GetComponent<Animator>();
        dash = GetComponent<Dash>();
        stateMachine.Initialize(idleState);
        rb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
        hps = GetComponent<HP_Test>();


        var actualScene = SceneManager.GetActiveScene();

        if (actualScene == SceneManager.GetSceneByName("ProtoBossBattle"))
            playerInput.SwitchCurrentActionMap("UI");


        for (int i = 0; i < combo.Count; i++)
        {
            combo[i].attackCollider = attacksCollider[i];
        }

    }

    private void Update()
    {
        stateMachine.currentPlayerState.FrameUpdate();

        if (dashBuffer > 0)
        {
            dashBuffer -= Time.deltaTime;
        }
        if (dashBuffer > 0 && canDash && isGrounded && stateMachine.currentPlayerState != attackState)
        {
            stateMachine.ChangeState(dashState);
            dashBuffer = 0;
        }

        if (attackBuffer > 0)
        {
            attackBuffer -= Time.deltaTime;
        }
        if (attackBuffer > 0 && Time.time > (lastComboEnd + timeBeforeNextCombo) 
        && Time.time > (lastAttack + timeBeforeNextAttack) 
        && stateMachine.currentPlayerState != attackState)
        {
            stateMachine.ChangeState(attackState);
            attackBuffer = 0;
        }
    }
    private void FixedUpdate()
    {
        stateMachine.currentPlayerState.PhysicsUpdate();

        moveInput = playerInput.actions["Move"].ReadValue<Vector2>();

        Vector3 camForward = Camera.main.transform.forward;
        Vector3 camRight = Camera.main.transform.right;

        camForward.y = 0f;
        camRight.y = 0f;
        camForward.Normalize();
        camRight.Normalize();

        dashDirection = (camForward * moveInput.y + camRight * moveInput.x).normalized;
    }

    #region ControllerFunctions
    public void Move(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            moveInput = context.ReadValue<Vector2>();
        }
        UpdateDirectionFromCamera();
    }

    void UpdateDirectionFromCamera()
    {
        Vector3 camForward = Camera.main.transform.forward;
        Vector3 camRight = Camera.main.transform.right;

        camForward.y = 0f;
        camRight.y = 0f;
        camForward.Normalize();
        camRight.Normalize();

        direction = (camForward * moveInput.y + camRight * moveInput.x).normalized;
    }


    public void Dash(InputAction.CallbackContext context)
    {
        if (!context.started) return;
        {
            dashBuffer = bufferTimer;
        }
    }

    public void Attack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            attackBuffer = bufferAttackTimer;
        }
    }
    public void Defense(InputAction.CallbackContext context)
    {
        if (context.performed && stateMachine.currentPlayerState != attackState && canShield)
        {
            stateMachine.ChangeState(shieldState);
        }

        if (context.canceled && stateMachine.currentPlayerState == shieldState)
        {
            stateMachine.ChangeState(idleState);
        }
    }

    public void Pause(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            pauseMenu.OnPause();
        }
    }
    #endregion

    //tmp var isais
    public bool hasFalledRecently = false;
    private float cdIFrames = 1f;
    private float cdCantMove = 0.5f;

    public CapsuleCollider hitbox;
    public bool iFraming { get; set; }

    //tout pareil qu'au dessus : c'pa'bo
    IEnumerator cdDamage()
    {
        hitbox.enabled = false;
        playerInput.enabled = false;
        yield return new WaitForSeconds(cdCantMove);
        playerInput.enabled = true;
        yield return new WaitForSeconds(cdIFrames);
        hitbox.enabled = true;
        iFraming = false; //bug mais c'est pas grave
    }
    bool canShield = true;
    IEnumerator ShieldBreak()
    {
        canShield = false;
        yield return new WaitForSeconds(2f);
        canShield = true;
    }
    #region interfaceDegats
    public void TakeDamage(int dgt)
    {
        if (stateMachine.currentPlayerState == shieldState && Time.time - shieldActivation < parryTiming)
        {
            Debug.Log("PARRY");
            hps.GainMP(5);
            //Parry();
        }
        else if (stateMachine.currentPlayerState == shieldState)
        {
            hps.LoseHP(dgt / 2);
            StartCoroutine(ShieldBreak());
            stateMachine.ChangeState(idleState);
        }
        else
        {
            hps.GainMP(2);
            dmgFeedback.PlayFeedbacks();
            hps.LoseHP(dgt);
        }
        StartCoroutine(cdDamage());
    }

    public void Knockback(Transform other)
    {
        Vector3 kbDir = -(other.transform.position - transform.position);
        kbDir = new Vector3(kbDir.x, 0, kbDir.z).normalized;
        rb.AddForce(kbDir * 200);
    }
    public void Die()
    {
        deathFeedback.PlayFeedbacks();
    }

    public void CreateDust()
    {
        dust.Play();
    }
    #endregion

}