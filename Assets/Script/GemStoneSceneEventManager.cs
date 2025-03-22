using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemStoneSceneEventManager : MonoBehaviour
{
    GameObject sceneManager;
    private void Awake()
    {
        sceneManager = GameObject.Find("Scene Manager");
        GameObject.Find("Player_Attack_Button").GetComponent<AttackButton>().coolTime = sceneManager.GetComponent<SceneChange>().CoolTime;
    }
}
