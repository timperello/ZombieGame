using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Add_Chargeur : MonoBehaviour
{
    public tir chargeur;
    public GameObject player;
    public AudioClip AmmoCollectedSound;
    

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("M4A1 Sopmod");
        chargeur = player.GetComponent<tir>();
    }

    // Update is called once per frame
    void Update()
    {
       
        StartCoroutine(DespawnBox(30));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            chargeur.MaxCartouches += 30;
            player.SendMessage("SoundAmmo");
            Destroy(gameObject);
            
        }
    }

    IEnumerator DespawnBox(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
