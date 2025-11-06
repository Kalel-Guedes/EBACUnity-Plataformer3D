using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Enemy;
using Health;



public class Bullet : MonoBehaviour
{
    private float TimeReset = 5f;
    public int damage = 1;
    public float speed = 20f;
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
        
        
        var enemy = collision.transform.GetComponent<HealthBase>();

            if (enemy != null)
        {
            if (enemy.isPlayer == false)
            {
                enemy.Damage(damage);
                Destroy(gameObject);
            }
        }
        
        

    }
}
