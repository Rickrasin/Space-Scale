using Space.FSM;
using Space.Objects;
using System;
using UnityEngine;

public class PlayerCarryState : PlayerAbilityState
{

    private Box BoxScript;

    public PlayerCarryState(PlayerScript player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        BoxScript = Interaction.GetInteractable<Box>();

        Debug.Log(BoxScript);

        if (BoxScript != null)
        {
            if (BoxScript.isCarrying)
            {
                Debug.Log("Executado Release");
                BoxScript.Release();
            }
            else if (BoxScript.canCarry && !BoxScript.isCarrying)
            {
                Debug.Log("Executado Take");
                BoxScript.Take(player.transform);
                BoxScript.gameObject.GetComponent<Rigidbody2D>().MovePosition(player.transform.position + (Vector3)playerData.CarryPosOffset);
            }
        }

    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (Time.time > startTime + playerData.carryTime)
        {
            isAbilityDone = true;
        }

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
