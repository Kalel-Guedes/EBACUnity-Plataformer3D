using UnityEngine;

namespace Itens
{
public class CollectableCoin : CollectableBase
{
        
    protected override void OnCollect()
    {
        base.OnCollect();
        ItemManager.Instance.AddByType(ItemType.COIN);

    }
}
}
