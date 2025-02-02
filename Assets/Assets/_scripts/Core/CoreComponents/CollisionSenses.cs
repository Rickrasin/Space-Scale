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
        [SerializeField] private bool Debug;


        [SerializeField] private float groundCheckRadius = 0.2f;

        [SerializeField] private LayerMask whatIsGround;

        #endregion

        public bool Ground
        {
            get => Physics2D.OverlapCircle(GroundCheck.position, groundCheckRadius, whatIsGround);
        }

        private void OnDrawGizmos()
        {
            if (Debug)
            {
                if (groundCheck == null) return;

                Gizmos.color = Ground ? Color.green : Color.red;
                Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);

            }
        }
    }
}
