using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GP : MonoBehaviour
{
    public int Gold;
    private void Awake()
    {
        Gold = PlayerPrefs.GetInt("Gold");
        gameObject.GetComponent<Text>().text = Gold + "��";
    }
    // Start is called before the first frame update
    public void GoldPlus()
    {
        gameObject.GetComponent<Text>().text = Gold+"��";
        PlayerPrefs.SetInt("Gold", Gold);
    }
}
