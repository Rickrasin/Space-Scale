using UnityEngine;
using UnityEngine.UIElements;

namespace Space.Objects.Stations
{
    public class DeliverySlot : MonoBehaviour
    {
        [SerializeField] private string stationSortingLayer;
        [SerializeField] private string boxSortingLayer;
        [SerializeField] private LayerMask boxLayer;
        [SerializeField] private Transform spawnPoint;

        private BoxCollider2D boxCollider;

        private float startTime;

        public bool IsOccupied { get; private set; }
        private float spawnDuringTime = 1;
        private bool canSpawn = true;

        private void Start()
        {
            boxCollider = GetComponent<BoxCollider2D>();

        }

        private void Update()
        {
            IsOccupied = CheckForBox();

            if (Time.time >= startTime + spawnDuringTime)
            {
                canSpawn = true;
            }
        }

        private bool CheckForBox()
        {
            Collider2D detectedObject = Physics2D.OverlapBox(transform.position, boxCollider.bounds.size, 0, boxLayer);
            return detectedObject != null && detectedObject.GetComponent<Box>() != null;
        }

        public void SpawnBox(IngredientSO recipe, Sprite boxSprite)
        {
            if (canSpawn)
            {
                IsOccupied = true;
                startTime = Time.time;
                canSpawn = false;
                GameObject box = Instantiate(new GameObject(recipe.name), spawnPoint.position, Quaternion.identity);
                SpriteRenderer spriteRenderer = box.AddComponent<SpriteRenderer>();
                spriteRenderer.sprite = boxSprite;
                box.AddComponent<Rigidbody2D>();
                box.AddComponent<BoxCollider2D>();
                box.tag = "Box";
                box.layer = LayerMask.NameToLayer("Box");
                spriteRenderer.sortingLayerName = "Station";
                spriteRenderer.sortingOrder = 6;
                IngredientBox ingredientBox = box.AddComponent<IngredientBox>();
                ingredientBox.SetIngredientData(recipe);
            }
        }
        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Box"))
            {
                IsOccupied = false;
                Box box = collision.gameObject.GetComponent<Box>();
                SpriteRenderer spriteRenderer = box.GetComponent<SpriteRenderer>();
                spriteRenderer.sortingLayerName = "Box";
                spriteRenderer.sortingOrder = 1;
                collision.gameObject.layer = LayerMask.NameToLayer("Carryable");
            }
        }
    }
}
