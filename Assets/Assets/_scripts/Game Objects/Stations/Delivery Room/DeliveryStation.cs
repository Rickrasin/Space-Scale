using UnityEngine;
using Space.Managers;

namespace Space.Objects.Stations
{
    public class DeliveryStation : MonoBehaviour
    {
        [SerializeField] private DeliverySlot[] deliverySlots;
        [SerializeField] private Sprite boxSprite;



        private void Start()
        {
            deliverySlots = GetComponentsInChildren<DeliverySlot>();
            EventManager.RegisterEvent<RecipeSO>(EventKey.SelectRecipe, InvokeBoxes);

        }


        public void InvokeBoxes(RecipeSO recipe)
        {

            if (!deliverySlots[0].IsOccupied)
            {
                deliverySlots[0].SpawnBox(recipe.primaryIngredient, boxSprite);
            }

            if (!deliverySlots[1].IsOccupied)
            {
                deliverySlots[1].SpawnBox(recipe.secondaryIngredient, boxSprite);
            }
        }

        private void OnDestroy()
        {
            EventManager.UnregisterEvent<RecipeSO>(EventKey.SelectRecipe, InvokeBoxes);
        }

    }
}
