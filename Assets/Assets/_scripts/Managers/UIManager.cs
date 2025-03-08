using UnityEngine;
using Space.UI;
using Space.Objects;
using static Space.Managers.GameManager;

namespace Space.Managers
{
    public class UIManager : MonoBehaviour
    {


        [SerializeField] private PauseMenuUI pauseMenu;         // Referência ao script PauseMenu
        [SerializeField] private RecipeSelectorUI recipeSelector; // Referência ao script RecipeSelector


        private PlayerInputHandler playerInputHandler;

        private bool isPaused;

        private void Awake()
        {
            pauseMenu = GetComponentInChildren<PauseMenuUI>(true);
            recipeSelector = GetComponentInChildren<RecipeSelectorUI>(true);

            EventManager.RegisterEvent(EventKey.OpenRecipeSelector, ShowRecipeMenu);

            playerInputHandler = GameManager.Instance?.PlayerInputHandler;

        }

        private void Update()
        {
            // Debug para verificar se a pausa está sendo detectada

            if ((GameManager.Instance.currentState != GameState.PauseMenu && GameManager.Instance.currentState != GameState.SelectRecipe) && playerInputHandler.OpenMenuInput)
            {
                EventManager.TriggerEvent<GameState>(EventKey.ChangeGameEvent, GameState.PauseMenu);
                ShowPauseMenu();
            }
            else if (playerInputHandler.CloseMenuInput && GameManager.Instance.currentState != GameState.SelectRecipe)
            {
                EventManager.TriggerEvent<GameState>(EventKey.ChangeGameEvent, GameState.Playing);
                HidePauseMenu();
            }
            else if (playerInputHandler.CloseMenuInput && GameManager.Instance.currentState == GameState.SelectRecipe)
            {
                EventManager.TriggerEvent<GameState>(EventKey.ChangeGameEvent, GameState.Playing);
                HideRecipeMenu();

            }

        }


        public void ShowPauseMenu()
        {
            pauseMenu.gameObject.SetActive(true);
        }
        public void HidePauseMenu()
        {
            pauseMenu.gameObject.SetActive(false);
        }


        public void ShowRecipeMenu()
        {
            recipeSelector.gameObject.SetActive(true);
        }
        public void HideRecipeMenu()
        {
            recipeSelector.gameObject.SetActive(false);
        }
        public void HideAllMenus()
        {
            if (pauseMenu.gameObject.activeSelf)
            {
                HidePauseMenu();
            }
            else if (recipeSelector.gameObject.activeSelf)
            {

                HideRecipeMenu();
            }
        }



        private void OnDestroy()
        {
            EventManager.UnregisterEvent(EventKey.OpenRecipeSelector, ShowRecipeMenu);
        }
    }
}
