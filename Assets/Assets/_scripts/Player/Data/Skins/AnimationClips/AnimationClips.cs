using UnityEngine;

public class AnimationClips : ScriptableObject
{
    [Header("Player Animations")]
    public AnimationClip idle;
    public AnimationClip walk;

    [Header("Primary Weapon Animations")]
    public AnimationClip primaryAttack1;
    public AnimationClip primaryAttack2;
    public AnimationClip primaryAttack3;

    [Header("Secondary Weapon Animations")]
    public AnimationClip secondaryAttack1;
    public AnimationClip secondaryAttack2;
    public AnimationClip secondaryAttack3;
}
