using System.Collections.Generic;
using System.Collections;
using UnityEngine;

namespace Enemy
{
    public class EnemyGun : MonoBehaviour
    {

        public BulletEnemy prefabBullet;
        public float timeShoot = .2f;
        public Transform shootPoint;
        public Coroutine _currentCoroutine;
        public float speed = 20f;
        public string compareTag = "Player";
        public GameObject enemy;
        public Transform transform;

        private void OnTriggerEnter(Collider collision)
        {
            if (collision.transform.CompareTag(compareTag))
            {
                _currentCoroutine = StartCoroutine(StartShoot());
                enemy.transform.LookAt(transform);

            }

        }
        private void OnTriggerExit(Collider collision)
        {
            if (collision.transform.CompareTag(compareTag))
            {
                StopCoroutine(StartShoot());
            }
        }

        protected virtual IEnumerator StartShoot()
        {
            while (true)
            {
                Shoot();
                yield return new WaitForSeconds(timeShoot);
            }
        }
        public virtual void Shoot()
        {
            var obj = Instantiate(prefabBullet);
            obj.transform.position = shootPoint.transform.position;
            obj.transform.rotation = shootPoint.transform.rotation;
            obj.speed = speed;
        }
    }
}
