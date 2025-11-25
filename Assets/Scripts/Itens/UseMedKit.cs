using System.Collections.Generic;
using System.Collections;
using TMPro;
using UnityEngine;
using Itens;

public class UseMedKit : MonoBehaviour
{
    public SOCoins itemValor;
    public PlayerMovement player;
    
    private void Start()
    {
       itemValor = ItemManager.Instance.GetItemByType(ItemType.MEDKIT).itemValor;
    }

    [NaughtyAttributes.Button]
    public void Recover()
    {
        if(itemValor.valor > 0)
        {
            ItemManager.Instance.RemoveByType(ItemType.MEDKIT);
            player.ResetLife();
        }
    }

}
