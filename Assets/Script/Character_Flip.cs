using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Flip : MonoBehaviour
{
    public SpriteRenderer sp;
    // Start is called before the first frame update
    
    void Awake()
    {
        sp = GetComponent<SpriteRenderer>();    
    }

}
