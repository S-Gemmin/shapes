using System.Collections;
using UnityEngine;

namespace Game
{
    public class GunManager : MonoBehaviour
    {
        public static GunManager instance { get; private set; }

        [SerializeField]
        private Transform gun;

        [SerializeField]
        private Transform firePoint;

        [SerializeField]
        private GameObject[] pewObjects;

        private Vector2 shapeDirection = Vector2.right;
        private float shapeSpeed = 5f;

        private void Awake() 
        {
            instance = this;
        }

        public void ShootTriangle() 
        {
            Shoot(GameAssets.i.pfTriangle);
        }

        public void ShootSquare() 
        {
            Shoot(GameAssets.i.pfSquare);
        }

        public void ShootCircle() 
        {
            Shoot(GameAssets.i.pfCircle);
        }

        public void UndoLast() 
        {
            GameObjectQueue.Dequeue();
        }

        private void Shoot(GameObject objectToShoot)
        {
            GameObject obj = Instantiate(objectToShoot, firePoint);
            Rigidbody2D rigidbody2D = obj.GetComponent<Rigidbody2D>();
            rigidbody2D.AddForce(shapeSpeed * shapeDirection, ForceMode2D.Impulse);
            GameObjectQueue.Enqueue(obj);

            SoundManager.PlaySound(Sound.Pew);
            StartCoroutine(AnimateGun());
            StartCoroutine(FlashPew());
        }

        private IEnumerator AnimateGun()
        {
            gun.localRotation = Quaternion.Euler(15f * Vector3.forward);
            yield return new WaitForSeconds(0.08f);
            gun.localRotation = Quaternion.identity;
        }

        private IEnumerator FlashPew() 
        {
            int randIndex = Random.Range(0, pewObjects.Length);
            pewObjects[randIndex].SetActive(true);
            yield return new WaitForSeconds(0.1f);
            pewObjects[randIndex].SetActive(false);
        }
    }
}
