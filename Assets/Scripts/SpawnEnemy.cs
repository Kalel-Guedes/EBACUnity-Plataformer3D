using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using DG.Tweening;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemys;
    public string compareTag = "Player";
    //public bool hasSpawned = false;


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.CompareTag(compareTag))
        {

            enemys.transform.DOScale(1, 1f).SetEase(Ease.OutBack);

        }
    }
   
    
    
    
}
