using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using DG.Tweening;
using NaughtyAttributes;
using TMPro;

public class CheckpointBase : MonoBehaviour
{
    public MeshRenderer meshRenderer;
    public int key = 1;
    public bool checkpointActive = false;
    private string checkpointKey = "CheckKey";
    public TextMeshProUGUI textMesh;



    private void OnTriggerEnter(Collider other)
    {
        if (!checkpointActive && other.transform.tag == "Player")
        {

            CheckCheckpoint();

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {

             textMesh.transform.DOScale(0, 2f).SetEase(Ease.OutBack);

        }
    }

    private void CheckCheckpoint()
    {
        turnOn();
        SaveCheckpoint();

    }
    [NaughtyAttributes.Button]
    private void turnOn()
    {
        meshRenderer.material.SetColor("_EmissionColor", Color.white);
    }
    [NaughtyAttributes.Button]
    private void turnOff()
    {
        meshRenderer.material.SetColor("_EmissionColor", Color.grey);
    }
    private void SaveCheckpoint()
    {
        /*if (PlayerPrefs.GetInt(checkpointKey, 0) > key)
        {
            PlayerPrefs.SetInt(checkpointKey, key);
        }*/

        CheckpointManger.Instance.SaveCheck(key);

        checkpointActive = true;
        textMesh.transform.DOScale(1, 2f).SetEase(Ease.OutBack);
    }
    
}
