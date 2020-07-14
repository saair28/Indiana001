using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccionadorTrampaTronco : MonoBehaviour
{
    public float timer;
    public bool activador = false;
    public bool accionador = false;
    //public bool Act;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(activador == true)
        {
            timer += Time.deltaTime;
        }
        if (timer >= 3.0f)
        {
            timer = 0;
            accionador = true;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        activador = true;
    }

   
}
