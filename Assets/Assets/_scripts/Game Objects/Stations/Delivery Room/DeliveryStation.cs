using UnityEngine;

namespace Space.Objects.Stations
{
    public class DeliveryStation : MonoBehaviour
    {
        [SerializeField] private DeliverySlot[] deliverySlots;
        [SerializeField] private GameObject boxPrefab;
        [SerializeField] private ButtonAction buttonAction;

        private void Start()
        {
            deliverySlots = GetComponentsInChildren<DeliverySlot>();
            buttonAction = GetComponentInChildren<ButtonAction>();

        }


        public void Execute()
        {
            foreach (DeliverySlot slot in deliverySlots)
            {
                if (!slot.IsOccupied)
                {
                    slot.SpawnBox(boxPrefab);
                }
            }
        }
    }
}
