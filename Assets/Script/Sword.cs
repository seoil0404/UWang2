using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sword : MonoBehaviour
{
    Rigidbody2D rg;
    SpriteRenderer sp;
    float Flip;
    float leftTime;
    float coolTime = 1;
    public GameObject swords;
    Vector3 weaponReach;
    GameObject[] disable = new GameObject[3];
    Color color;
    void Awake()
    {
        rg = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
        if (PlayerPrefs.GetInt("UseWeapon") == 1)
        {
            weaponReach = new Vector3(0, 0, 0);
            swords = GameObject.Find("sword1");
            disable[0] = GameObject.Find("sword2");
            disable[1] = GameObject.Find("sword3");
            disable[2] = GameObject.Find("sword4");
        }
        else if (PlayerPrefs.GetInt("UseWeapon") == 2)
        {
            weaponReach = new Vector3(0.5f, 0, 0);
            swords = GameObject.Find("sword2");
            disable[0] = GameObject.Find("sword1");
            disable[1] = GameObject.Find("sword3");
            disable[2] = GameObject.Find("sword4");
        }
        else if (PlayerPrefs.GetInt("UseWeapon") == 3)
        {
            weaponReach = new Vector3(0.7f, 0, 0);
            swords = GameObject.Find("sword3");
            disable[0] = GameObject.Find("sword1");
            disable[1] = GameObject.Find("sword2");
            disable[2] = GameObject.Find("sword4");
        }
        else if (PlayerPrefs.GetInt("UseWeapon") == 4)
        {
            weaponReach = new Vector3(0f, 0, 0);
            swords = GameObject.Find("sword4");
            disable[0] = GameObject.Find("sword1");
            disable[1] = GameObject.Find("sword2");
            disable[2] = GameObject.Find("sword3");
        }
        else
        {
            weaponReach = new Vector3(0, 0, 0);
            swords = GameObject.Find("sword1");
            disable[0] = GameObject.Find("sword2");
            disable[1] = GameObject.Find("sword3");
            disable[2] = GameObject.Find("sword4");
        }
    }

    public void Attack(bool flip)
    {
        disable[0].SetActive(false);
        disable[1].SetActive(false);
        disable[2].SetActive(false);
        leftTime = (GameObject.Find("Scene Manager").GetComponent<SceneChange>().CoolTime);
        coolTime = (GameObject.Find("Scene Manager").GetComponent<SceneChange>().CoolTime);
        if (flip)
        {
            swords.transform.position = gameObject.transform.position + weaponReach;
            Flip = 1;
            sp.flipX = false;
            swords.GetComponent<SpriteRenderer>().flipX = false;
            swords.GetComponent<SpriteRenderer>().flipY = false;
        }
        else
        {
            swords.transform.position = gameObject.transform.position + -weaponReach;
            Flip = -1;
            sp.flipX = true;
            swords.GetComponent<SpriteRenderer>().flipX = true;
            swords.GetComponent<SpriteRenderer>().flipY = true;

        }
        
        StartCoroutine(Stop());
    }

    IEnumerator Stop()
    {
        yield return new WaitForSeconds(0.25f);
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        rg.velocity = new Vector2(Flip * 0.5f, rg.velocity.y);
        swords.transform.position += new Vector3(0.0025f * Flip, 0, 0);
        leftTime -= Time.deltaTime * 1.5f;
        float left = (leftTime / coolTime);
        color.r = 255;
        color.g = 255;
        color.b = 255;
        color.a = left;
        swords.GetComponent<SpriteRenderer>().color = color;
        gameObject.GetComponent<SpriteRenderer>().color = color;
    }
}
