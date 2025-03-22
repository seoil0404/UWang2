using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponUpgrade : MonoBehaviour
{
    public Text text;
    public GameObject Gemstone;
    public GameObject GAMEobject;
    public int[] Weapondatas = new int[4];
    string[] GetWeaponData = new string[4];
    private void Awake()
    {
        if (!PlayerPrefs.HasKey("WeaponUpgrade"))
        {
            WeaponUpgradeNodata();
            GetWeaponData = PlayerPrefs.GetString("WeaponUpgrade").Split(',');
        }
        else GetWeaponData = PlayerPrefs.GetString("WeaponUpgrade").Split(',');
        for (int i = 0; i < GetWeaponData.Length; i++)
        {
            Weapondatas[i] = System.Convert.ToInt32(GetWeaponData[i]);
            
        }
        gameObject.SetActive(false);
    }

    public void PressWeaponUpgrade()
    {
        if(Weapondatas[GAMEobject.GetComponent<WeaponBuy>().weaponID-1]<50 && Gemstone.GetComponent<GemStonePlus>().GemStone1 >= 20)
        {
            Gemstone.GetComponent<GemStonePlus>().GemStone1 -= 20;
            Gemstone.GetComponent<GemStonePlus>().GemStone1Plus();
            Weapondatas[GAMEobject.GetComponent<WeaponBuy>().weaponID - 1]++;
            PlayerPrefs.SetInt("WeaponLevel",Weapondatas[GAMEobject.GetComponent<WeaponBuy>().weaponID - 1]);
            SwordChange();
            string arr = "";
            for (int i = 0; i < Weapondatas.Length; i++)
            {
                arr = arr + Weapondatas[i];
                if (i < Weapondatas.Length - 1)
                {
                    arr = arr + ",";
                }
            }

            PlayerPrefs.SetString("WeaponUpgrade", arr);
        }
    }
    public void SwordChange()
    {
        if (Weapondatas[GAMEobject.GetComponent<WeaponBuy>().weaponID - 1] >= 50)
        {
            text.text = "Max.Lv";
        }
        else
        {
            text.text = "강화하기(" + (Weapondatas[GAMEobject.GetComponent<WeaponBuy>().weaponID - 1] + 1) + ".Lv) (20)";
        }
    }
    void WeaponUpgradeNodata()
    {
        string arr = "";
        for (int i = 0; i < Weapondatas.Length; i++)
        {
            arr = arr + Weapondatas[i];
            if (i < Weapondatas.Length - 1)
            {
                arr = arr + ",";
            }
        }
        PlayerPrefs.SetString("WeaponUpgrade", arr);
    }
}
