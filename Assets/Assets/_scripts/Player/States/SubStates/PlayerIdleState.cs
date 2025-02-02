using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Space.FSM
{
    public class PlayerIdleState : PlayerGroundedState
    {
        public PlayerIdleState(PlayerScript player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
        {
        }

        public override void DoChecks()
        {
            base.DoChecks();
        }

        public override void Enter()
        {
            base.Enter();
            Movement?.SetVelocityX(0f);
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (!isExitingState)
            {
                if (xInput != 0)
                {
                    stateMachine.ChangeState(player.MoveState);
                }


            }
        }


        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}