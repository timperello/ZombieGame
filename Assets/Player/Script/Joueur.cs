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

    public EcranGameOver EcranGameOver;
    public Text affichageScore;
    public int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        nombreSante.SetHealth(currentHealth);
        InvokeRepeating("AddLife", 1, 1);
        GetComponent<Animator>().enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        affichageScore.text = score + " POINTS";
    }
    public void AddScore()
    {
        score += 100;
    }

    void TakeDamage()
    {
        if ((currentHealth - dmgZombie) > 0)
            currentHealth = currentHealth - dmgZombie;
        else
            currentHealth = 0;
        GetComponent<AudioSource>().PlayOneShot(SoundHit);
        if (currentHealth <= 0)
        {
            InvokeRepeating("AddLife", 0, 0);
            currentHealth = -1;
            PlayerDead();
        }
        nombreSante.SetHealth(currentHealth);
        healthBar.SetHealth(currentHealth);
        updateBlood();
    }

    public void PlayerDead()
    {

        GetComponent<Animator>().enabled = true;
        GetComponent<AudioSource>().PlayOneShot(SoundDead);
        StartCoroutine(Restart());
        GameOver();
    }
    public void GameOver()
    {
        EcranGameOver.Setup(score);
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

    void AddLife()
    {
        if (currentHealth < maxHealth)
        {
            currentHealth += 2;  //  RegenHealth est le nombre de santÃ© que tu veux ajouter toutes les secondes
            nombreSante.SetHealth(currentHealth);
            healthBar.SetHealth(currentHealth);
            updateBlood();
        }

        if (currentHealth <= 0)
            currentHealth = -1;

    }

    void updateBlood()
    {
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
}