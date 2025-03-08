using UnityEngine;

namespace Space.Objects
{
    [CreateAssetMenu(fileName = "NewIngredient", menuName = "Ingredients/IngredientSO")]
    public class IngredientSO : ScriptableObject
    {
        public enum IngredientType
        {
            CarneLunar,
            CogumeloEstelar,
            RaizDeV�nus,
            PlasmaFrio,
            FrutoNebuloso,
            InsetoTitaniano,
            Tent�culoSolar,
            AlgaDeMarte
        }

        public string ingredientName;


        public IngredientType ingredientType;
        public Sprite ingredientSprite;



        public bool canBeCut;
        public bool canBeMixed;
        public bool canBeCooked;


        public string miniGameName;
    }
}
