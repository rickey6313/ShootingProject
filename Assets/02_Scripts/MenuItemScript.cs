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

    public void SetUI(string shipName, string shipLevel, string shipDmg, string shipNextDmg, int locked)
    {
        shipNameText.text = shipName;
        levelText.text = shipLevel;
        dmgText.text = shipDmg;
        nextDmgText.text = shipNextDmg;
        if(locked == 1)
        {
            unlockButton.gameObject.SetActive(true);
        }
        else
        {
            unlockButton.gameObject.SetActive(false);
        }
    }

    public void UnlockAction()
    {
        unlockButton.gameObject.SetActive(false);
    }

    public void PwerUpAction()
    {

    }
}
