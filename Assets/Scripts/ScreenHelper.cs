using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Core.Singleton;
using NaughtyAttributes;
using DG.Tweening;
using TMPro;

namespace Screens
{
    public class ScreenHelper : MonoBehaviour
    {
        public ScreenType screenType;

        public void OnClick()
        {
            ScreenManager.Instance.ShowByType(screenType);

        }
    }
}
