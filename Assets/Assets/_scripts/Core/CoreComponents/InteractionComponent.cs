using Space.CoreSystem;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

namespace Rickras.CoreSystem
{
    public class InteractionComponent : CoreComponent
    {
        private CollisionSenses CollisionSenses => collisionSenses ?? core.GetCoreComponent(ref collisionSenses);
        private CollisionSenses collisionSenses;

        [SerializeField] private float interactionRadius = 1f;
        [SerializeField] private UnityEngine.Transform interactionTransform; // Define quais objetos podem ser interagidos
        [SerializeField] private LayerMask interactionLayer; // Define quais objetos podem ser interagidos

        public T GetInteractable<T>() where T : MonoBehaviour
        {
            if (core == null)
            {
                Debug.LogWarning("Core não foi inicializado no InteractionComponent!");
                return null;
            }

            Collider2D[] detectedObjects = Physics2D.OverlapCircleAll(interactionTransform.position, interactionRadius, interactionLayer);

            foreach (Collider2D collider in detectedObjects)
            {
                T interactable = collider.GetComponent<T>();
                if (interactable != null)
                {
                    return interactable;
                }
            }

            return null;
        }

        public bool HasInteractable<T>() where T : MonoBehaviour
        {
            return GetInteractable<T>() != null;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(interactionTransform.position, interactionRadius);
        }
    }
}
