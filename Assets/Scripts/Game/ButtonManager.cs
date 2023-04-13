using UnityEngine;

namespace Game
{
    public class ButtonManager : MonoBehaviour
    {
        private GameHandler gameHandler;
        private GunManager gunManager;

        private void Start()
        {
            gameHandler = GameHandler.instance;
            gunManager = GunManager.instance;
        }

        public void OnTriangleButtonDown()
        {
            gunManager.ShootTriangle();
        }

        public void OnSquareButtonDown()
        {
            gunManager.ShootSquare();
        }

        public void OnCircleButtonDown()
        {
            gunManager.ShootCircle();
        }

        public void OnUndoLastButtonDown() 
        {
            gunManager.UndoLast();
        }

        public void OnPauseButtonDown()
        {
            gameHandler.PauseGame();
            PlayButtonDownSound();
        }

        public void OnResumeButtonDown() 
        {
            gameHandler.ResumeGame();
            PlayButtonDownSound();
        }

        public void OnPlayAgainButtonDown()
        {
            gameHandler.PlayGame();
            PlayButtonDownSound();
        }

        public void OnMainMenuButtonDown()
        {
            gameHandler.MainMenu();
            PlayButtonDownSound();
        }

        public void SetVolume(float volume)
        {
            PlayerPreferences.volume = volume;
            PlayerPreferences.Save();
        }

        public void ToggleVolume()
        {
            SetVolume(PlayerPreferences.volume > 0f ? 0 : 0.5f);
        }

        private void PlayButtonDownSound()
        {
            SoundManager.PlaySound(Sound.ButtonDown);
        }
    }
}
