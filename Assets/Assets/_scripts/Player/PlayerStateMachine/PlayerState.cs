using Space.CoreSystem;
using UnityEngine;


namespace Space.FSM
{
    public class PlayerState
    {
        protected Core core;

        protected PlayerScript player;
        protected PlayerStateMachine stateMachine;
        protected PlayerData playerData;

        protected bool isAnimationFinished;
        protected bool isExitingState;

        protected float startTime;

        protected string animBoolName;

        protected AnimationHandler AnimHandler
        {
            get => animHandler ?? core.GetCoreComponent(ref animHandler);
        }

        private AnimationHandler animHandler;

        public PlayerState(PlayerScript player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName)
        {
            this.player = player;
            this.stateMachine = stateMachine;
            this.playerData = playerData;
            this.animBoolName = animBoolName;
            core = player.Core;
        }

        public virtual void Enter()
        {
            DoChecks();
            AnimHandler.AnimatorSetBoolValue(animBoolName, true);
            startTime = Time.time;
            if (playerData.Debug)
            {
                Debug.Log(animBoolName);
            }
            isAnimationFinished = false;
            isExitingState = false;
        }

        public virtual void Exit()
        {
            AnimHandler.AnimatorSetBoolValue(animBoolName, false);
            isExitingState = true;
        }

        public virtual void LogicUpdate()
        {

        }

        public virtual void PhysicsUpdate()
        {
            DoChecks();
        }

        public virtual void DoChecks() { }

        public virtual void AnimationTrigger() { }

        public virtual void AnimationFinishTrigger() => isAnimationFinished = true;


    }
}