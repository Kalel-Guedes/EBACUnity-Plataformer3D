using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Health;



public class BulletEnemy : MonoBehaviour
{
    private float TimeReset = 5f;
    public int damage = 1;
    public float speed = 20f;
    public string compareTag = "Player";
    //public EnemyBase enemyBase;


    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    public void Awake()
    {
        Destroy(gameObject, TimeReset);
    }

    private void OnCollisionEnter(Collision collision)
    {
          if (collision.transform.CompareTag(compareTag))
        {
            var player = collision.transform.GetComponent<HealthBase>();

            if (player != null)
            {
                player.Damage(damage);
                Destroy(gameObject);
            }
        }

    }
}
