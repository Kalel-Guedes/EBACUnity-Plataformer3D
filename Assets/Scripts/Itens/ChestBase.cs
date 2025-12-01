using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using Itens;
using DG.Tweening;

public class ChestBase : MonoBehaviour
{
    public GameObject chestLayout;
    public KeyCode keyOpen = KeyCode.E;
    public bool inTrigger = false;
    public bool isOpen = false;
    public Animator animator;
    public Transform point;
    public GameObject item;
   
    void Start()
    {
        chestLayout.transform.DOScale(0,0.1f);
    }

    void Update()
    {
        if(Input.GetKeyDown(keyOpen) && inTrigger == true && isOpen == false)
        {
            OpenChest();
        }
    }
    public void OnTriggerEnter(Collider collider)
    {
        if(collider.transform.CompareTag("Player"))
        {
            chestLayout.transform.DOScale(1,1f);
            inTrigger = true;
            
        }
    }
    public void OnTriggerExit(Collider collider)
    {
        if(collider.transform.CompareTag("Player"))
        {
            chestLayout.transform.DOScale(0,1f);
            inTrigger = false;
        }
    }
    public void OpenChest()
    {
        animator.SetTrigger("Openned");
        isOpen = true;
        Invoke(nameof(SpawnItem), 2f);
    }

    public void SpawnItem()
    {
       var obj = Instantiate(item);
       obj.transform.position = point.transform.position;
       obj.transform.DOScale(1,1f).From();
    }



    
}
