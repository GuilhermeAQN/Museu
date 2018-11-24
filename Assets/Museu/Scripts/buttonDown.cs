using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class buttonDown : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    Vector3 s;
    Animator anim;
    public float num;

    void Start()
    {
        s = this.gameObject.transform.localScale;
        try
        {
            anim = GetComponent<Animator>();
        }
        catch
        {
        }

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        try
        {
            anim.enabled = false;
        }
        catch
        {
        }

        this.gameObject.transform.localScale = new Vector3(s.x * num, s.y * num, s.z * num);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        try
        {
            anim.enabled = true;
        }
        catch
        {
        }
        this.gameObject.transform.localScale = s;
    }
}