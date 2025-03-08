using UnityEngine;

namespace Space.Objects
{
    public class Box : MonoBehaviour, ICarryable
    {
        protected Rigidbody2D rb;
        protected SpriteRenderer spriteRenderer;
        private Transform player;

        private Vector2 offset;
        protected bool canCarry = true;
        [SerializeField] private Sprite boxSprite;
        [SerializeField] private float followSpeed = 10f;

        private bool isCarrying;
        private bool isRising = false;
        private float riseTimer = 0f;
        private float carryDuration = 0f;
        private Vector2 initialBoxPosition;
        private Vector2 targetBoxPosition;

        protected virtual void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            spriteRenderer = GetComponent<SpriteRenderer>();

            if (boxSprite != null) spriteRenderer.sprite = boxSprite;

            canCarry = true;

        }

        public void Take(Transform playerTransform, Vector2 offset, float followSpeed, float duration)
        {
            if (player != null) return; // Evita pegar o mesmo objeto duas vezes

            isCarrying = true;
            player = playerTransform;
            this.offset = offset;
            this.followSpeed = followSpeed;

            rb.gravityScale = 0;
            rb.linearVelocity = Vector2.zero;

            isRising = true;
            riseTimer = 0f;
            carryDuration = duration;
            initialBoxPosition = rb.position;
            targetBoxPosition = (Vector2)player.position + offset;
            canCarry = false;
        }

        public void Release()
        {
            if (player == null) return;

            player = null;
            isCarrying = false;
            isRising = false;
            canCarry = true;
            rb.gravityScale = 5;
        }

        private void FixedUpdate()
        {
            if (player != null)
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

        public Transform GetTransform() => gameObject.transform;

        public bool CanCarry() => canCarry;
        public bool IsCarrying() => isCarrying;
    }
}
