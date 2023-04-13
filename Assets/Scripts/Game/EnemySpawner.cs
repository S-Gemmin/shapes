using UnityEngine;

namespace Game
{
    public class EnemySpawner : MonoBehaviour
    {
        private Vector2 enemyDirection = Vector2.left;
        private float enemySpeed = 1f;
        private float secondsBetweenSpawn = 1f;
        private float nextSpawnTime = 0f;
        private float difficulty = 1f;

        private void Update()
        {
            if (Time.time > nextSpawnTime)
            {
                nextSpawnTime = Time.time + secondsBetweenSpawn / difficulty;
                SpawnEnemy();
                difficulty += 0.02f;
            }
        }

        private void SpawnEnemy()
        {
            GameObject enemy = Instantiate(GameAssets.i.GetRandomEnemy(), transform);
            Rigidbody2D rigidbody2D = enemy.GetComponent<Rigidbody2D>();
            rigidbody2D.AddForce(difficulty * enemySpeed * enemyDirection, ForceMode2D.Impulse);
        }
    }
}
