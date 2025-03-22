using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEffect : MonoBehaviour
{
    public Animator an;
    // Start is called before the first frame update
    private void Awake()
    {
        an = GetComponent<Animator>();
        gameObject.SetActive(false);
    }
}
