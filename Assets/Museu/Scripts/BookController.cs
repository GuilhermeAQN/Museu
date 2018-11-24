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
    
    public void Slide()
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
