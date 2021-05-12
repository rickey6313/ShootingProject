using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuItemScript : MonoBehaviour
{
    public int id;
    public Button unlockButton;
    public Image shipImage;
    public Text shipNameText;
    public Text levelText;
    public Text dmgText;
    public Text nextDmgText;
    public Text unlockCoinText;

    public void SetUI(string shipName, string shipLevel, string shipDmg, string shipNextDmg, int locked, float unlockCoin)
    {
        shipNameText.text = shipName;
        levelText.text = shipLevel;
        dmgText.text = shipDmg;
        nextDmgText.text = shipNextDmg.ToString() + " Coin";
        unlockCoinText.text = unlockCoin.ToString();

        if (locked == 1)
        {
            unlockButton.gameObject.SetActive(true);
            unlockCoinText.gameObject.SetActive(true);
        }
        else
        {
            unlockButton.gameObject.SetActive(false);
            unlockCoinText.gameObject.SetActive(false);
        }
    }

    public void UnlockAction()
    {
        unlockButton.gameObject.SetActive(false);
        GameDataScript.instance.ships[id].SetLock(0);
    }

    public void PwerUpAction()
    {

    }
}
