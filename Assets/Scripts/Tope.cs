using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tope : MonoBehaviour
{
    public bool TopeOn = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        TopeOn = true;
    }
}
