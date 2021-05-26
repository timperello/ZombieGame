using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlayer : MonoBehaviour
{
    private Animator anim;
    
    void Start()
    {
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            anim.SetBool("Walk", true);
            anim.SetBool("Run", false);
        }
        if (!Input.GetKey(KeyCode.Z))
        {
            anim.SetBool("Walk", false);
        }

        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.Z))
        {
            anim.SetBool("Walk", false);
            anim.SetBool("Run", true);
        }

        if (!Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.Z))
        {
            anim.SetBool("Walk", false);
            anim.SetBool("Run", false);
        }

        if (Input.GetKeyDown(KeyCode.R) /*&& GetComponentInChildren<tir>().Cartouches==0*/)
        {
            anim.SetTrigger("Reload");
        }
    }
}
