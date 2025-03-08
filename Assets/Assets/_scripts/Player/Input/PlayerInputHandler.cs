using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    public GameInputs GameInputs;
    private Camera cam;

    public Vector2 RawMovementInput { get; private set; }
    public Vector2 RawDashDirectionInput { get; private set; }
    public Vector2Int DashDirectionInput { get; private set; }
    public int NormInputX { get; private set; }
    public int NormInputY { get; private set; }
    public bool JumpInput { get; private set; }
    public bool JumpInputStop { get; private set; }

    public bool OpenMenuInput { get; private set; }
    public bool CloseMenuInput { get; private set; }

    public bool InteractionInput { get; private set; }
    public bool InteractionInputStop { get; private set; }


    public bool DashInput { get; private set; }
    public bool DashInputStop { get; private set; }

    public bool[] AttackInputs { get; private set; }

    [SerializeField]
    private float inputHoldTime = 0.2f;

    private float jumpInputStartTime;
    private float dashInputStartTime;
    private float interactionInputStartTime;



    private void Awake()
    {
        GameInputs = new GameInputs();


        cam = Camera.main;

    }

    private void Start()
    {

        OnMoveInput();

        OnJumpInput();

        OnInteractionInput();

    }

    private void Update()
    {
        CheckPauseInputs();

        CheckJumpInputHoldTime();
        CheckDashInputHoldTime();
        CheckInteractionInputHoldTime();
    }
    public void OnMoveInput()
    {
        GameInputs.Gameplay.Movement.performed += ctx =>
        {
            RawMovementInput = ctx.ReadValue<Vector2>();

            NormInputX = Mathf.RoundToInt(RawMovementInput.x);
            NormInputY = Mathf.RoundToInt(RawMovementInput.y);
        };

        GameInputs.Gameplay.Movement.canceled += ctx =>
        {
            RawMovementInput = ctx.ReadValue<Vector2>();

            NormInputX = Mathf.RoundToInt(0);
            NormInputY = Mathf.RoundToInt(0);
        };

    }

    public void OnJumpInput()
    {
        GameInputs.Gameplay.Jump.started += ctx =>
        {
            JumpInput = true;
            JumpInputStop = false;
            jumpInputStartTime = Time.time;
        };


        GameInputs.Gameplay.Jump.canceled += ctx =>
        {
            JumpInputStop = true;
        };
    }

    public void OnInteractionInput()
    {
        GameInputs.Gameplay.Interaction.started += ctx =>
        {
            InteractionInput = true;
            InteractionInputStop = false;
            interactionInputStartTime = Time.time;
        };


        GameInputs.Gameplay.Interaction.canceled += ctx =>
        {
            InteractionInputStop = true;
        };
    }




    public void UseJumpInput() => JumpInput = false;

    public void UseDashInput() => DashInput = false;

    public void UseInteractionInput() => InteractionInput = false;



    public void CheckPauseInputs()
    {
        OpenMenuInput = GameInputs.Gameplay.MenuOpen.WasPressedThisFrame();
        CloseMenuInput = GameInputs.UI.MenuClose.WasPressedThisFrame();
    }

    private void CheckJumpInputHoldTime()
    {
        if (Time.time >= jumpInputStartTime + inputHoldTime)
        {
            JumpInput = false;
        }
    }

    private void CheckDashInputHoldTime()
    {
        if (Time.time >= dashInputStartTime + inputHoldTime)
        {
            DashInput = false;
        }
    }

    private void CheckInteractionInputHoldTime()
    {
        if (Time.time >= interactionInputStartTime + inputHoldTime)
        {
            InteractionInput = false;
        }
    }



    private void OnEnable()
    {
        GameInputs.Gameplay.Enable();
    }

    private void OnDisable()
    {
        GameInputs.Gameplay.Disable();
    }
}

