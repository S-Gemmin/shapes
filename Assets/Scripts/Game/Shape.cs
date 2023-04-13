using UnityEngine;

namespace Game
{
    public class Shape : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D col) 
        {
            if (col.gameObject.layer == LayerMask.NameToLayer("Enemy"))
            {
                Player player = Player.instance;
                if (col.gameObject.tag == gameObject.tag)
                {
                    Destroy(col.gameObject);
                    player.AddScore(1);
                }
                else 
                {
                    player.Damage(1);
                }

                GameObjectQueue.Dequeue();
                Destroy(gameObject);
            }
        }
    }
}
