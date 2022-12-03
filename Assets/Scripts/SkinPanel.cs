using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SkinPanel : MonoBehaviour
{
    public GameObject skinToEquip;
    public TextMeshProUGUI buttonText;
    public enum SkinsIDs { defaultSkin, red, hat }
    public SkinsIDs skinID;
    public int skinCost = 1;
    private bool isSkinUnlocked;

    private void Awake()
    {
        if (PlayerPrefs.GetInt(skinID.ToString()) == 1)
        {
            isSkinUnlocked = true;
            buttonText.text = "Equip Skin";
        }
        else
        {
            buttonText.text = "Buy for " + skinCost + " G";
        }
    }

    public void EquipSkin()
    {
        SkinLoader.skinToLoad = skinToEquip;
    }

    public void OnSkinButtonPress()
    {
        if (isSkinUnlocked)
        {
            EquipSkin();
        }
        else
        {
           
            if (FindObjectOfType<PlayerMoney>().TryRemoveMoney(skinCost))
            {
                isSkinUnlocked = true;
                PlayerPrefs.SetInt(skinID.ToString(), 1);
                buttonText.text = "Equip Skin";
            }
        }
    }
}