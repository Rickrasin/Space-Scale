using UnityEngine;
using UnityEngine.UI; // Necess�rio para Button
using TMPro;
using Space.Objects;
using Space.Managers;
using static Space.Managers.GameManager;

namespace Space.UI
{
    public class RecipeSelectorUI : MonoBehaviour
    {
        [SerializeField] private RecipeSO[] recipeList; // Lista de receitas para criar bot�es
        [SerializeField] private Transform listContent; // O conte�do onde os bot�es ser�o colocados
        [SerializeField] private GameObject buttonPrefab; // O conte�do onde os bot�es ser�o colocados

        // Start � chamado uma vez no in�cio
        void Start()
        {
            InitializeRecipes();
        }

        // Inicializa a lista de receitas criando bot�es
        public void InitializeRecipes()
        {
            // Limpa qualquer conte�do anterior
            foreach (Transform child in listContent)
            {
                Destroy(child.gameObject);
            }

            // Cria um bot�o para cada receita
            foreach (var recipe in recipeList)
            {
                GameObject buttonObject = Instantiate(buttonPrefab, listContent.transform);

                Button button = buttonObject.GetComponent<Button>();
                TextMeshProUGUI TMP = buttonObject.GetComponentInChildren<TextMeshProUGUI>();

                TMP.text = recipe?.recipeName;
                TMP.alignment = TextAlignmentOptions.Center;

                // Ajuste de estilo: fonte e cor
                TMP.fontSize = 36;
                TMP.enableAutoSizing = true;
                TMP.color = Color.black;

                // Ajusta a posi��o e o tamanho do texto
                RectTransform textRect = buttonObject.GetComponent<RectTransform>();

                // Adiciona a a��o ao clicar no bot�o
                button.onClick.AddListener(() => OnRecipeButtonClicked(recipe));

                RectTransform buttonRect = buttonObject.GetComponent<RectTransform>();
                buttonRect.sizeDelta = new Vector2(buttonRect.sizeDelta.x, 100); // Define o tamanho do bot�o
            }
        }

        // A��o quando o bot�o de receita for clicado
        private void OnRecipeButtonClicked(RecipeSO recipe)
        {
            EventManager.TriggerEvent<RecipeSO>(EventKey.SelectRecipe, recipe);
            EventManager.TriggerEvent<GameState>(EventKey.ChangeGameEvent, GameState.Playing);
            GameManager.Instance.UIManager.HideRecipeMenu();
        }
    }
}
