using UnityEngine;
using UnityEngine.UIElements;

namespace Space.Objects.Stations
{
    public class DeliverySlot : MonoBehaviour
    {
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

        public void SpawnBox(GameObject boxPrefab)
        {
            if (canSpawn)
            {
                IsOccupied = true;
                startTime = Time.time;
                canSpawn = false;
                GameObject box = Instantiate(boxPrefab, spawnPoint.position, Quaternion.identity);
                box.layer = LayerMask.NameToLayer("Box");
            }
        }
        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Box"))
            {
                IsOccupied = false;
                Box box = collision.gameObject.GetComponent<Box>();
                box.SetSortingLayerOrder(8);
                collision.gameObject.layer = LayerMask.NameToLayer("Carryable");
            }
        }
    }
}
