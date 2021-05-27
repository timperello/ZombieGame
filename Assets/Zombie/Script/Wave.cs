using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wave : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject zombie;
    Vector3 posSpawn;
    int rand;
    private bool isCoroutineExecuting;
    const int NbZombieParVague = 5;
    public int nbzombies;
    int NumWave = 0;
    public bool IsStop = false;
    public Text affichageManche;
    public Text affichageZombiesRestants;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        nbzombies = GameObject.FindGameObjectsWithTag("Zombie").Length;

        affichageZombiesRestants.text = "Zombies restants: " + nbzombies;
        affichageManche.text = "Manche: " + NumWave;

        if (GameObject.FindGameObjectsWithTag("Zombie").Length == 0 && IsStop == false)
        {
            NumWave++;
            StartCoroutine(WaitWave(10));
            print(GameObject.FindGameObjectsWithTag("Zombie").Length);
            
        }
    }
    void SpawnZombie()
    {
        rand = Random.Range(1, 7);
        posSpawn = GameObject.Find("SpawnZombie" + rand).transform.position;
        Instantiate(zombie, posSpawn, Quaternion.identity);
    }
    IEnumerator NewWave(float time)
    {
        for (int i = 0; i < (NumWave * NbZombieParVague); i++)
        {
            SpawnZombie();
            yield return new WaitForSeconds(time);
            
        }
    }
    IEnumerator WaitWave(float time)
    {
        IsStop = true;
        yield return new WaitForSeconds(time);
        IsStop = false;
        StartCoroutine(NewWave(2));
    }
}
