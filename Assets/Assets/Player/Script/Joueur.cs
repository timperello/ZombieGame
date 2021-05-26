using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Joueur : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;
    public const int dmgZombie = 10;
    public HealthBar healthBar;
    public NombreSante nombreSante;
    public AudioClip SoundDead;
    public AudioClip SoundHit;
    private bool Dead = false;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        nombreSante.SetHealth(currentHealth);
        GetComponent<Animator>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            if(currentHealth > 0)
                {
                    TakeDamage(dmgZombie);
                    
                }
        }

        /*if (Input.GetKeyDown("m"))
        {
            if (currentHealth >= 0)
            {
                currentHealth += 10;
            }
        }*/

        if (currentHealth >= 50)
        {
            GameObject.Find("Blood").GetComponent<CanvasGroup>().alpha = 0f;
        }
        if (currentHealth < 50)
        {
            GameObject.Find("Blood").GetComponent<CanvasGroup>().alpha = 0.2f;
        }
        if (currentHealth < 40)
        {
            GameObject.Find("Blood").GetComponent<CanvasGroup>().alpha = 0.3f;
        }
        if (currentHealth < 30)
        {
            GameObject.Find("Blood").GetComponent<CanvasGroup>().alpha = 0.4f;
        }
        if (currentHealth < 20)
        {
            GameObject.Find("Blood").GetComponent<CanvasGroup>().alpha = 0.5f;
        }
        if (currentHealth < 10)
        {
            GameObject.Find("Blood").GetComponent<CanvasGroup>().alpha = 0.6f;
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth = currentHealth - damage;
        GetComponent<AudioSource>().PlayOneShot(SoundHit);
        if (currentHealth <= 0)
            PlayerDead();
        nombreSante.SetHealth(currentHealth);
        healthBar.SetHealth(currentHealth);
    }

    public void PlayerDead()
    {

        GetComponent<Animator>().enabled = true;
        GetComponent<AudioSource>().PlayOneShot(SoundDead);
        StartCoroutine(Restart());
    }

    IEnumerator Restart()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Map_v1");
    }

    /*void OnGUI()
    {
        GUI.Label(new Rect(10, 30, 200, 20), "Vie : " + CurHealth);
    }*/
}
