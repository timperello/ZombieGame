using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NombreSante : MonoBehaviour
{
    public Text affichageNombreSante;
    // Start is called before the first frame update
    
    public void SetHealth(int health)
    {
        affichageNombreSante.text = ""+ health +"";
    }
}
