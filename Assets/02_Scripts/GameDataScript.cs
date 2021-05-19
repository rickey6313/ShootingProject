using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game;

public class GameDataScript : MonoBehaviour
{
    public static GameDataScript instance;
    public float coin;
    private TextAsset shipTextAsset;
    public ShipData[] ships;
    private int _select;
    public int select 
    {
        get 
        { 
            _select = PlayerPrefs.GetInt("ChrSelect", 0);
            return _select;
        }
        set
        {
            _select = value;
            PlayerPrefs.SetInt("ChrSelect", _select);
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    private void Start()
    {
        LoadData();
    }


    public float GetCoin()
    {
        this.coin = PlayerPrefs.GetFloat("TotalCoin", 0);
        return coin;
    }

    public void AddCoin(float coin)
    {
        this.coin += coin;
        PlayerPrefs.SetFloat("TotalCoin", this.coin);
        MenuManager.instance.coinImage.gameObject.SetActive(true);
        MenuManager.instance.coinText.gameObject.SetActive(true);
    }

    private void LoadData()
    {
        shipTextAsset = Resources.Load<TextAsset>("ship");
        string[] lines = shipTextAsset.text.Split('\n');
        ships = new ShipData[lines.Length - 2];

        for (int i = 1; i < lines.Length-1; i++)
        {
            string[] rows = lines[i].Split('\t');
            int id = int.Parse(rows[0]);
            float base_dmg = float.Parse(rows[1]);
            string name = rows[2];
            string kName = rows[3];
            float unlockCoin = float.Parse(rows[4]);

            int chrLevel = PlayerPrefs.GetInt("Chr_Level" + i.ToString(), 1);
            int locked;

            if (i == 1)
            {
                locked = 0;
            }
            else
            {
                locked = PlayerPrefs.GetInt("Chr_Locked" + (i-1).ToString(), 1);
            }
            ships[i - 1] = new ShipData(id, base_dmg, name, kName, unlockCoin, chrLevel, locked);
            ships[i - 1].SetDamage();

        }
        for (int j = 0; j < ships.Length; j++)
        {
            ships[j].Show();
        }
    }

    public bool CanUnlock(int id)
    {
        if (GetCoin() > ships[id].unlockCoin)
        {
            if (ships[id].GetLock() == 1)
                return true;
            else
            {
                return false;
            }
        }
        else
            return false;
    }

    public void ExcuteUnlock(int id)
    {
        AddCoin(-ships[id].unlockCoin);
        ships[id].SetLock(0);
    }
}
