using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blinking : MonoBehaviour
{
    Light lampe;

    public float tempsMin = 0.5f;
    public float tempsMax = 2;

    void Start()
    {
        lampe = GetComponent<Light>();
        StartCoroutine(Flashing());
    }

    IEnumerator Flashing()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(tempsMin,tempsMax));
            lampe.enabled = !lampe.enabled;
        }
    }
}
