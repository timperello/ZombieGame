using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int MaxHealth = 100;
    public int CurHealth = 100;
    public AudioClip SoundDead;
    public AudioClip SoundHit;
    private bool Dead = false;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Animator>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("o"))
        {
            if(CurHealth>0)
            {
                GetComponent<AudioSource>().PlayOneShot(SoundHit);
                CurHealth -= 10;
            }
            if (CurHealth == 0)
            {
                PlayerDead();
            }
        }
        if(Input.GetKeyDown("m"))
        {
            if (CurHealth >= 0)
            {
                CurHealth += 10;
            }
        }

        if (CurHealth >= 50)
        {
            GameObject.Find("Blood").GetComponent<CanvasGroup>().alpha = 0f;
        }
        if (CurHealth < 50)
        {
            GameObject.Find("Blood").GetComponent<CanvasGroup>().alpha = 0.2f;
        }
        if (CurHealth < 40)
        {
            GameObject.Find("Blood").GetComponent<CanvasGroup>().alpha = 0.3f;
        }
        if (CurHealth < 30)
        {
            GameObject.Find("Blood").GetComponent<CanvasGroup>().alpha = 0.4f;
        }
        if (CurHealth < 20)
        {
            GameObject.Find("Blood").GetComponent<CanvasGroup>().alpha = 0.5f;
        }
        if (CurHealth < 10)
        {
            GameObject.Find("Blood").GetComponent<CanvasGroup>().alpha = 0.6f;
        }
    }

    public void PlayerDead()
    {
        
        GetComponent<Animator>().enabled= true;
        GetComponent<AudioSource>().PlayOneShot(SoundDead);
        StartCoroutine(Restart());
    }

    IEnumerator Restart()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Map_v1");
    }

    void OnGUI()
    {
        GUI.Label(new Rect(10, 30, 200, 20), "Vie : " + CurHealth);
    }
}
