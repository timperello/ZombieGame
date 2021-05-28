using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Audio : MonoBehaviour
{
    public AudioSource audio;

    public bool son;
    // Start is called before the first frame update
    void Start()
    {
        audio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("Escape"))
        {
            Son();
        }
    }

    public void Son()
    {
        son = !son;
        if (son)
        {
            audio.Play();
        }
        else
            audio.mute = true;
    }
}
