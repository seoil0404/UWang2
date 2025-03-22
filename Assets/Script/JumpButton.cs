using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JumpButton : MonoBehaviour, IPointerDownHandler
{
    public GameObject obj;
    public void OnPointerDown(PointerEventData eventData)
    {
        obj.GetComponent<Player_Move>().Jump();
    }
}
