using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eject : MonoBehaviour
{
    private Animator Anim;
    private bool isFire = false;
    private bool FullAuto = false;
    private float NextFire = 0f;
    public float FireRate = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButton("Fire1") && !Input.GetKey(KeyCode.LeftShift) && isFire == false && Time.time > NextFire)
        {
            NextFire = Time.time + FireRate;
            if (GetComponentInParent<tir>().Cartouches > 0)
            {
                if (!FullAuto)
                {
                    Anim.Play("Eject");
                }
                else
                {
                    Anim.SetBool("Eject", true);
                }
            }

        }
        if (Input.GetButtonDown("Fire1") && isFire == false)
        {
            isFire = true;
        }
        if (Input.GetButtonUp("Fire1"))
        {
            isFire = false;
            Anim.SetBool("Eject", false);
        }
        if (Input.GetKeyDown("v"))
        {
            FullAuto = !FullAuto;
        }
        if (FullAuto)
        {
            FireRate = 0.10f;
        }
        else
        {
            FireRate = 0.5f;
        }
    }
}