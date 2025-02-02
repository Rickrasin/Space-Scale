using System.Collections;
using System.Collections.Generic;
using UnityEditor.AnimatedValues;
using UnityEngine;

namespace Space.FSM
{
    public class PlayerLandState : PlayerGroundedState
    {
        public PlayerLandState(PlayerScript player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
        {
        }

        public override void DoChecks()
        {
            base.DoChecks();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (player.CarryState.IsCarrying())
            {

                isAnimationFinished = AnimHandler.HasAnimationFinished("LandCarry", 0);
            }
            else
            {
                isAnimationFinished = AnimHandler.HasAnimationFinished("Land", 0);

            }

            if (!isExitingState)
            {
                if (xInput != 0)
                {
                    stateMachine.ChangeState(player.MoveState);
                }
                else if (isAnimationFinished)
                {
                    stateMachine.ChangeState(player.IdleState);
                }
            }
        }
    }
}