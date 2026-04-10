using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Core.Singleton;
using NaughtyAttributes;
using DG.Tweening;
using TMPro;

namespace Screens
{

    public class ScreenManager : Singleton<ScreenManager>
    {
        public List<MenuManager> menuManager;

        public ScreenType startScreen = ScreenType.Menu;

        private MenuManager _CurrentScreen;

        public void Start()
        {
            HideAll();
            ShowByType(startScreen);
        }

        public void ShowByType(ScreenType type)
        {
            if (_CurrentScreen != null) _CurrentScreen.Hide();

            var nextScreen = menuManager.Find(i => i.screenType == type);

            _CurrentScreen = nextScreen;
            nextScreen.Show();
        }

        public void HideAll()
        {
            menuManager.ForEach(i => i.Hide());
        }
    }
}
