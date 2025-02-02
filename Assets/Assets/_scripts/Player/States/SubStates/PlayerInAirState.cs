using Space.CoreSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Space.FSM
{
    public class PlayerInAirState : PlayerState
    {

        protected Movement Movement { get => movement ?? core.GetCoreComponent(ref movement); }
        private CollisionSenses CollisionSenses { get => collisionSenses ?? core.GetCoreComponent(ref collisionSenses); }

        private Movement movement;
        private CollisionSenses collisionSenses;

        //Input
        private int xInput;
        private bool jumpInput;
        private bool jumpInputStop;
        private bool grabInput;
        private bool dashInput;

        //Checks
        private bool isGrounded;
        private bool isTouchingWall;
        private bool isTouchingWallBack;
        private bool oldIsTouchingWall;
        private bool oldIsTouchingWallBack;
        private bool isTouchingLedge;

        private bool coyoteTime;
        private bool wallJumpCoyoteTime;
        private bool isJumping;

        private float startWallJumpCoyoteTime;

        public PlayerInAirState(PlayerScript player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
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
        }

        public override void Exit()
        {
            base.Exit();


        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            CheckCoyoteTime();
            CheckWallJumpCoyoteTime();

            xInput = player.InputHandler.NormInputX;
            jumpInput = player.InputHandler.JumpInput;
            jumpInputStop = player.InputHandler.JumpInputStop;
            grabInput = player.InputHandler.InteractionInput;
            dashInput = player.InputHandler.DashInput;

            CheckJumpMultiplier();



            if (isGrounded && Movement?.CurrentVelocity.y < 0.01f)
            {
                stateMachine.ChangeState(player.LandState);
            }
            else if (jumpInput && player.JumpState.CanJump())
            {
                stateMachine.ChangeState(player.JumpState);
            }
            else
            {
                Movement?.CheckIfShouldFlip(xInput);
                Movement?.SetVelocityX(playerData.movementVelocity * xInput);

                AnimHandler.AnimatorSetFloatValue("yVelocity", Movement.CurrentVelocity.y);
                AnimHandler.AnimatorSetFloatValue("xVelocity", Mathf.Abs(Movement.CurrentVelocity.x));
            }

        }

        private void CheckJumpMultiplier()
        {
            if (isJumping)
            {
                if (jumpInputStop)
                {
                    Movement?.SetVelocityY(Movement.CurrentVelocity.y * playerData.variableJumpHeightMultiplier);
                    isJumping = false;
                }
                else if (Movement.CurrentVelocity.y <= 0f)
                {
                    isJumping = false;
                }

            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }

        private void CheckCoyoteTime()
        {
            if (coyoteTime && Time.time > startTime + playerData.coyoteTime)
            {
                coyoteTime = false;
                player.JumpState.DecreaseAmountOfJumpsLeft();
            }
        }

        private void CheckWallJumpCoyoteTime()
        {
            if (wallJumpCoyoteTime && Time.time > startWallJumpCoyoteTime + playerData.coyoteTime)
            {
                wallJumpCoyoteTime = false;
            }
        }

        public void StartCoyoteTime() => coyoteTime = true;

        public void SetIsJumping() => isJumping = true;
    }

}