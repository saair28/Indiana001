using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Telaraña : MonoBehaviour
{
    public bool lento = false;
    public static Telaraña instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            lento = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        lento = false;
    }
}
