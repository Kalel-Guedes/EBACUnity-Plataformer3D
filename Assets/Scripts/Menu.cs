using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public SaveManager saveManager;

    public void SaveButton()
    {
       saveManager.SaveAll();
    }

    

}
