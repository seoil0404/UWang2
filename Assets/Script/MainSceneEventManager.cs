using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainSceneEventManager : MonoBehaviour
{
    private void Awake()
    {
        if (PlayerPrefs.GetInt("UseWeapon") == 1)
        {
            GameObject.Find("Scene Manager").GetComponent<SceneChange>().WeaponImformation = 1;
            GameObject.Find("Scene Manager").GetComponent<SceneChange>().WeaponDamage = 2;
            GameObject.Find("Scene Manager").GetComponent<SceneChange>().CoolTime = 0.5f;
        }
        else if (PlayerPrefs.GetInt("UseWeapon") == 2)
        {
            GameObject.Find("Scene Manager").GetComponent<SceneChange>().WeaponImformation = 2;
            GameObject.Find("Scene Manager").GetComponent<SceneChange>().WeaponDamage = 1;
            GameObject.Find("Scene Manager").GetComponent<SceneChange>().CoolTime = 1f;
        }

        else if (PlayerPrefs.GetInt("UseWeapon") == 3)
        {
            GameObject.Find("Scene Manager").GetComponent<SceneChange>().WeaponImformation = 3;
            GameObject.Find("Scene Manager").GetComponent<SceneChange>().WeaponDamage = 2;
            GameObject.Find("Scene Manager").GetComponent<SceneChange>().CoolTime = 0.5f;
        }
        else if(PlayerPrefs.GetInt("UseWeapon") == 4)
        {
            GameObject.Find("Scene Manager").GetComponent<SceneChange>().WeaponImformation = 4;
            GameObject.Find("Scene Manager").GetComponent<SceneChange>().WeaponDamage = 3;
            GameObject.Find("Scene Manager").GetComponent<SceneChange>().CoolTime = 0.5f;
        }
        else
        {
            GameObject.Find("Scene Manager").GetComponent<SceneChange>().WeaponImformation = 1;
            GameObject.Find("Scene Manager").GetComponent<SceneChange>().WeaponDamage = 2;
            GameObject.Find("Scene Manager").GetComponent<SceneChange>().CoolTime = 0.5f;
        }
        if (PlayerPrefs.HasKey("WeaponLevel")) GameObject.Find("Scene Manager").GetComponent<SceneChange>().CoolTime = ((GameObject.Find("Scene Manager").GetComponent<SceneChange>().CoolTime - ((GameObject.Find("Scene Manager").GetComponent<SceneChange>().CoolTime / 100) * PlayerPrefs.GetInt("WeaponLevel"))));
    }
    public void ChangeWeapon()
    {
        GameObject.Find("Scene Manager").GetComponent<SceneChange>().WeaponSceneChange();
    }
    public void GotoGemstone()
    {
        GameObject.Find("Scene Manager").GetComponent<SceneChange>().GemStoneSceneChange();
    }
}
