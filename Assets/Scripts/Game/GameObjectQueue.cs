using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public static class GameObjectQueue
    {
        private static Queue<GameObject> queueGameObject = new Queue<GameObject>();

        public static void Enqueue(GameObject gameObject)
        {
            queueGameObject.Enqueue(gameObject);
        }

        public static void Dequeue()
        {
            if (queueGameObject.Count > 0) 
            {
                MonoBehaviour.Destroy(queueGameObject.Dequeue());
            }
        }
    }
}
