using System.Collections.Generic;
using System.Collections;
using TMPro;
using UnityEngine;
using Core.Singleton;

namespace Itens
{
    public enum ItemType
    {
        COIN,
        MEDKIT
    }

    public class ItemManager : Singleton<ItemManager>
    {
    
    public List<ItemSetup> itemSetup;
    

    private void Start()
    {
        Reset();
    }

    private void Reset()
    {
        foreach(var i in itemSetup)
            {
                i.itemValor.valor = 0;
            }
        //UpdateUI();
    }
    public ItemSetup GetItemByType(ItemType itemType,int amount = 1)
        {
            return itemSetup.Find(i => i.itemType == itemType);
        }

    public void AddByType(ItemType itemType,int amount = 1)
    {
        if(amount < 0) return;       
        itemSetup.Find(i => i.itemType == itemType).itemValor.valor += amount;
        //UpdateUI();
    }
    public void RemoveByType(ItemType itemType,int amount = -1)
    {        
        if(amount > 0) return;       
        var item = itemSetup.Find(i => i.itemType == itemType);
        item.itemValor.valor += amount;
        //UpdateUI();

        if(item.itemValor.valor < 0) item.itemValor.valor = 0;
       
    }
    /*public void UpdateUI()
    {
        itemSetup.coinsNumber.text = sOCoins.valor.ToString();
    }*/

     [NaughtyAttributes.Button]
    private void AddCoin()
        {
            AddByType(ItemType.COIN);
        }
     [NaughtyAttributes.Button]
    private void AddMedKit()
        {
            AddByType(ItemType.MEDKIT);
        }
    [NaughtyAttributes.Button]
    private void RemoveCoin()
        {
            RemoveByType(ItemType.COIN);
        }
     [NaughtyAttributes.Button]
    private void RemoveMedKit()
        {
            RemoveByType(ItemType.MEDKIT);
        }
    

    
    }

    [System.Serializable]
    public class ItemSetup
    {
        public ItemType itemType;
        public SOCoins itemValor;
        public Sprite icon;
    }
}
