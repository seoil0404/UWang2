using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player_Move : MonoBehaviour
{
    Rigidbody2D rg;
    public SpriteRenderer sp;
    public GameObject FlipCheck;
    public Animator an;
    public Text text;
    public GameObject loading;
    public GameObject loading2;
    public float f;
    public float h;
    public int MaxHealth;
    public int Health;
    public GameObject sword1;
    public GameObject SceneManager;
    bool AttackDelay = true;
    private void Awake()
    {
        SceneManager = GameObject.Find("Scene Manager");
        sword1 = GameObject.Find("sword_smash1");
        sword1.SetActive(false);
        rg = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
        an = GetComponent<Animator>();
        StartCoroutine(Loading());
    }
    IEnumerator Loading()
    {
        yield return new WaitForSeconds(1f);
        loading.SetActive(false);
        loading2.SetActive(false);
    }
    public void Ot()
    {
        SceneManager.GetComponent<SceneChange>().StartSceneChange();
    }

    private void FixedUpdate()
    {
        if (AttackDelay) rg.velocity = new Vector2(f , rg.velocity.y);
    }
    
    public void Jump()
    {
        Vector3 razor = new Vector3(0.25f, 0, 0);
        RaycastHit2D rayH = Physics2D.Raycast(razor + transform.position, Vector3.down, 0.5f, LayerMask.GetMask("Ignore Raycast"));
        if(rayH == false)
        {
            Vector3 razor2 = new Vector3(-0.25f, 0, 0);
            RaycastHit2D rayHH = Physics2D.Raycast(razor2 + transform.position, Vector3.down, 0.5f, LayerMask.GetMask("Ignore Raycast"));
            rayH = rayHH;
        }
        if (rayH == true)
        {
            an.SetTrigger("IsJump");
            rg.velocity = new Vector2(rg.velocity.x, 0);
            rg.AddForce(Vector2.up * 7, ForceMode2D.Impulse);
            
        }
    }
    public void Attack()
    {
        if(FlipCheck.GetComponent<Character_Flip>().sp.flipX == true)
        {
            AttackDelay = false;
            rg.velocity = new Vector2(0, rg.velocity.y);
            rg.AddForce(Vector2.left * 6, ForceMode2D.Impulse);
            Vector3 sw = new Vector3(0.7f, 0.2f, 0);
            sword1.SetActive(true);
            sword1.transform.position = sw += gameObject.transform.position;
            sword1.GetComponent<Sword>().Attack(true);
            Invoke("Attack_Delay", 0.4f);
        }
        else
        {
            AttackDelay = false;
            rg.velocity = new Vector2(0, rg.velocity.y);
            rg.AddForce(Vector2.right * 6, ForceMode2D.Impulse);
            Vector3 sw = new Vector3(-0.7f, 0.2f, 0);
            sword1.SetActive(true);
            sword1.transform.position = sw += gameObject.transform.position;
            sword1.GetComponent<Sword>().Attack(false);
            Invoke("Attack_Delay", 0.4f);
        }
    }
    public void Attack_Delay()
    {
        AttackDelay = true;
    }
}
