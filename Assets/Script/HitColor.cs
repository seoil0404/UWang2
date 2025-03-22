using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitColor : MonoBehaviour
{
    Color color;
    float coolTime = 0.3f;
    float leftTime = 0.2f;
    bool isCool = false;
    private void Awake()
    {
        color = gameObject.GetComponent<Image>().color;
        gameObject.SetActive(false);
    }
    public void Hit()
    {
        leftTime = 0.2f;
        isCool = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isCool)
        {
            if (leftTime > 0)
            {
                leftTime -= Time.deltaTime * 1;
                if (leftTime < 0)
                {
                    isCool = false;
                    leftTime = 0;
                    gameObject.SetActive(false);
                }
                float left = (leftTime / coolTime);
                color.a = left;
                gameObject.GetComponent<Image>().color = color;
            }
        }
    }
}
