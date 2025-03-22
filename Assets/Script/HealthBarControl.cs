using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBarControl : MonoBehaviour
{
    Image image;
    public GameObject obj;
    void Awake()
    {
        image = GetComponent<Image>();
    }

    public void Hitted(int leftH, int MaxH)
    {
        float left = (float)leftH / (float)MaxH;
        
        obj.GetComponent<Text>().text = ""+leftH;
        image.fillAmount = left;
    }
}
