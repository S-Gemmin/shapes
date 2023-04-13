using UnityEngine;

namespace Game 
{
    public class Enemy : MonoBehaviour 
    { 
        private void OnTriggerEnter2D(Collider2D col) 
        {
            if (col.gameObject.CompareTag("Player")) 
            {
                Player.instance.Dead();
            }
        }
    }
}
