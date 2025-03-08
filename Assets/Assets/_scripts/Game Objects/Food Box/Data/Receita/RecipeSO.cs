using UnityEngine;


namespace Space.Objects
{
    [CreateAssetMenu(fileName = "NewRecipe", menuName = "Recipes/RecipeSO")]
    public class RecipeSO : ScriptableObject
    {

        public enum RecipeType
        {
            GuisadoCosmico,
            SopaDeEstrelas,
            TentaculosGrelhados,
            EnsopadoAlienigena,
            BurguerNebuloso,
            TorradaSolar,
            SaladaVenusiana,
        }

        public RecipeType recipeType;
        [Space]
        public string recipeName;
        [Space]
        public Sprite spriteBox;
        [Space]
        public IngredientSO primaryIngredient;
        public IngredientSO secondaryIngredient;
        [Space]

        public Sprite foodSprite;

    }
}
