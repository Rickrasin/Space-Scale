using UnityEngine;
using UnityEngine.UI; // Necessário para Button
using TMPro;
using Space.Objects;
using Space.Managers;
using static Space.Managers.GameManager;

namespace Space.UI
{
    public class RecipeSelectorUI : MonoBehaviour
    {
        [SerializeField] private RecipeSO[] recipeList; // Lista de receitas para criar botões
        [SerializeField] private Transform listContent; // O conteúdo onde os botões serão colocados
        [SerializeField] private GameObject buttonPrefab; // O conteúdo onde os botões serão colocados

        // Start é chamado uma vez no início
        void Start()
        {
            InitializeRecipes();
        }

        // Inicializa a lista de receitas criando botões
        public void InitializeRecipes()
        {
            // Limpa qualquer conteúdo anterior
            foreach (Transform child in listContent)
            {
                Destroy(child.gameObject);
            }

            // Cria um botão para cada receita
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

                // Ajusta a posição e o tamanho do texto
                RectTransform textRect = buttonObject.GetComponent<RectTransform>();

                // Adiciona a ação ao clicar no botão
                button.onClick.AddListener(() => OnRecipeButtonClicked(recipe));

                RectTransform buttonRect = buttonObject.GetComponent<RectTransform>();
                buttonRect.sizeDelta = new Vector2(buttonRect.sizeDelta.x, 100); // Define o tamanho do botão
            }
        }

        // Ação quando o botão de receita for clicado
        private void OnRecipeButtonClicked(RecipeSO recipe)
        {
            EventManager.TriggerEvent<RecipeSO>(EventKey.SelectRecipe, recipe);
            EventManager.TriggerEvent<GameState>(EventKey.ChangeGameEvent, GameState.Playing);
            GameManager.Instance.UIManager.HideRecipeMenu();
        }
    }
}
