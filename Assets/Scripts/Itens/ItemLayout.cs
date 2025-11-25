using System.Collections.Generic;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace Itens
{
    public class ItemLayout : MonoBehaviour
    {
        private ItemSetup _currSetup;
        public Image uiIcon;
        public TextMeshProUGUI textMesh;

        public void Load(ItemSetup setup)
        {
            _currSetup = setup;
            UpdateUI();
        }

        private void UpdateUI()
        {
            uiIcon.sprite = _currSetup.icon;
        }

        private void Update()
        {
            textMesh.text = _currSetup.itemValor.valor.ToString();
        }
    }
}
