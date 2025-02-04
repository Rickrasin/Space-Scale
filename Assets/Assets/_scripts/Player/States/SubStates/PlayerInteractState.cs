using Space.FSM;
using Space.Objects;
using UnityEngine;

namespace Space.FSM
{
    public class PlayerInteractState : PlayerAbilityState
    {
        public bool isInteract { get; private set; }

        public PlayerInteractState(PlayerScript player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName)
            : base(player, stateMachine, playerData, animBoolName)
        {
        }

        public override void Enter()
        {
            base.Enter();
            isInteract = true;


            IInteractable interactable = Interaction.GetInteractable<IInteractable>();


            if (interactable != null)
            {
                interactable.Interact();
            }
            else
            {
                Debug.LogWarning("Nenhum objeto interagível encontrado.");
            }



            isAbilityDone = true;

        }



        public override void Exit()
        {
            base.Exit();
            isInteract = false;

        }

    }

}