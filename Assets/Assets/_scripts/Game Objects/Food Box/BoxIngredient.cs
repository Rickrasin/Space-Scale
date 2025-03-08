using UnityEngine;

namespace Space.Objects
{
    public class IngredientBox : Box
    {
        private IngredientSO ingredientData; // ScriptableObject que cont�m os dados do ingrediente
        private bool isProcessed = false; // Verifica se o ingrediente j� foi processado
        private SpriteRenderer ingredientSpriteRender;

        public void SetIngredientData(IngredientSO ingredientData)
        {
            this.ingredientData = ingredientData;
        }

        protected override void Awake()
        {
            base.Awake();

            //GameObject childGO = new GameObject(ingredientData.ingredientName);
            //childGO.transform.parent = this.transform;

            //ingredientSpriteRender = childGO.AddComponent<SpriteRenderer>();

            //ingredientSpriteRender.sprite = ingredientData.ingredientSprite;


        }


        // M�todos para processar o ingrediente
        public void ProcessIngredient(string action)
        {
            if (isProcessed)
            {
                Debug.Log("Este ingrediente j� foi processado.");
                return;
            }

            switch (action)
            {
                case "Cortar":
                    if (ingredientData.canBeCut)
                    {
                        Debug.Log($"{ingredientData.ingredientType} cortado!");
                        // L�gica para transforma��o ap�s cortar
                        isProcessed = true;
                    }
                    else
                    {
                        Debug.Log("Este ingrediente n�o pode ser cortado.");
                    }
                    break;

                case "Misturar":
                    if (ingredientData.canBeMixed)
                    {
                        Debug.Log($"{ingredientData.ingredientType} misturado!");
                        // L�gica para transforma��o ap�s misturar
                        isProcessed = true;
                    }
                    else
                    {
                        Debug.Log("Este ingrediente n�o pode ser misturado.");
                    }
                    break;

                case "Cozinhar":
                    if (ingredientData.canBeCooked)
                    {
                        Debug.Log($"{ingredientData.ingredientType} cozido!");
                        // L�gica para transforma��o ap�s cozinhar
                        isProcessed = true;
                    }
                    else
                    {
                        Debug.Log("Este ingrediente n�o pode ser cozido.");
                    }
                    break;

                default:
                    Debug.Log("A��o inv�lida.");
                    break;
            }

            //if (isProcessed && ingredientData.ingredientPrefab != null)
            //{
            //    Instantiate(ingredientData.ingredientPrefab, transform.position, Quaternion.identity);
            //}
        }


    }
}
