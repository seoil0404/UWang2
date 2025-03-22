using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public int WeaponImformation;
    public int WeaponDamage;
    public float CoolTime;
    public GameObject StageChoser;
    public GameObject Dondestroy1;
    public int enemylevel;
    public int Weaponlevel;
    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(Dondestroy1);
        StageChoser.SetActive(false);
    }
    public void FightScene()
    {
        StageChoser.SetActive(true);
    }
    public void CloseFightScene()
    {
        StageChoser.SetActive(false);
    }
    public void FightScene1Change()
    {
        enemylevel = 1;
        SceneManager.LoadScene("FightScene1");
    }
    public void FightScene2Change()
    {
        enemylevel = 2;
        SceneManager.LoadScene("FightScene2");
    }
    public void FightScene3Change()
    {
        enemylevel = 3;
        SceneManager.LoadScene("FightScene3");
    }
    public void StartSceneChange()
    {
        
        SceneManager.LoadScene("StartScene");
        Destroy(gameObject);
        Destroy(Dondestroy1);
    }
    public void WeaponSceneChange()
    {

        SceneManager.LoadScene("WeaponScene");
    }
    public void GemStoneSceneChange()
    {
        SceneManager.LoadScene("GemStone1");
    }
}
