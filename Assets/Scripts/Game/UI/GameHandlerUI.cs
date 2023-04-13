using UnityEngine;
using TMPro;

namespace Game
{
    public class GameHandlerUI : MonoBehaviour
    {
        [SerializeField]
        private GameObject pauseGameUI;

        [SerializeField]
        private GameObject gameOverUI;

        [SerializeField]
        private TextMeshProUGUI highScoreText;

        private void Start()
        {
            GameHandler gameHandler = GameHandler.instance;
            gameHandler.OnPauseGame += OnPauseGame;
            gameHandler.OnResumeGame += OnResumeGame;
            gameHandler.OnGameOver += OnGameOver;
            SetHighScoreText(PlayerPreferences.highScore.ToString());
        }

        private void OnPauseGame() 
        { 
            pauseGameUI.SetActive(true);
        }

        private void OnResumeGame() 
        { 
            pauseGameUI.SetActive(false);
        }

        private void OnGameOver() 
        { 
            SetHighScoreText(PlayerPreferences.highScore.ToString());
            gameOverUI.SetActive(true);
        }

        private void SetHighScoreText(string highScore) 
        {
            highScoreText.SetText($"High Score : {highScore}");
        }
    }
}
