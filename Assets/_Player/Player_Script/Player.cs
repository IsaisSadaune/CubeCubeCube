using MoreMountains.Feedbacks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour, IDamageable
{
    public HP_Test hps { get; set; }
    #region Singleton
    private static Player _instance = null;
    public static Player Instance => _instance;
    #endregion
    #region States
    public PlayerStateMachine stateMachine { get; set; }
    public IdleState idleState { get; set; }
    public InteractState interactState { get; set; }
    public WalkingState walkingState { get; set; }
    public DashState dashState { get; set; }
    public AttackState attackState { get; set; }
    public ShieldState shieldState { get; set; }
    public SuperState superState { get; set; }
    #endregion

    #region Movement Variables
    [Header("Movement Variables")]
    public float speed = 5f;
    public float rotationSpeed = 15f;
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
    public MMF_Player parryFeedback;
    public AudioSource dashSound;
    #endregion
    public Super actualSuper;
    #region Others Variables
    public InputActionReference moveRef;
    public LayerMask obstacle;

    [Header("Menu Variables")]
    public UIPauseScript pauseMenu;
    public int buttonSelected { get; set; }

    public bool isDead { get; set; }
    [HideInInspector] public bool canDash = true;
    [HideInInspector] public bool isGrounded = true;
    public Dash dash { get; private set; }
    public Vector3 dashDirection { get; private set; }
    public Attack attack { get; private set; }
    public int comboCount { get; set; }

    [Header("Attack Variables")]
    public GapClose gapClose { get; private set; }
    public Healing healing { get; private set; }
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
    public GameObject dialogueCanvas;
    public Image pnjSprite;
    public GameObject interactImage;
    private bool talkingTrigger;
    [SerializeField] public PNJ pnj;
    public Animator animator;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Interact"))
        {
            talkingTrigger = true;
            interactImage.SetActive(true);
            if (pnj == null)
                pnj = other.GetComponent<PNJ>();
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Interact"))
        {
            interactImage.SetActive(false);
            talkingTrigger = false;
            stateMachine.ChangeState(idleState);
            pnj = null;
        }
    }
    #endregion
    private void Awake()
    {
        stateMachine = new PlayerStateMachine();
        idleState = new IdleState(this, stateMachine);
        walkingState = new WalkingState(this, stateMachine);
        dashState = new DashState(this, stateMachine);
        attackState = new AttackState(this, stateMachine);
        shieldState = new ShieldState(this, stateMachine);
        superState = new SuperState(this, stateMachine);
        interactState = new InteractState(this, stateMachine);


        gapClose = GetComponent<GapClose>();
        healing = GetComponent<Healing>();

        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            _instance = this;
        }
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


        if (dialogueCanvas != null)
            dialogueCanvas.SetActive(false);
        if (interactImage != null)
            interactImage.SetActive(false);

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
        if (!isGrounded)
        {
            rb.linearVelocity = new Vector3(Vector3.zero.x, rb.linearVelocity.y, Vector3.zero.z);
        }
        stateMachine.currentPlayerState.FrameUpdate();

        if (dashBuffer > 0)
        {
            dashBuffer -= Time.deltaTime;
        }
        if (dashBuffer > 0 && canDash && isGrounded && stateMachine.currentPlayerState != attackState)
        {
            gapClose.isUlting = false;
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
            gapClose.isUlting = false;
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
            gapClose.isUlting = false;
            dashBuffer = bufferTimer;
        }
    }

    public void Super(InputAction.CallbackContext context)
    {
        if (context.started && hps.CanUlt)
        {
            gapClose.isUlting = true;
            stateMachine.ChangeState(superState);
        }
        if (context.canceled && hps.CanUlt && gapClose.isUlting)
        {
            gapClose.isUlting = false;
            if (actualSuper == global::Super.GapClose)
            {
                gapClose.GapClosing();
            }
            else if (actualSuper == global::Super.Heal)
            {
                healing.Heal();
            }
        }
        else if (context.canceled && hps.CanUlt && !gapClose.isUlting)
        {
            stateMachine.ChangeState(idleState);
        }
    }

    public void Attack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            gapClose.isUlting = false;
            attackBuffer = bufferAttackTimer;
        }
    }
    public void Defense(InputAction.CallbackContext context)
    {
        if (context.performed && stateMachine.currentPlayerState != attackState && canShield)
        {
            gapClose.isUlting = false;
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
            gapClose.isUlting = false;
            pauseMenu.PauseGame();
        }
    }
    public void Interact(InputAction.CallbackContext context)
    {
        if (context.performed && talkingTrigger && pnj != null && stateMachine.currentPlayerState == idleState)
        {
            stateMachine.ChangeState(interactState);
        }
    }

    public void Close(InputAction.CallbackContext context)
    {
        if (context.performed && pnj.textEnded && pnj != null && stateMachine.currentPlayerState == interactState)
        {
            stateMachine.ChangeState(idleState);
        }
    }
    public void FastWritting(InputAction.CallbackContext context)
    {
        if (context.performed && pnj != null)
        {
            pnj.delay /= 10;
        }
        if (context.canceled && pnj != null)
        {
            pnj.delay *= 10;
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
            GameManager_Offi.Instance.AddStatParry();
            hps.GainMP(5);
            parryFeedback.PlayFeedbacks();
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
            gapClose.isUlting = false;
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

    #region Test_Movement
    public Vector3 wallNormal { get; set; }
    public bool isTouchingWall { get; private set; }

    private void OnCollisionStay(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            if (Vector3.Angle(contact.normal, Vector3.up) > 10f)
            {
                wallNormal = contact.normal;
                isTouchingWall = true;
                return;
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        isTouchingWall = false;
    }
    #endregion
}