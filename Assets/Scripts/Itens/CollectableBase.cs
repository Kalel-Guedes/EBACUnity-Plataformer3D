using System.Collections.Generic;
using System.Collections;
using UnityEngine;

namespace Itens
{
public class CollectableBase : MonoBehaviour
{
    public ItemType itemType;
    public string compareTag = "Player";

    public ParticleSystem particles;

    public GameObject graphicItem;

    public AudioSource audio;
    


    

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.CompareTag(compareTag))
        {
            Collect();
        }
    }

    private void HideObject()
    {
        gameObject.SetActive(false);
    }

    protected virtual void Collect()
    {
        if (graphicItem != null) graphicItem.SetActive(false);
        Debug.Log("Collect");
        OnCollect();
        Invoke("HideObject", 3f);
        
    }


    protected virtual void OnCollect()
    {
        if (particles != null) particles.Play();
        if (audio != null) audio.Play();
        ItemManager.Instance.AddByType(itemType);
    }
    
}
}
