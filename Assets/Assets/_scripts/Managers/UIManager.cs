using UnityEngine;

namespace Space.Managers
{
    public class UIManager : MonoBehaviour
    {
        public void PlayGame()
        {
            GameManager.Instance.StartGame();
        }

        public void OpenOptions()
        {
            Debug.Log("Op��es abertas"); // Pode ser um painel simples
        }

        public void QuitGame()
        {
            GameManager.Instance.QuitGame();
        }
    }
}



