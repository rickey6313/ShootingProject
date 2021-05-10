using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Game;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject item;
    public GameObject content;
    public GameObject addButtonObj;
    public GameObject ClearButtonObj;
    public Text coinText;
    public GameObject coinImage;

    private void Start()
    {
        int shipLength = GameDataScript.instance.ships.Length;

        for(int i = 0; i < shipLength; i++)
        {
            ShipData ship = GameDataScript.instance.ships[i];
            GameObject obj = Instantiate(item, transform.position, Quaternion.identity);
            MenuItemScript curItem = obj.GetComponent<MenuItemScript>();
            curItem.SetUI(ship.name, ship.chr_level.ToString(), ship.dmg.ToString(), ship.nextDmg.ToString());
            curItem.id = ship.id;
            obj.name = i.ToString();
            obj.transform.SetParent(content.transform, false);
            obj.SetActive(true);
            curItem.shipImage.sprite = Resources.Load<Sprite>(ship.GetImageName());
            GetComponent<ScrollRectSnap>().item.Add(obj);
        }
        if(GameDataScript.instance.GetCoin() == 0)
        {
            coinImage.SetActive(false);
            coinText.gameObject.SetActive(false);
        }
        else
        {
            coinImage.SetActive(true);
            coinText.gameObject.SetActive(true);
            coinText.text = GameDataScript.instance.GetCoin().ToString();
        }
    }

    public void GoGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void AddTestCoin()
    {
        GameDataScript.instance.AddCoin(10000);
        coinText.text = GameDataScript.instance.GetCoin().ToString();
    }

    public void ClearPrefAction()
    {
        PlayerPrefs.DeleteAll();
    }


    public void QuitGame()
    {
        Application.Quit();
    }
}
