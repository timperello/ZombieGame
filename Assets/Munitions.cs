using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Munitions : MonoBehaviour
{
    public int munitions = 30;
    public int chargeur;
    public bool tire;
    public Text affichageMunitions;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        affichageMunitions.text = munitions.ToString()+"/"+""+chargeur*30;
        
        if(munitions !=0 )
        {
            if (Input.GetMouseButtonDown(0) && !tire && munitions > 0)
            {
                tire = true;
                munitions--;
                tire = false;
            }
        }
        if(chargeur !=0)
        {
            if (Input.GetMouseButtonDown(1)/* && appuye sur recharge*/)
            {
                chargeur--;
                munitions = 30;
            }
        }
        
        
    }
}
