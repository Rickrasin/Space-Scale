using Space.FSM;
using Space.Objects;
using UnityEngine;

public class PlayerCarryState : PlayerAbilityState
{
    private Box currentBox;
    private bool isCarrying;

    public PlayerCarryState(PlayerScript player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName)
        : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        Movement.SetVelocityX(0);

        if (currentBox == null)
        {
            currentBox = Interaction.GetInteractable<Box>();
            isCarrying = true;
        }

        if (currentBox != null)
        {
            if (currentBox.isCarrying)
            {
                currentBox.Release();
                AnimHandler.AnimatorSetBoolValue("isCarrying", false);
                currentBox = null;
            }
            else if (currentBox.canCarry && !currentBox.isCarrying)
            {
                AnimHandler.AnimatorSetBoolValue("isCarrying", true);

                Vector2 offset = new Vector2(
                    Movement.FacingDirection < 1 ? -playerData.CarryPosOffset.y : playerData.CarryPosOffset.y,
                    playerData.CarryPosOffset.y);

                currentBox.Take(player.transform, offset, playerData.movementVelocity + playerData.drag, playerData.carryTime);
            }
        }
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        Movement.SetVelocityX(0);

        if (currentBox != null)
        {
            float diff = currentBox.transform.position.x - player.transform.position.x;
            int desiredDirection = diff > 0 ? 1 : -1;

            if (Movement.FacingDirection != desiredDirection)
            {
                Movement.Flip();
            }
        }

        if (Time.time > startTime + playerData.carryTime)
        {
            if (currentBox == null)
            {
                isCarrying = false;
            }
            isAbilityDone = true;
        }
    }

    public override void Exit()
    {
        base.Exit();
    }

    public bool IsCarrying() => isCarrying;
}

