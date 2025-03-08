using UnityEngine;

namespace Space.Objects
{
    public class IngredientBox : Box
    {
        private IngredientSO ingredientData; // ScriptableObject que contém os dados do ingrediente
        private bool isProcessed = false; // Verifica se o ingrediente já foi processado
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


        // Métodos para processar o ingrediente
        public void ProcessIngredient(string action)
        {
            if (isProcessed)
            {
                Debug.Log("Este ingrediente já foi processado.");
                return;
            }

            switch (action)
            {
                case "Cortar":
                    if (ingredientData.canBeCut)
                    {
                        Debug.Log($"{ingredientData.ingredientType} cortado!");
                        // Lógica para transformação após cortar
                        isProcessed = true;
                    }
                    else
                    {
                        Debug.Log("Este ingrediente não pode ser cortado.");
                    }
                    break;

                case "Misturar":
                    if (ingredientData.canBeMixed)
                    {
                        Debug.Log($"{ingredientData.ingredientType} misturado!");
                        // Lógica para transformação após misturar
                        isProcessed = true;
                    }
                    else
                    {
                        Debug.Log("Este ingrediente não pode ser misturado.");
                    }
                    break;

                case "Cozinhar":
                    if (ingredientData.canBeCooked)
                    {
                        Debug.Log($"{ingredientData.ingredientType} cozido!");
                        // Lógica para transformação após cozinhar
                        isProcessed = true;
                    }
                    else
                    {
                        Debug.Log("Este ingrediente não pode ser cozido.");
                    }
                    break;

                default:
                    Debug.Log("Ação inválida.");
                    break;
            }

            //if (isProcessed && ingredientData.ingredientPrefab != null)
            //{
            //    Instantiate(ingredientData.ingredientPrefab, transform.position, Quaternion.identity);
            //}
        }


    }
}
