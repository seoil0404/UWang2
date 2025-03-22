using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GemStonePlus : MonoBehaviour
{
    public int GemStone1;
    private void Awake()
    {
        GemStone1 = PlayerPrefs.GetInt("GemStone1");
        gameObject.GetComponent<Text>().text = GemStone1+"";
    }
    // Start is called before the first frame update
    public void GemStone1Plus()
    {
        gameObject.GetComponent<Text>().text = GemStone1+"";
        PlayerPrefs.SetInt("GemStone1", GemStone1);
    }
}
