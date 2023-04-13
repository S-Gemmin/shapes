using UnityEngine;
using System;
using UnityEngine.SceneManagement;

namespace Game
{
    public class GameHandler : MonoBehaviour
    {
        public static GameHandler instance { get; private set; }

        public event Action OnPauseGame;
        public event Action OnResumeGame;
        public event Action OnGameOver;

        private const string GAME_KEY = "Game";
        private const string MAIN_MENU_KEY = "MainMenu";

        private float timeScale 
        {
            get => Time.timeScale;
            set => Time.timeScale = value;
        }

        private void Awake() 
        {
            instance = this;
        }

        public void PlayGame() 
        {
            ResumeTime();
            LoadGame();
        }

        public void MainMenu() 
        {
            ResumeTime();
            LoadMainMenu();
        }

        public void PauseGame() 
        {
            PauseTime();
            OnPauseGame?.Invoke();
        }

        public void ResumeGame() 
        {
            ResumeTime();
            OnResumeGame?.Invoke();
        }

        public void GameOver(int newScore) 
        {
            PauseTime();

            if (newScore > PlayerPreferences.highScore) 
            {
                PlayerPreferences.highScore = newScore;
                PlayerPreferences.Save();
            }
            
            OnGameOver?.Invoke();
        }

        private void LoadGame() 
        {
            SceneManager.LoadScene(GAME_KEY);
        }

        private void LoadMainMenu() 
        {
            SceneManager.LoadScene(MAIN_MENU_KEY);
        }

        private void PauseTime() 
        {
            timeScale = 0f;
        }

        private void ResumeTime() 
        {
            timeScale = 1f;
        }
    }
}
