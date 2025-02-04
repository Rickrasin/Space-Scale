using Rickras.CoreSystem;
using Space.CoreSystem;
using UnityEngine;


namespace Space.FSM
{

    public class PlayerGroundedState : PlayerState
    {
        protected int xInput;
        protected int yInput;

        protected InteractionComponent Interaction
        {
            get => interaction ?? core.GetCoreComponent(ref interaction);
        }

        private InteractionComponent interaction;

        protected Movement Movement
        {
            get => movement ?? core.GetCoreComponent(ref movement);
        }

        private Movement movement;

        private CollisionSenses CollisionSenses
        {
            get => collisionSenses ?? core.GetCoreComponent(ref collisionSenses);
        }

        private CollisionSenses collisionSenses;

        private bool jumpInput;
        private bool grabInput;

        private bool primaryActionInput;

        private bool isTouchingWall;
        private bool isTouchingLedge;
        private bool dashInput;

        private bool InteractionInput;

        private bool isGrounded;

        public PlayerGroundedState(PlayerScript player, PlayerStateMachine stateMachine, PlayerData playerData,
            string animBoolName) : base(player, stateMachine, playerData, animBoolName)
        {
        }

        public override void DoChecks()
        {
            base.DoChecks();

            if (CollisionSenses)
            {
                isGrounded = CollisionSenses.Ground;
            }
        }

        public override void Enter()
        {
            base.Enter();

            player.JumpState.ResetAmountOfJumpsLeft();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            xInput = player.InputHandler.NormInputX;
            yInput = player.InputHandler.NormInputY;
            jumpInput = player.InputHandler.JumpInput;
            dashInput = player.InputHandler.DashInput;
            InteractionInput = player.InputHandler.InteractionInput;


            if (jumpInput && player.JumpState.CanJump())
            {
                stateMachine.ChangeState(player.JumpState);
            }
            else if (InteractionInput && player.CarryState.CanCarry() && Interaction.HasInteractable<ICarryable>() && Interaction.GetInteractable<ICarryable>().CanCarry() || InteractionInput && player.CarryState.CanCarry() && player.CarryState.IsCarrying())
            {

                stateMachine.ChangeState(player.CarryState);
            }
            else if (InteractionInput && Interaction.HasInteractable<IInteractable>() && !player.InteractState.isInteract)
            {
                stateMachine.ChangeState(player.InteractState);
            }
            else if (!isGrounded)
            {
                player.InAirState.StartCoyoteTime();
                stateMachine.ChangeState(player.InAirState);
            }

        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}