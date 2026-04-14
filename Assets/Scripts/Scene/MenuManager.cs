using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Core.Singleton;
using NaughtyAttributes;
using DG.Tweening;
using TMPro;

namespace Screens
{
    public enum ScreenType
    {
        Menu,
        Info,
    }
    public class MenuManager : MonoBehaviour
    {
        public ScreenType screenType;
        public List<Transform> listOfObjects;
        public float scaleTime = 0.5f;
        public float delayObjects = 0.5f;

        public bool startHiden;

        public void Start()
        {
            if (startHiden)
            {
                Hide();
            }
        }

        [Button]
        public virtual void Show()
        {
            ShowObject();
            Debug.Log("show");
        }

        [Button]
        public virtual void Hide()
        {
            HideObject();
            Debug.Log("show");
        }

        public void HideObject()
        {
            listOfObjects.ForEach(i => i.gameObject.SetActive(false));
            /*listOfObjects.ForEach(i => i.gameObject.transform.DOScale(0, scaleTime));
            */
        }
        public void ShowObject()
        {
            for (int i = 0; i < listOfObjects.Count; i++)
            {
                var obj = listOfObjects[i];

                obj.gameObject.SetActive(true);
                obj.DOScale(0, scaleTime).From().SetDelay(i * delayObjects);               

            }
            /*listOfObjects.ForEach(i => i.gameObject.transform.DOScale(1, scaleTime));
            listOfObjects.ForEach(i => i.gameObject.SetActive(true));*/
        }










    }
}