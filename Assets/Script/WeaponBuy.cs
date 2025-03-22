using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponBuy : MonoBehaviour
{
    GameObject Buy;
    GameObject Sword;
    GameObject Chose;
    GameObject Price;
    GameObject Chosing;
    public GameObject upgradebutton;
    public Sprite[] image = new Sprite[4];
    string[] datas = new string[4];
    int price;
    public int weaponID;
    int[] Weapondata = new int[4];
    int[] IsWeaponBuy = new int[4];
    int[] IsWeaponChose = new int[4];
    private void Awake()
    {
        if (!PlayerPrefs.HasKey("WeaponData"))
        {
            WeaponNodata();
            datas = PlayerPrefs.GetString("WeaponData").Split(',');
        }
        else datas = PlayerPrefs.GetString("WeaponData").Split(',');
        for (int i = 0; i < datas.Length; i++)
        {
            Weapondata[i] = System.Convert.ToInt32(datas[i]);
        }
        
        Weapondata[0] = 1;
        Weapondata[1] = 1;
        for (int i = 0; i < IsWeaponBuy.Length; i++)
        {
            if (IsWeaponBuy[i] == 0)
            {
                IsWeaponBuy[i] = Weapondata[i];
            }
        }
        if (!PlayerPrefs.HasKey("UseWeapon"))
        {
            weaponID = 1;
            WeaponNochose();
        }
        IsWeaponChose[PlayerPrefs.GetInt("UseWeapon") - 1] = 1;
        Sword = GameObject.Find("Sword");
        Buy = GameObject.Find("Buy");
        Chose = GameObject.Find("Chose");
        Price = GameObject.Find("Price");
        Chosing = GameObject.Find("Chosing");
        Sword.SetActive(false);
        Buy.SetActive(false);
        Chose.SetActive(false);
        Chosing.SetActive(false);
    }
    public void Out()
    {
        GameObject.Find("Scene Manager").GetComponent<SceneChange>().StartSceneChange();

    }
    public void Weapon1()
    {
        weaponID = 1;
        WeaponShow(1);
    }
    public void Weapon2()
    {
        weaponID = 2;
        WeaponShow(2);
    }
    public void Weapon3()
    {
        weaponID = 3;
        WeaponShow(3);
    }
    public void Weapon4()
    {
        weaponID = 4;
        WeaponShow(4);
    }
    void WeaponShow(int weaponname)
    {
        upgradebutton.SetActive(true);
        upgradebutton.GetComponent<WeaponUpgrade>().SwordChange();
        
        PlayerPrefs.SetInt("WeaponLevel", upgradebutton.GetComponent<WeaponUpgrade>().Weapondatas[weaponID-1]);
        Sword.SetActive(true);
        if(Weapondata[weaponname-1] == 1)
        {
            Buy.SetActive(false);
            Chose.SetActive(true);
            Chosing.SetActive(false);
            if (IsWeaponChose[weaponname-1] == 1)
            {
                Chose.SetActive(false);
                Chosing.SetActive(true);
            }

        }
        else
        {
            upgradebutton.SetActive(false);
            Buy.SetActive(true);
            if(weaponname == 3)
            {
                price = 100;
            }
            else if(weaponname == 4)
            {
                price = 500;
            }
            PriceSet(price);
            Chosing.SetActive(false);
            Chose.SetActive(false);
        }
        
        GameObject.Find("Sword").GetComponent<Image>().sprite = image[weaponname-1];
    }
    void WeaponNodata()
    {
        string arr = "";
        for (int i = 0; i < IsWeaponBuy.Length; i++)
        {
            arr = arr + IsWeaponBuy[i];
            if (i < IsWeaponBuy.Length - 1)
            {
                arr = arr + ",";
            }
        }
        PlayerPrefs.SetString("WeaponData", arr);
    }
    public void WeaponBuyClick()
    {
        if (GameObject.Find("GoldCount").GetComponent<GP>().Gold >= price)
        {
            GameObject.Find("GoldCount").GetComponent<GP>().Gold -= price;
            GameObject.Find("GoldCount").GetComponent<GP>().GoldPlus();
            IsWeaponBuy[weaponID-1] = 1;
            string arr = "";
            for (int i = 0; i < IsWeaponBuy.Length; i++)
            {
                arr = arr + IsWeaponBuy[i];
                if (i < IsWeaponBuy.Length - 1)
                {
                    arr = arr + ",";
                }
            }
            Debug.Log(arr);
            datas = PlayerPrefs.GetString("WeaponData").Split(',');
            for (int i = 0; i < datas.Length; i++)
            {
                Weapondata[i] = System.Convert.ToInt32(datas[i]);
            }
            Weapondata[0] = 1;
            Weapondata[1] = 1;
            Weapondata[weaponID - 1] = 1;
            PlayerPrefs.SetString("WeaponData", arr);
            WeaponShow(weaponID);
        }
    }
    public void WeaponChose()
    {
        for (int i = 0; i < IsWeaponChose.Length; i++)
        {
            IsWeaponChose[i] = 0;
        }
        IsWeaponChose[weaponID - 1] = 1;
        PlayerPrefs.SetInt("UseWeapon", weaponID);
        WeaponShow(weaponID);
    }
    void WeaponNochose()
    {
        for (int i = 0; i < IsWeaponChose.Length; i++)
        {
            IsWeaponChose[i] = 0;
        }
        IsWeaponChose[weaponID - 1] = 1;
        PlayerPrefs.SetInt("UseWeapon", weaponID);
    }
    void PriceSet(int price)
    {
        Price.GetComponent<Text>().text = price + "¿ø";
    }
}
