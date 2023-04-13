using System.Collections;
using UnityEngine;
using TMPro;

namespace Game
{
    public class PlayerUI : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI scoreText;
        
        [SerializeField]
        private Transform healthBar;

        [SerializeField]
        private GameObject redBackground;

        [SerializeField]
        private Transform healthUI;

        private void Start()
        {
            Player player = Player.instance;
            player.OnScoreChanged += OnScoreChanged;
            player.OnHealthChanged += OnHealthChanged;
        }

        private void OnScoreChanged(int score)
        {
            SetScoreText(score.ToString());
        }

        private void OnHealthChanged(float healthPercent)
        {
            SetHealthBar(healthPercent);

            if (healthPercent > 0)
            {
                StartCoroutine(ShakeHealthBar(10f));
                StartCoroutine(FlashRedBackground());
            }
        }

        private void SetScoreText(string score)
        {
            scoreText.SetText(score);
        }

        private void SetHealthBar(float healthPercent)
        {
            healthBar.localScale = new Vector2(healthPercent, 1f);
        }

        private IEnumerator FlashRedBackground() 
        {
            redBackground.SetActive(true);
            yield return new WaitForSeconds(0.05f);
            redBackground.SetActive(false);
        }

        private IEnumerator ShakeHealthBar(float magnitude) 
        {
            Vector2 originalPos = healthUI.position;
            
            for (float time = 0f; time < 0.2f; time += Time.deltaTime)
            {
                float x = Random.Range(-1f, 1f) * magnitude;
                healthUI.position = originalPos + new Vector2(x, 0f);
                yield return null;
            }

            healthUI.position = originalPos;
        }
    }
}
