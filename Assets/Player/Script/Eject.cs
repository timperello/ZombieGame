using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eject : MonoBehaviour
{
    private Animator Anim;
    // Start is called before the first frame update
    void Start()
    {
        Anim=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && !Input.GetKey(KeyCode.LeftShift))
        {
            if(GetComponentInParent<tir>().Cartouches>0)
                Anim.SetBool("Eject", true);
            else
                Anim.SetBool("Eject", false);

        }
        if (Input.GetButtonUp("Fire1"))
        {
            Anim.SetBool("Eject", false);
        }
    }
}
