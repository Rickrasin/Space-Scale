using Space.Managers;
using UnityEngine;

namespace Space.UI
{
    public class PauseMenuUI : MonoBehaviour
    {
        [SerializeField] private GameObject pauseMenuUI; // Referência ao menu de pausa

        public void PauseGame()
        {

            GameManager.Instance.SetGameState(GameManager.GameState.PauseMenu);  // Exibe o menu de pausa
        }

        public void ResumeGame()
        {
            GameManager.Instance.SetGameState(GameManager.GameState.Playing);  // Exibe o menu de pausa

        }

        public void ShowOptions()
        {
            Debug.Log("Options Menu");    // Marca que o jogo está pausado
        }

        public void QuitGame()
        {
            Time.timeScale = 1f;          // Garante que o tempo volte ao normal antes de sair
            UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenuScene");
        }

    }
}
