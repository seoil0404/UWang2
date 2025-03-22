using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldPlus : MonoBehaviour
{
    public float leftTime;
    public float coolTime = 1;
    Color color;
    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += new Vector3(0, 0.001f, 0);
        leftTime -= Time.deltaTime * 1;
        float left = (leftTime / coolTime);
        color.r = 255;
        color.g = 255;
        color.b = 255;
        color.a = left;
        gameObject.GetComponent<SpriteRenderer>().color = color;
    }
}
