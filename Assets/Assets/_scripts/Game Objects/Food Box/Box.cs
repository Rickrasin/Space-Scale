using UnityEngine;

namespace Space.Objects
{
    // Classe Base (Pai) para todas as caixas
    public class Box : MonoBehaviour
    {
        public bool canCarry { get; private set; } = true;
        protected Rigidbody2D rb;
        protected SpriteRenderer spriteRenderer;
        public bool isCarrying { get; private set; }
        private Transform player;

        protected virtual void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public void Take(Transform jogadorTransform)
        {
            if (canCarry && !isCarrying)
            {
                isCarrying = true;
                player = jogadorTransform;
                rb.bodyType = RigidbodyType2D.Kinematic;
                this.transform.parent = player;
            }
        }

        public void Release()
        {
            if (isCarrying)
            {
                isCarrying = false;
                player = null;
                rb.bodyType = RigidbodyType2D.Dynamic;
                this.transform.parent = null;
            }
        }

        public bool SetCanCarry(bool value) => canCarry = value;
    }
}
