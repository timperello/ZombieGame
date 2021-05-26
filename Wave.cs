using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject zombie;
    Vector3 posSpawn;
    int rand;
    private bool isCoroutineExecuting;
    const int NbZombieParVague = 5;
    int NumWave = 0;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Zombie").Length == 0)
        {
            NumWave++;
            StartCoroutine(NewWave(2));
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
}
