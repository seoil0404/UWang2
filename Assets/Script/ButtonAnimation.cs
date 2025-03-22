using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class ButtonAnimation : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    Animator an;
    private void Awake()
    {
        an = GetComponent<Animator>();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        an.SetTrigger("ButtonPress");
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        an.SetTrigger("ButtonPressUp");
    }
}
