using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class PlayerInputHandler : MonoBehaviour
{
    private GameInputs playerInput;
    private Camera cam;

    public Vector2 RawMovementInput { get; private set; }
    public Vector2 RawDashDirectionInput { get; private set; }
    public Vector2Int DashDirectionInput { get; private set; }
    public int NormInputX { get; private set; }
    public int NormInputY { get; private set; }
    public bool JumpInput { get; private set; }
    public bool JumpInputStop { get; private set; }

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
        playerInput = new GameInputs();

        int count = Enum.GetValues(typeof(CombatInputs)).Length;
        AttackInputs = new bool[count];

        cam = Camera.main;

    }

    private void Start()
    {

        OnMoveInput();

        OnJumpInput();

        OnInteractionInput();

        OnPrimaryInput();





    }

    private void Update()
    {
        CheckJumpInputHoldTime();
        CheckDashInputHoldTime();
        CheckInteractionInputHoldTime();
    }
    public void OnMoveInput()
    {
        playerInput.Gameplay.Movement.performed += ctx =>
        {
            RawMovementInput = ctx.ReadValue<Vector2>();

            NormInputX = Mathf.RoundToInt(RawMovementInput.x);
            NormInputY = Mathf.RoundToInt(RawMovementInput.y);
        };

        playerInput.Gameplay.Movement.canceled += ctx =>
        {
            RawMovementInput = ctx.ReadValue<Vector2>();

            NormInputX = Mathf.RoundToInt(0);
            NormInputY = Mathf.RoundToInt(0);
        };

    }

    public void OnJumpInput()
    {
        playerInput.Gameplay.Jump.started += ctx =>
        {
            JumpInput = true;
            JumpInputStop = false;
            jumpInputStartTime = Time.time;
        };


        playerInput.Gameplay.Jump.canceled += ctx =>
        {
            JumpInputStop = true;
        };
    }

    public void OnInteractionInput()
    {
        playerInput.Gameplay.Interaction.started += ctx =>
        {
            InteractionInput = true;
            InteractionInputStop = false;
            interactionInputStartTime = Time.time;
        };


        playerInput.Gameplay.Interaction.canceled += ctx =>
        {
            InteractionInputStop = true;
        };
    }

    public void OnPrimaryInput()
    {
        playerInput.Gameplay.PrimaryAction.started += ctx => AttackInputs[(int)CombatInputs.primary] = true;
        playerInput.Gameplay.PrimaryAction.canceled += ctx => AttackInputs[(int)CombatInputs.primary] = false;
    }

    public void UseJumpInput() => JumpInput = false;

    public void UseDashInput() => DashInput = false;

    public void UseInteractionInput() => InteractionInput = false;


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
        playerInput.Gameplay.Enable();
    }

    private void OnDisable()
    {
        playerInput.Gameplay.Disable();
    }
}


public enum CombatInputs
{
    primary,
    secondary
}

