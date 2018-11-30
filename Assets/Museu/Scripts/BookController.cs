using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class BookController : MonoBehaviour {
    public Animator anim;
    public static BookController instance;
    
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        anim = GetComponent<Animator>();
    }
    
    public void Show() //Book Menu
    {
        if (anim.GetBool ("Hide") == true)
        {
            anim.SetBool("Hide", false);
        }
        if (anim.GetBool ("Show") == false)
        {
            anim.SetBool("Show", true);
        }
    }
    public void Hide()
    {
        if (anim.GetBool ("Show") == true)
        {
            anim.SetBool("Show", false);
        }
        if (anim.GetBool("Hide") == false)
        {
            anim.SetBool("Hide", true);
        }
    }
    public void Slide() //Book Hud game
    {
        if (anim.GetBool ("SlideUp") == false)
        {
            anim.SetBool("SlideUp", true);
        }
        else if(anim.GetBool("SlideDown") == false)
        {
            anim.SetBool("SlideDown", true);
        }
        if (this.anim.GetCurrentAnimatorStateInfo(0).IsName("SlideDown"))
        {
            anim.SetBool("SlideDown", false);
        }
    }
    
}
