using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccionadorPisoFalso : MonoBehaviour
{
    public float timer = 0f;
    public bool trampaActiva = false;
    public bool colisionActive = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (colisionActive == true)
        { 
            timer += Time.deltaTime;
            if (timer >= 5)
            {
                trampaActiva = true;
                timer = 0;
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            colisionActive = true; 
        }
    }
}
