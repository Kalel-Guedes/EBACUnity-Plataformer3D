using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using TMPro;
using Itens;

public class PowerUpBase : CollectableBase
{
    [Header("Power Up")]
    public float duration;

    protected override void OnCollect()
    {
        base.OnCollect();
        StartPowerUp();
    }
    protected virtual void StartPowerUp()
    {
        Debug.Log("Start Power Up");
        Invoke(nameof(EndPowerUp), duration);
    }
    protected virtual void EndPowerUp()
    {
        Debug.Log("End Power Up");
    }
   
}
