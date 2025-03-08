using Space.FSM;
using Space.Objects;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace Space.Managers
{
    public class GameManager : MonoBehaviour
    {
        public enum GameState
        {
            MainMenu,    // Menu Principal
            PauseMenu,    // Pause 
            Playing,     // Jogo em Execução
            SelectRecipe, // Selecionando Receita
            GameOver     // Tela de Game Over
        }

        public static GameManager Instance { get; private set; }
        public GameObject player { get; private set; }
        public PlayerInputHandler PlayerInputHandler { get; private set; }
        public UIManager UIManager { get; private set; }


        [SerializeField] private GameState startState;

        [SerializeField] private List<RecipeSO> RecipeList;


        public GameState currentState { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject); // Faz o GameManager persistir entre as cenas
            }
            else
            {
                Destroy(gameObject);
            }

            if (player == null) player = GameObject.FindWithTag("Player");
            PlayerInputHandler = GetComponent<PlayerInputHandler>();
            UIManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();

        }

        private void Start()
        {

            EventManager.RegisterEvent<GameState>(EventKey.ChangeGameEvent, SetGameState);

            SetGameState(startState); // Começa no Menu Principal
        }

        public void SetGameState(GameState newState)
        {
            currentState = newState;
            HandleStateChange();
        }

        private void HandleStateChange()
        {
            switch (currentState)
            {
                case GameState.MainMenu:

                    break;

                case GameState.PauseMenu:
                    PauseGame();
                    break;

                case GameState.Playing:
                    StartGame();
                    break;

                case GameState.SelectRecipe:
                    SelectRecipe();

                    break;

                case GameState.GameOver:
                    break;
            }
        }

        private void StartGame()
        {
            Debug.Log("Jogo iniciado");
            UIManager.HideAllMenus();
            Time.timeScale = 1.0f;
            player.GetComponent<PlayerScript>().enabled = true;
            PlayerInputHandler.GameInputs?.Gameplay.Enable();
            PlayerInputHandler.GameInputs?.UI.Disable();


        }
        private void PauseGame()
        {
            UIManager.ShowPauseMenu();
            player.GetComponent<PlayerScript>().enabled = false;
            Time.timeScale = 0;
            PlayerInputHandler.GameInputs?.UI.Enable();
            PlayerInputHandler.GameInputs?.Gameplay.Disable();
        }

        private void SelectRecipe()
        {
            UIManager.ShowRecipeMenu();
            PlayerInputHandler.GameInputs?.UI.Enable();
            PlayerInputHandler.GameInputs?.Gameplay.Disable();
        }

        private void OnDestroy()
        {
            EventManager.UnregisterEvent<GameState>(EventKey.ChangeGameEvent, SetGameState);
        }


    }



}
