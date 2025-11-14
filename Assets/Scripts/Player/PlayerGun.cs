using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    public Bullet prefabBullet;
    public float timeShoot = .2f;
    public Transform shootPoint;
    public Coroutine _currentCoroutine;
    public float speed = 20f;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _currentCoroutine = StartCoroutine(StartShoot());

        }
        else if (Input.GetMouseButtonUp(0))
        {
            if (_currentCoroutine != null) { StopCoroutine(_currentCoroutine); }
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

        CameraShake.Instance.Shake();
    }




}
