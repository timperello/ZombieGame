using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tir : MonoBehaviour
{
    private Ray ray;
    private RaycastHit hit;
    public GameObject BulletHolePrefab;
    public float FireRate = 0.5f;
    private float NextFire = 0f;
    public AudioClip SoundTir;
    private bool FullAuto = false;
    private float Nextreload = 0f;
    public float ReloadRate = 1f;
    Enemy zombie;
    private Animator anim;

    public AudioClip reloadsound;
   

    public int Cartouches=30;
    public int MaxCartouches=90;
    public float Chargeur;

    public AudioClip emptysound;
    public float Emptyrate = 0.5f;
    private float Nextempty=0f;
    public AudioClip modetir;

    //public Text affichageMunitions;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        Chargeur = MaxCartouches / 30;
        if (Input.GetButton("Fire1")&& Time.time > NextFire && Cartouches !=0  && !Input.GetKey(KeyCode.LeftShift))
        {
            
            NextFire = Time.time + FireRate;
            GetComponent<AudioSource>().PlayOneShot(SoundTir);
            Vector2 ScreenCenterPoint = new Vector2(Screen.width / 2, Screen.height / 2);
            ray = Camera.main.ScreenPointToRay(ScreenCenterPoint);
            if(Physics.Raycast(ray,out hit, Camera.main.farClipPlane))
            {
                if (hit.transform.gameObject.tag == "Zombie")
                {
                    zombie = hit.transform.gameObject.GetComponent<Enemy>();
                    zombie.SendMessage("TakeDmg", 1);
                    zombie.SendMessage("SlowZombie", 1.5f);
                }
                else if (hit.transform.gameObject.tag == "Mur")
                {
                    GameObject pointimpact = Instantiate(BulletHolePrefab, hit.point, Quaternion.FromToRotation(Vector3.forward, hit.normal)) as GameObject;
                    Destroy(pointimpact, 10f);
                }
            }
            Cartouches -= 1;
        }
        if (Input.GetKeyDown("v"))
        {
            GetComponent<AudioSource>().PlayOneShot(modetir);
            FullAuto = !FullAuto;
        }
        if (FullAuto == true)
        {
            FireRate = 0.10f;
        }
        else
        {
            FireRate = 0.5f;
        }
        if(Input.GetKeyDown("r")&& Time.time>Nextreload && MaxCartouches!=0)
        {
            MaxCartouches = MaxCartouches - (30 - Cartouches);
            Cartouches = 30;
            Nextreload = Time.time + ReloadRate;
            GetComponent<AudioSource>().PlayOneShot(reloadsound);
            if (MaxCartouches <= 0)
            {
                MaxCartouches = 0;
            }

        }

        
        /*if (Input.GetKeyDown("r") && Time.time > Nextreload && Chargeur == 0 && Cartouches > 0)
        {
            MaxCartouches = MaxCartouches - (30 - Cartouches);
            Cartouches = 30;
            Nextreload = Time.time + ReloadRate;
            if (MaxCartouches <= 0)
            {
                MaxCartouches = 0;
            }
        }*/
        if (Input.GetKeyDown("r")&&MaxCartouches < 30 && Cartouches == 0)
        {
            Cartouches = MaxCartouches;
            MaxCartouches = 0;
        }
        if (Input.GetButton("Fire1") && Cartouches==0 && Time.time > NextFire)
        {
            Nextempty = Time.time + FireRate;
            GetComponent<AudioSource>().PlayOneShot(emptysound);
        }

    }



    void OnGUI()
    {
        GUI.Label(new Rect(10,10,300,30),"Cartouches : "+Cartouches+"/"+MaxCartouches+" Chargeurs : "+Chargeur);
    }

    
}
