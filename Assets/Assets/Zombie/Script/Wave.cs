using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject zombie;
    Vector3 posSpawn;
    int rand;
    private bool isCoroutineExecuting;
    void Start()
    {       
        zombie = GameObject.Find("Enemy");       
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(ExecuteAfterTime(5));
        
    }
    void SpawnZombie()
    {
        rand = Random.Range(1, 7);
        posSpawn = GameObject.Find("SpawnZombie" + rand).transform.position;
        Instantiate(zombie,posSpawn, Quaternion.identity);        
    }
    IEnumerator ExecuteAfterTime(float time)
    {
        if (isCoroutineExecuting)
            yield break;

        isCoroutineExecuting = true;

        yield return new WaitForSeconds(time);

        SpawnZombie();

        isCoroutineExecuting = false;
    }
}
