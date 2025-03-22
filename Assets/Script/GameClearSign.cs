using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameClearSign : MonoBehaviour
{
    public GameObject obj;
    public GameObject obj2;
    public Collider2D player;
    // Start is called before the first frame update
    void Awake()
    {
        obj.SetActive(false);
        obj2.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision == player)
        {
            obj.SetActive(true);
            obj2.SetActive(true);
        }
        
    }
}
