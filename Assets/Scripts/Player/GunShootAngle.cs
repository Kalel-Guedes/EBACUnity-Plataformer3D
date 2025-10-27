using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class GunShootAngle : ShootLimits
{
    public int amoutShoots = 4;
    public float angle = 15f;
    


    public override void Shoot()
    {
        
        
            int mult = 0;

            for (int i = 0; i < amoutShoots; i++)
            {
                if (i % 2 == 0)
                {
                    mult++;
                }

                var obj = Instantiate(prefabBullet, shootPoint);
                obj.transform.position = shootPoint.position;
                obj.transform.localEulerAngles = Vector3.zero + Vector3.up * (i % 2 == 0 ? angle : -angle) * mult;
                obj.speed = speed;
                obj.transform.parent = null;
            }
        

    }
}
