using Space.CoreSystem;
using Space.FSM;
using Space.Objects;
using UnityEngine;


namespace Space.FSM
{
    public class PlayerCarryState : PlayerAbilityState
    {
        private bool canCarry = true;

        private bool playTimer;
        private bool isRelease;

        private ICarryable currentObject;

        public PlayerCarryState(PlayerScript player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName)
            : base(player, stateMachine, playerData, animBoolName)
        {
        }

        public override void Enter()
        {
            base.Enter();

            canCarry = false;

            if (currentObject == null)
            {
                playTimer = true;
                isRelease = false;

                currentObject = Interaction.GetInteractable<ICarryable>();

                Movement.SetVelocityX(0);

                AnimHandler.AnimatorSetBoolValue("isCarrying", true);

                Vector2 offset = new Vector2(
                        Movement.FacingDirection < 1 ? -playerData.CarryPosOffset.y : playerData.CarryPosOffset.y,
                        playerData.CarryPosOffset.y);

                currentObject.Take(player.transform, offset, playerData.movementVelocity + playerData.drag, playerData.carryTime);
            }
            else
            {
                Movement.SetVelocityX(0);
                AnimHandler.AnimatorSetBoolValue("isCarrying", true);
                currentObject.Release();
                playTimer = true;
                isRelease = true;


            }

        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            Movement.SetVelocityX(0);

            if (currentObject != null)
            {
                float diff = currentObject.GetTransform().position.x - player.transform.position.x;
                int desiredDirection = diff > 0 ? 1 : -1;

                if (Movement.FacingDirection != desiredDirection)
                {
                    Movement.Flip();
                }
            }

            if (playTimer && !isRelease && Time.time > startTime + playerData.carryTime)
            {
                playTimer = false;
                isAbilityDone = true;
            }

            if (playTimer && isRelease && Time.time > startTime + playerData.carryTime)
            {
                currentObject = null;
                currentObject = null;
                AnimHandler.AnimatorSetBoolValue("isCarrying", false);
                isRelease = false;
                playTimer = false;
                isAbilityDone = true;

            }
        }

        public override void Exit()
        {
            base.Exit();
            canCarry = true;
        }

        public bool IsCarrying() => currentObject != null;
        public bool CanCarry() => canCarry;
    }
}