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
            RaizDeVênus,
            PlasmaFrio,
            FrutoNebuloso,
            InsetoTitaniano,
            TentáculoSolar,
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
