using System.Collections.Generic;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace Itens
{
    public class LayoutManager : MonoBehaviour
    {
        public ItemLayout prefabLayout;
        public Transform container;
        public List<ItemLayout> layouts;

        public void Start()
        {
            CreateItem();
        }

        private void CreateItem()
        {
            foreach(var setup in ItemManager.Instance.itemSetup)
            {
                var item = Instantiate(prefabLayout, container);
                item.Load(setup);
                layouts.Add(item);
            }

        } 
    }
}
