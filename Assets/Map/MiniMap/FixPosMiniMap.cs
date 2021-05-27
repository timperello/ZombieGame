using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixPosMiniMap : MonoBehaviour
{
    Vector3 setPosition;
    // Start is called before the first frame update
    void Start()
    {
        setPosition.y = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        setPosition.x = transform.position.x;
        setPosition.z = transform.position.z;
        this.transform.position = setPosition;
    }
}
