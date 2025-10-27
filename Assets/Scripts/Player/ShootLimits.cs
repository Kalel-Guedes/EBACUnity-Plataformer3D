using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class ShootLimits : PlayerGun
{
    public float maxBullets = 10f;
    public float timeRecharge = 1f;

    private float _CurrentShoots;
    private bool _IsRecharging;

    protected override IEnumerator StartShoot()
    {
        if (_IsRecharging) yield break;

        while (true)
        {
            if (_CurrentShoots < maxBullets)
            {
                Shoot();
                _CurrentShoots++;
                Recharge();
                yield return new WaitForSeconds(timeShoot);
            }
        }
    }

    private void Recharge()
    {
        if (_CurrentShoots >= maxBullets)
        {
            if (_currentCoroutine != null) { StopCoroutine(_currentCoroutine); }
            Recharging();
        }
    }

    private void Recharging()
    {
        _IsRecharging = true;
        StartCoroutine(RechargeCorroutine());
    }
    
    IEnumerator RechargeCorroutine()
    {
        float time = 0f;
        while (time < timeRecharge)
        {
            time += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        _CurrentShoots = 0;
        _IsRecharging = false;
        Debug.Log("recarregando");
    }



}
