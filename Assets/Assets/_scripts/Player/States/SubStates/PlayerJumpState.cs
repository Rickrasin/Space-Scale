﻿
using UnityEngine;

namespace Space.FSM
{
    public class PlayerJumpState : PlayerAbilityState
    {
        private int amountOfJumpsLeft;

        public PlayerJumpState(PlayerScript player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
        {
            amountOfJumpsLeft = playerData.amountOfJumps;
        }

        public override void Enter()
        {
            base.Enter();
            player.InputHandler.UseJumpInput();

            Movement?.SetVelocityY(player.CarryState.IsCarrying() ? playerData.carryJumpVelocity : playerData.jumpVelocity);

            isAbilityDone = true;
            amountOfJumpsLeft--;
            player.InAirState.SetIsJumping();
        }

        public bool CanJump()
        {
            if (amountOfJumpsLeft > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ResetAmountOfJumpsLeft() => amountOfJumpsLeft = playerData.amountOfJumps;

        public void DecreaseAmountOfJumpsLeft() => amountOfJumpsLeft--;
    }
}