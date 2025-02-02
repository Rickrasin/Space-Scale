using UnityEngine;

namespace Space.Objects
{
    public class Box : MonoBehaviour
    {
        protected Rigidbody2D rb;
        protected SpriteRenderer spriteRenderer;
        private Transform player;

        private Vector2 offset;
        [SerializeField] private float followSpeed = 10f; // Pode ser ajustado no Inspector

        public bool canCarry { get; private set; } = true;
        public bool isCarrying { get; private set; }

        private bool isRising = false;
        private float riseTimer = 0f;
        private float carryDuration = 0f;
        private Vector2 initialBoxPosition;
        private Vector2 targetBoxPosition;

        protected virtual void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public void Take(Transform jogadorTransform, Vector2 offset, float followSpeed, float duration)
        {
            if (canCarry && !isCarrying)
            {
                isCarrying = true;
                player = jogadorTransform;
                this.offset = offset;
                this.followSpeed = followSpeed; // Atualiza a velocidade

                rb.gravityScale = 0;
                rb.linearVelocity = Vector2.zero;

                isRising = true;
                riseTimer = 0f;
                carryDuration = duration;
                initialBoxPosition = rb.position;
                targetBoxPosition = (Vector2)player.position + offset;
            }
        }

        public void Release()
        {
            if (isCarrying)
            {
                isCarrying = false;
                isRising = false;
                player = null;
                rb.gravityScale = 5;
            }
        }

        private void FixedUpdate()
        {
            if (isCarrying && player != null)
            {
                if (isRising)
                {
                    riseTimer += Time.fixedDeltaTime;
                    float t = Mathf.Clamp01(riseTimer / carryDuration);
                    Vector2 newPos = Vector2.Lerp(initialBoxPosition, targetBoxPosition, t);
                    rb.MovePosition(newPos);

                    if (t >= 1f)
                        isRising = false;
                }
                else
                {
                   
                    Vector2 followTarget = (Vector2)player.position + offset;
                    Vector2 velocity = Vector2.zero;

                    Vector2 newPos = Vector2.Lerp(rb.position, followTarget, followSpeed * Time.fixedDeltaTime);
                    rb.MovePosition(newPos);
                }
            }
        }

        private void OnDrawGizmos()
        {
            if (isCarrying)
            {
                Gizmos.color = Color.green;
                Gizmos.DrawWireSphere(transform.position, 0.5f);
            }
        }

        public bool SetCanCarry(bool value) => canCarry = value;
    }
}
