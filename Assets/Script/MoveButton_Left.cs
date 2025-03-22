using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveButton_Left : MonoBehaviour,IPointerExitHandler, IPointerEnterHandler
{
    Animator an;
    public GameObject obj;
    public GameObject obj1;
    public GameObject obj2;
    public GameObject obj3;
    public GameObject obj4;
    public GameObject obj5;
    private void Awake()
    {
        an = GetComponent<Animator>();
        obj = GameObject.Find("sword_man");
    }
    // Start is called before the first frame update
    public void OnPointerEnter(PointerEventData eventData)
    {
        obj.GetComponent<Player_Move>().f = -2.5f;
        obj1.GetComponent<Character_Flip>().sp.flipX = false;
        obj2.GetComponent<Character_Flip>().sp.flipX = false;
        obj3.GetComponent<Character_Flip>().sp.flipX = false;
        obj4.GetComponent<Character_Flip>().sp.flipX = false;
        obj5.GetComponent<Character_Flip>().sp.flipX = false;
        an.SetTrigger("ButtonPress");
        Invoke("ButtonUp", 0.1f);
        obj.GetComponent<Player_Move>().an.SetBool("IsRun", true);
    }
    void ButtonUp()
    {
        an.SetTrigger("ButtonPressUp");
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        obj.GetComponent<Player_Move>().f = 0f;
        obj.GetComponent<Player_Move>().an.SetBool("IsRun", false);
    }


}
