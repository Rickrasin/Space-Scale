using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newPlayerData", menuName = "Data/Player Data/Base Data")]
public class PlayerData : ScriptableObject
{
    [Header("Move State")]
    public float movementVelocity = 10f;

    [Header("Jump State")]
    public float jumpVelocity = 12f;
    public int amountOfJumps = 1;

    [Header("In Air State")]
    public float coyoteTime = 0.2f;
    public float variableJumpHeightMultiplier = 0.5f;

    [Header("Carry State")]
    public Vector2 CarryPosOffset = new Vector2(1, 1);

    public float carryJumpVelocity = 8f;
    public float carryMovementVelocity = 7f;

    public float drag = -0.8f;

    public float smoothTime = 0.3f;
    public float carryTime = 0.2f;


    [Header("Other Options")]
    public bool Debug = true;
}