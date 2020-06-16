using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escarabajo : MonoBehaviour
{
    public int contador = 0;

    public GameObject escarabajo;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}

