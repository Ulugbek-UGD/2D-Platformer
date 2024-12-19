using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine;

namespace RedwoodTestTask
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private InputAction quitKey;
        [SerializeField] private GameObject gameOverScreen;
        
        //============================================================
        private void OnEnable()
        {
            Player.OnDead += ShowGameOverScreen;
            
            quitKey.Enable();
            quitKey.performed += OnQuitKeyPerformed;
        }
        //============================================================
        private void OnDisable()
        {
            Player.OnDead -= ShowGameOverScreen;
            
            quitKey.Disable();
            quitKey.performed -= OnQuitKeyPerformed;
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
        private void OnQuitKeyPerformed(InputAction.CallbackContext context)
        {
            QuitGame();
        }
        //============================================================
    }
}