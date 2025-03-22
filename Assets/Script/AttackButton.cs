using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackButton : MonoBehaviour
{
    Image image;
    Button button;
    public float coolTime = 1f;
    float leftTime = 1f;
    bool isCool = false;
    private void Awake()
    {
        image = GetComponent<Image>();
        button = GetComponent<Button>();
        coolTime = GameObject.Find("Scene Manager").GetComponent<SceneChange>().CoolTime;
    }
    public void ButtonDown()
    {
        leftTime = coolTime;
        isCool = true;
        button.enabled = false;
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
                    button.enabled = true;
                    isCool = false;
                    leftTime = 0;
                }
                float left = 1.0f - (leftTime / coolTime);
                image.fillAmount = left;
            }
        }
    }
}
