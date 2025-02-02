using UnityEngine;

[CreateAssetMenu(fileName = "NewPlayerSkinData", menuName = "Game/Skins/PlayerSkinData")]
public class PlayerSkinData : ScriptableObject
{
    [Header("Skin Info")]
    public string skinName; // Nome da skin
    public Sprite skinIcon; // �cone da skin no invent�rio

    [Header("Animations")]
    public PlayerAnimationClips PlayerAnimationClips; // Refer�ncia ao ScriptableObject com os AnimationClips
    public WeaponAnimationClips PrimaryWeaponAnimationClips; // Refer�ncia ao ScriptableObject com os AnimationClips

    [Header("Animator Override")]
    public AnimatorOverrideController skinOverrideAnimator; // Override do Animator associado a essa skin
}
