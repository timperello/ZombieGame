using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Munitions : MonoBehaviour
{

    public int munitions = 30;
    public int munChargeur = 90;
    public float chargeur;
    public bool tire;

    public float FireRate = 0.5f;
    private float NextFire = 0f;
    private float Nextreload = 0f;
    public float ReloadRate = 1f;
    private bool FullAuto = false;



    public float Emptyrate = 0.5f;
    private float Nextempty = 0f;

    public Text affichageMunitions;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        chargeur = munChargeur / 30;
        affichageMunitions.text = munitions.ToString() + "/" + "" + munChargeur;

        if (munitions != 0)
        {
            if (Input.GetButton("Fire1") && Time.time > NextFire)
            {
                NextFire = Time.time + FireRate;
                tire = true;
                munitions--;
                tire = false;
            }
        }
            if (Input.GetKeyDown("v"))
            {
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
        if (Input.GetKeyDown("r") && Time.time > Nextreload && chargeur !=0 )
        {
            munChargeur = munChargeur - (30 - munitions);
            munitions = 30;
            Nextreload = Time.time + ReloadRate;
         }
        if (Input.GetKeyDown("r") && Time.time > Nextreload && chargeur == 0 && munitions > 0)
        {
            munChargeur = munChargeur - (30 - munitions);
            munitions = 30;
            Nextreload = Time.time + ReloadRate;
            if(munChargeur <= 0)
            {
                munChargeur = 0;
            }
        }
            if (Input.GetKeyDown("r") && munChargeur < 30 && munitions == 0)
            {
                munitions = munChargeur;
                munChargeur = 0; 
            }
            if (Input.GetButton("Fire1") && munitions == 0 && Time.time > NextFire)
            {
                Nextempty = Time.time + FireRate;
            }


        }
    }

/*using System.Collections;
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


    public AudioClip reloadsound;


    public int munitions = 30;
    public int chargeur = 3;
    public int munChargeur = 90;


    public AudioClip emptysound;
    public float Emptyrate = 0.5f;
    private float Nextempty = 0f;
    public AudioClip modetir;

    public Text affichageMunitions;

    private void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        affichageMunitions.text = munitions.ToString() + "/" + "" + munChargeur;

        if (Input.GetButton("Fire1") && Time.time > NextFire && munitions != 0 && !Input.GetKey(KeyCode.LeftShift))
        {

            NextFire = Time.time + FireRate;
            GetComponent<AudioSource>().PlayOneShot(SoundTir);
            Vector2 ScreenCenterPoint = new Vector2(Screen.width / 2, Screen.height / 2);
            ray = Camera.main.ScreenPointToRay(ScreenCenterPoint);
            if (Physics.Raycast(ray, out hit, Camera.main.farClipPlane))
            {
                if (hit.transform.gameObject.tag == "Ennemi")
                {
                    hit.rigidbody.AddForceAtPosition(transform.TransformDirection(-Vector3.forward) * 1000, hit.normal);
                }
                else if (hit.transform.gameObject.tag == "Mur")
                {
                    GameObject pointimpact = Instantiate(BulletHolePrefab, hit.point, Quaternion.FromToRotation(Vector3.forward, hit.normal)) as GameObject;
                    Destroy(pointimpact, 10f);
                }
            }
            munitions -= 1;
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
        if (Input.GetKeyDown("r") && Time.time > Nextreload && chargeur != 0)
        {
            chargeur--;
            munChargeur = munChargeur - (30 - munitions);
            munitions = 30;
            Nextreload = Time.time + ReloadRate;
            GetComponent<AudioSource>().PlayOneShot(reloadsound);

        }
        if (Input.GetButton("Fire1") && munitions == 0 && Time.time > NextFire)
        {
            Nextempty = Time.time + FireRate;
            GetComponent<AudioSource>().PlayOneShot(emptysound);
        }

    }

    /*void OnGUI()
    {
        GUI.Label(new Rect(10,10,300,30),"Cartouches : "+Cartouches+"/"+MaxCartouches+" Chargeurs : "+Chargeur);
    }*/


//}
