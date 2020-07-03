using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderAtaqueMelee : MonoBehaviour
{
    public int ataq = 3;
    public bool ataqueRegresa = false;
    //public bool ataqueRegresa2 = false;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ataqueRegresa"))
        {
            ataqueRegresa = true;
        }
        if (other.gameObject.CompareTag("ataqueRegresa2"))
        {
            ataqueRegresa = false;
        }
        if (other.gameObject.CompareTag("Player"))
        {
            player.GetComponent<Health>().RestarVida(ataq);
        }
    }
}
