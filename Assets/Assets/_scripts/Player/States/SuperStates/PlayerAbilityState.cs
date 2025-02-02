using Rickras.CoreSystem;
using Space.CoreSystem;
using UnityEngine;


namespace Space.FSM
{
    public class PlayerAbilityState : PlayerState
    {
        protected bool isAbilityDone;

        protected InteractionComponent Interaction
        {
            get => interaction ?? core.GetCoreComponent(ref interaction);
        }

        private InteractionComponent interaction;

        protected Movement Movement { get => movement ?? core.GetCoreComponent(ref movement); }
        private CollisionSenses CollisionSenses { get => collisionSenses ?? core.GetCoreComponent(ref collisionSenses); }

        private Movement movement;
        private CollisionSenses collisionSenses;

        private bool isGrounded;

        public PlayerAbilityState(PlayerScript player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
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

            isAbilityDone = false;
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (isAbilityDone)
            {
                if (isGrounded && Movement?.CurrentVelocity.y < 0.01f)
                {
                    stateMachine.ChangeState(player.IdleState);
                }
                else
                {
                    stateMachine.ChangeState(player.InAirState);
                }
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}