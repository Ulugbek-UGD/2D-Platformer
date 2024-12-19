using UnityEngine.SceneManagement;
using UnityEngine;

namespace RedwoodTestTask
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private GameObject gameOverScreen;
        
        //============================================================
        private void OnEnable()
        {
            Player.OnDead += ShowGameOverScreen;
        }
        //============================================================
        private void OnDisable()
        {
            Player.OnDead -= ShowGameOverScreen;
        }
        //============================================================
        private void ShowGameOverScreen()
        {
            gameOverScreen.SetActive(true);
        }
        //============================================================
        public void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        //============================================================
        public void QuitGame()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
        //============================================================
    }
}