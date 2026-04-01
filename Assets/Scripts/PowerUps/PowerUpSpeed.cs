using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using TMPro;

public class PowerUpSpeed : PowerUpBase
{
    [Header("Power Up Speed Up")]
    public float amountToSpeed;
    public Color invencibleColor = Color.blue;

    public PlayerMovement player;

    protected override void StartPowerUp()
    {
        base.StartPowerUp();
        player.PowerUpSpeedUp(amountToSpeed);
        player.material.SetColor("_BaseColor", invencibleColor);
        
    }
    protected override void EndPowerUp()
    {
        base.EndPowerUp();
        player.ResetSpeed();
        player.material.SetColor("_BaseColor", Color.white);
    }
   
}
