using Space.CoreSystem;
using UnityEngine;


namespace Rickras.CoreSystem
{
    public class InteractionComponent : CoreComponent
    {
        private CollisionSenses CollisionSenses => collisionSenses ?? core.GetCoreComponent(ref collisionSenses);
        private CollisionSenses collisionSenses;

        [SerializeField] private Collider2D col;
        [SerializeField] private UnityEngine.Transform interactionTransform; // Define quais objetos podem ser interagidos
        [SerializeField] private LayerMask interactionLayer; // Define quais objetos podem ser interagidos

        protected override void Awake()
        {
            base.Awake();

            col = GetComponentInChildren<Collider2D>();
        }

        public T GetInteractable<T>() where T : class
        {
            Collider2D[] detectedObjects = Physics2D.OverlapBoxAll(col.bounds.center, col.bounds.size, 0, interactionLayer);

            foreach (Collider2D collider in detectedObjects)
            {
                MonoBehaviour component = collider.GetComponent<MonoBehaviour>();

                if (component is T interactable)
                {
                    return interactable;
                }
            }

            return null;
        }

        public bool HasInteractable<T>() where T : class
        {
            return GetInteractable<T>() != null;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawCube(col.bounds.center, col.bounds.size);
        }


    }
}
