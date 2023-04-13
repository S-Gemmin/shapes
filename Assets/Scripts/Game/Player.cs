using UnityEngine;
using System;

namespace Game
{
    public class Player : MonoBehaviour
    {
        public static Player instance { get; private set; }

        public event Action<int> OnScoreChanged;
        public event Action<float> OnHealthChanged;

        private int maxHealth = 3;
        private int health = 0;
        private int score = 0;

        private void Awake() 
        {
            instance = this;
            health = maxHealth;
        }

        public void AddScore(int scoreToAdd) 
        {
            score += scoreToAdd;
            SoundManager.PlaySound(Sound.Score);
            OnScoreChanged?.Invoke(score);
        }

        public void Damage(int damage)
        {
            health -= damage;
            SoundManager.PlaySound(Sound.Oof);
            OnHealthChanged?.Invoke((float)health / maxHealth);
            if (health <= 0) Dead();
        }

        public void Dead() 
        {
            health = 0;
            OnHealthChanged?.Invoke((float)health / maxHealth);
            GameHandler.instance.GameOver(score);
            SoundManager.PlaySound(Sound.Oof);
        }
    }
}
