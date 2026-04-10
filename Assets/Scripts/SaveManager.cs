using System.IO;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Core.Singleton;
using Health;


public class SaveManager : Singleton<SaveManager>
{
    [SerializeField] private SaveSetup _saveSetup;
    private string _path = Application.streamingAssetsPath + "/save.txt";

    public HealthBase healthBase;
    public PlayerMovement player;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        _saveSetup = new SaveSetup();
    }


   [NaughtyAttributes.Button]
    private void Save()
    {
        string setupToJson = JsonUtility.ToJson(_saveSetup, true);
        Debug.Log(setupToJson);
        SaveFile(setupToJson);
    }

    [NaughtyAttributes.Button]
    private void SaveItens()
    {
        _saveSetup.coins = Itens.ItemManager.Instance.GetItemByType(Itens.ItemType.COIN).itemValor.valor;
        _saveSetup.health = Itens.ItemManager.Instance.GetItemByType(Itens.ItemType.MEDKIT).itemValor.valor;
        Save();
    }

    private void SaveFile(string json)
    {
        
        Debug.Log(_path);
        File.WriteAllText(_path, json);
    }

    [NaughtyAttributes.Button]
    public void SaveLastLevel()
    {
        _saveSetup.lastLevel = CheckpointManger.Instance.lastCheck;
        Save();
    }

    [NaughtyAttributes.Button]
    public void SaveLife()
    {
       _saveSetup.Life = healthBase._currentLife; 
       Save();
    }

    public void SaveRoupa()
    {
        _saveSetup.roupa = player.playerColor;
        Save();
    }
    
    [NaughtyAttributes.Button]
    public void Load()
    {
        string fileLoaded = "";

        if(File.Exists(_path)) { fileLoaded = File.ReadAllText(_path);}

        _saveSetup = JsonUtility.FromJson<SaveSetup>(fileLoaded);

        TurnLoads();
    }

    [NaughtyAttributes.Button]
    public void SaveAll()
    {
        SaveLastLevel();
        SaveLife();
        SaveItens();
        SaveRoupa();

    }

    [NaughtyAttributes.Button]
    public void TurnLoads()
    {
        player.ChangeColor(_saveSetup.roupa);
        healthBase._currentLife = _saveSetup.Life;
        Itens.ItemManager.Instance.GetItemByType(Itens.ItemType.COIN).itemValor.valor = _saveSetup.coins;
        Itens.ItemManager.Instance.GetItemByType(Itens.ItemType.MEDKIT).itemValor.valor = _saveSetup.health;
    }

}

[System.Serializable]
public class SaveSetup
{
    public int lastLevel;
    public int coins;
    public int health;
    public int Life;
    public Color roupa;
}
