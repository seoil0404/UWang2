using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAiSlime : MonoBehaviour
{
    Rigidbody2D rg;
    float nextmove;
    int enemyHealth = 3;
    int enemylevel;
    float enemyspeed;
    float enemyHitWait;
    float enemyHitReach;
    float enemyDashPower;
    int enemtGetGold;
    SpriteRenderer sp;
    public GameObject swordman;
    public GameObject bulletEffect;
    public GameObject RedEffect;
    public GameObject HealthBar;
    public GameObject Ground;
    public GameObject sword1;
    public GameObject goldplus;
    public GameObject gop;
    public GameObject end;
    public int weapondamage;
    GameObject sceneManager;
    Animator an;
    bool IsHit = false;
    bool IsHitting = false;
    bool isDeath = false;
    // Start is called before the first frame update
    void Awake()
    {
        sceneManager = GameObject.Find("Scene Manager");
        weapondamage = sceneManager.GetComponent<SceneChange>().WeaponDamage;
        enemylevel = sceneManager.GetComponent<SceneChange>().enemylevel;
        if (enemylevel == 1)
        {
            enemyspeed = 1f;
            enemyHitWait = 1f;
            enemyHitReach = 1f;
            enemyDashPower = 1f;
            enemtGetGold = 1;
        }
        else if (enemylevel == 2)
        {
            enemyspeed = 1.5f;
            enemyHitWait = 0.66f;
            enemyHitReach = 1.5f;
            enemyDashPower = 1.25f;
            enemtGetGold = 2;
        }
        else if(enemylevel == 3)
        {
            enemyHealth = 9;
            enemyHitWait = 0.66f;
            enemyHitReach = 2f;
            enemyDashPower = 1.5f;
            enemtGetGold = 3;
        }
        rg = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
        an = GetComponent<Animator>();
        goldplus.SetActive(false);
        Think();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 frontVec = new Vector2(rg.position.x + nextmove * 0.5f, rg.position.y);
        RaycastHit2D rayH = Physics2D.Raycast(frontVec, Vector3.down, 1f, LayerMask.GetMask("Ignore Raycast"));
        RaycastHit2D IsHitRight = Physics2D.Raycast(transform.position, Vector3.right, 2*enemyHitReach, LayerMask.GetMask("EnemyHit"));
        RaycastHit2D IsHitLeft = Physics2D.Raycast(transform.position, Vector3.left, 2*enemyHitReach, LayerMask.GetMask("EnemyHit"));
        if (IsHitRight == true && IsHitting == false)
        {
            IsHit = true;
            IsHitting = true;
            sp.flipX = true;
            rg.AddForce(Vector2.right * 4 * enemyDashPower, ForceMode2D.Impulse);
            an.SetTrigger("IsEnemyHit");
            StartCoroutine(Hit());
        }
        if (IsHitLeft == true && IsHitting == false)
        {
            IsHit = true;
            IsHitting = true;
            sp.flipX = false;
            rg.AddForce(Vector2.left * 4 * enemyDashPower, ForceMode2D.Impulse);
            an.SetTrigger("IsEnemyHit");
            StartCoroutine(Hit());
        }
        if (rayH == false)
        {
            if(sp.flipX == true)
            {
                nextmove = -1.1f;
            }
            else if (sp.flipX == false)
            {
                nextmove = 1.1f;
            }
            FlipCheck();
            CancelInvoke();
            int rate = Random.Range(2, 5);
            Invoke("Think", 1);
        }
        if (IsHit == false) rg.velocity = new Vector2(nextmove * enemyspeed, rg.velocity.y);
    }

    IEnumerator Hit()
    {
        yield return new WaitForSeconds(3 * enemyHitWait);
        IsHit = false;
        IsHitting = false;
    }

    void Think()
    {
        nextmove = Random.Range(-1, 2);
        FlipCheck();
        int rate = Random.Range(2, 5);
        Invoke(nameof(Think), rate);
    }

    void FlipCheck()
    {
        if (nextmove > 0)
        {
            sp.flipX = true;
        }
        else if (nextmove < 0)
        {
            sp.flipX = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject obj = collision.gameObject;
        if (obj == swordman && isDeath == false)
        {
            swordman.GetComponent<Player_Move>().Health -= 1;
            if (swordman.GetComponent<Player_Move>().Health <= 0)
            {
                sceneManager.GetComponent<SceneChange>().StartSceneChange();
            }
            RedEffect.SetActive(true);
            RedEffect.GetComponent<HitColor>().Hit();
            HealthBar.GetComponent<HealthBarControl>().Hitted(swordman.GetComponent<Player_Move>().Health, swordman.GetComponent<Player_Move>().MaxHealth);
        }
        else if (obj == Ground) { }
        else if (obj == end) { }
        else
        {
            enemyHealth -= weapondamage;
            if (enemyHealth <= 0)
            {
                an.SetTrigger("EnemyDeath");
                rg.velocity = new Vector2(0, 0);
                IsHit = true;
                IsHitting = true;
                goldplus.SetActive(true);
                goldplus.GetComponent<GoldPlus>().leftTime = 1;
                gop.GetComponent<GP>().Gold += enemtGetGold;
                gop.GetComponent<GP>().GoldPlus();
                StartCoroutine(Death());
            }
            bulletEffect.SetActive(true);
            bulletEffect.transform.position = transform.position;
            bulletEffect.GetComponent<BulletEffect>().an.SetTrigger("EnemyHit");
            StartCoroutine(Effect());
        }
        
    }

    IEnumerator Effect()
    {
        yield return new WaitForSeconds(0.45f);
        bulletEffect.SetActive(false);
    }
    IEnumerator Death()
    {
        yield return new WaitForSeconds(0.7f);
        bulletEffect.SetActive(false);
        gameObject.SetActive(false);
        isDeath = true;
    }
}
