using UnityEngine;

namespace Space.CoreSystem
{
    public class CollisionSenses : CoreComponent
    {
        private Movement Movement { get => movement ?? core.GetCoreComponent(ref movement); }

        private Movement movement;

        #region Check Transforms

        public Transform GroundCheck
        {
            get => GenericNotImplementedError<Transform>.TryGet(groundCheck, core.transform.parent.name);
            private set => groundCheck = value;
        }

        [SerializeField] private Transform groundCheck;

        [SerializeField] private float groundCheckRadius;

        [SerializeField] private LayerMask whatIsGround;

        #endregion

        public bool Ground
        {
            get => Physics2D.OverlapCircle(GroundCheck.position, groundCheckRadius, whatIsGround);
        }

    }

}
