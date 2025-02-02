using Space.CoreSystem;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;

namespace Space.CoreSystem
{
    public class AnimationHandler : CoreComponent
    {
        public Animator PlayerAnimator { get; private set; }
        public SpriteRenderer PlayerSpriteRenderer { get; private set; }

        [SerializeField]
        private AnimatorController PlayerBaseAnimatorController;


        private AnimatorOverrideController PlayerOverrideController;
        private AnimatorOverrideController PrimaryWeaponOverrideController;

        [SerializeField]
        private bool debug;


        protected override void Awake()
        {
            base.Awake();

            PlayerAnimator = GetComponent<Animator>();

            PlayerSpriteRenderer = GetComponent<SpriteRenderer>();

        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
        }

        #region Animator Controllers

        /// <summary>
        ///  D� Play direto em uma anima��o pelo nome (sem precisar de Trigger).
        ///  �til quando voc� sabe exatamente qual Clip quer tocar.
        /// </summary>
        public void PlayAnimation(string animationName, int layer = 0, float normalizedTime = 0f)
        {
            PlayerAnimator.Play(animationName, layer, normalizedTime);
        }

        /// <summary>
        ///  Define um Trigger no Animator, caso voc� ainda queira usar o modelo de Trigger para transi��es
        /// </summary>
        public void SetAnimationTrigger(string triggerName)
        {
            PlayerAnimator.SetTrigger(triggerName);
        }

        /// <summary>
        ///  Reseta um Trigger no Animator
        /// </summary>
        public void ResetAnimationTrigger(string triggerName)
        {
            PlayerAnimator.ResetTrigger(triggerName);
        }

        /// <summary>
        /// M�todo para alterar o valor de um par�metro Booleano no animator.
        /// </summary>
        /// <param name="AnimBoolName">Nome do par�metro</param>
        /// <param name="value">Valor do par�metro, Tipo Booleano</param>
        public void AnimatorSetBoolValue(string AnimBoolName, bool value)
        {
            PlayerAnimator.SetBool(AnimBoolName, value);
        }

        /// <summary>
        /// M�todo para alterar o valor de um par�metro Float no animator.
        /// </summary>
        /// <param name="AnimBoolName">Nome do par�metro</param>
        /// <param name="value">Valor do par�metro, Tipo Float</param>
        public void AnimatorSetFloatValue(string AnimBoolName, float value)
        {
            PlayerAnimator.SetFloat(AnimBoolName, value);
        }

        /// <summary>
        ///  M�todo para ser chamado via Animation Event (antes ficava no PlayerScript).
        ///  Voc� pode disparar l�gica espec�fica do evento de anima��o por aqui.
        /// </summary>
        public void AnimationTrigger()
        {
            // Coloque aqui a l�gica que antes estava no "AnimationTrigger" do PlayerScript
            // Exemplo: emitir um evento do C# ou chamar outro m�todo do seu Player.
            // Ex: player.OnAnimationTrigger();
        }

        /// <summary>
        ///  M�todo para ser chamado via Animation Event (antes ficava no PlayerScript).
        ///  Voc� pode disparar l�gica de fim de anima��o por aqui.
        /// </summary>
        public void AnimationFinishTrigger()
        {
            // Coloque aqui a l�gica que antes estava no "AnimationFinishTrigger" do PlayerScript
            // Exemplo: notificar a state machine que a anima��o terminou.
            // Ex: player.OnAnimationFinish();
        }

        /// <summary>
        /// Verifica se determinada anima��o terminou (normalizedTime >= 1).
        /// </summary>
        /// <param name="animationName">Nome exato do state no Animator Controller</param>
        /// <param name="layer">�ndice da camada (normalmente 0)</param>
        /// <returns>Verdadeiro se a anima��o estiver conclu�da e n�o houver transi��o.</returns>
        public bool HasAnimationFinished(string animationName, int layer = 0)
        {
            AnimatorStateInfo stateInfo = PlayerAnimator.GetCurrentAnimatorStateInfo(layer);

            

            // Verifica se a animação atual é a que buscamos,
            // se o normalizedTime passou do threshold (0.99) e não está em transição.
            return stateInfo.IsName(animationName)
                   && stateInfo.normalizedTime >= 0.99f
                   && !PlayerAnimator.IsInTransition(layer);

           
        }


        #endregion

    }
}
