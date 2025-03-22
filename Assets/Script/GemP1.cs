using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemP1 : MonoBehaviour
{
    public Collider2D tilemap;
    public Collider2D player;
    public GameObject hittedeffect;
    public GameObject hittedeffect1;
    public GameObject hittedeffect2;
    public GameObject GemStonep;
    public int AttackDamage;
    bool isEnable;
    int GemStoneHealth;
    void Awake()
    {
        AttackDamage = 1;
        GemStoneHealth = 10;
        isEnable = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == tilemap || collision == player) { }
        else if(isEnable)
        {
            GemStoneHealth -= AttackDamage;
            if(GemStoneHealth <= 0)
            {
                GemStonep.GetComponent<GemStonePlus>().GemStone1++;
                GemStonep.GetComponent<GemStonePlus>().GemStone1Plus();
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                isEnable = false;
                Invoke("ReSpawn", 80f);
            }
            if (hittedeffect.activeInHierarchy == true)
            {
                if (hittedeffect1.activeInHierarchy == true)
                {
                    hittedeffect2.SetActive(true);
                    hittedeffect2.transform.position = transform.position;
                    hittedeffect2.GetComponent<BulletEffect>().an.SetTrigger("EnemyHit");
                    StartCoroutine(Effect(2));
                }
                else
                {
                    hittedeffect1.SetActive(true);
                    hittedeffect1.transform.position = transform.position;
                    hittedeffect1.GetComponent<BulletEffect>().an.SetTrigger("EnemyHit");
                    StartCoroutine(Effect(3));
                }
            }
            else
            {
                hittedeffect.SetActive(true);
                hittedeffect.transform.position = transform.position;
                hittedeffect.GetComponent<BulletEffect>().an.SetTrigger("EnemyHit");
                StartCoroutine(Effect(1));
            }
            
        }
    }
    private void ReSpawn()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        isEnable = true;
        GemStoneHealth = 10;
    }
    IEnumerator Effect(int effectnum)
    {
        yield return new WaitForSeconds(0.45f);
        switch(effectnum)
        {
            case 1:
                hittedeffect.SetActive(false);
                break;
            case 2:
                hittedeffect.SetActive(false);
                hittedeffect1.SetActive(false);
                break;
            case 3:
                hittedeffect.SetActive(false);
                hittedeffect1.SetActive(false);
                hittedeffect2.SetActive(false);
                break;
        }
        
    }
}
