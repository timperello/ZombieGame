using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModeTir : MonoBehaviour
{
    public Sprite auto;
    public Sprite semiAuto;

    public bool modeTir = true;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Image>().sprite = semiAuto;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("v"))
        {
            Mode();
        }
        

    }
    public void Mode()
    {
        modeTir = !modeTir;
        if (modeTir)
        {
            gameObject.GetComponent<Image>().sprite = semiAuto;
        }
        else
            gameObject.GetComponent<Image>().sprite = auto;
    }

    


}
