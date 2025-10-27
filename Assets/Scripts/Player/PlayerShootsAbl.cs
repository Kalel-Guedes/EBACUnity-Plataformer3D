using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlayerShootsAbl : MonoBehaviour
{
    public GameObject prefabNormalGun;
    public GameObject prefabAngleGun;

    void Start()
    {
        prefabAngleGun.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            prefabNormalGun.SetActive(true);
            prefabAngleGun.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            prefabAngleGun.SetActive(true);
            prefabNormalGun.SetActive(false);
        }
    }
    
}
