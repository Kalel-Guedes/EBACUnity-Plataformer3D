using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using TMPro;

public class PowerUpInvencible : PowerUpBase
{
    public PlayerMovement player;
    public Color invencibleColor = Color.yellow;
    protected override void StartPowerUp()
    {
        base.StartPowerUp();
        player.SetInvencible();
        player.material.SetColor("_BaseColor", invencibleColor);
    }
    protected override void EndPowerUp()
    {
        base.EndPowerUp();
        player.SetInvencible(false);
        player.material.SetColor("_BaseColor", Color.white);
    }
}
