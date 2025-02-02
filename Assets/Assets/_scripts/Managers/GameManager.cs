using UnityEngine;
using UnityEngine.SceneManagement;

namespace Space.Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }
        public UIManager UIManager { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            GameObject uiObject = GameObject.FindGameObjectWithTag("UIManager");
            if (uiObject != null)
            {
                UIManager = uiObject.GetComponent<UIManager>();
            }
            else
            {
                Debug.LogError("UIManager não encontrado! Certifique-se de que o GameObject tem a tag 'UIManager'.");
            }
        }

        public void StartGame()
        {
            SceneManager.LoadScene(SceneNames.GameScene); // Agora usa o struct para evitar erros de digitação
        }

        public void ReturnToMenu()
        {
            SceneManager.LoadScene(SceneNames.MainMenu);
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}
