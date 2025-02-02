using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Space.FSM
{
    public class PlayerMoveState : PlayerGroundedState
    {
        public PlayerMoveState(PlayerScript player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
        {
        }

        public override void DoChecks()
        {
            base.DoChecks();
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

            if (!player.CarryState.IsCarrying())
            {

                Movement?.CheckIfShouldFlip(xInput);
            }

            float moveVelocity = player.CarryState.IsCarrying() ? playerData.carryMovementVelocity : playerData.movementVelocity;
            Movement?.SetVelocityX(moveVelocity * xInput);

            if (!isExitingState)
            {
                if (xInput == 0)
                {
                    stateMachine.ChangeState(player.IdleState);

                }
            }
        }


        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}