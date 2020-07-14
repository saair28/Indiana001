using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruccion : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Araña"))
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Pared"))
        {
            Destroy(gameObject);
        }

        /*
         if (collision.gameObject.CompareTag("Boss"))
         {
             Destroy(gameObject);
         }

         if (collision.gameObject.CompareTag("Ciempies"))
         {
             Destroy(gameObject);
         }

         if (collision.gameObject.CompareTag("EscarabajosN"))
         {
             Destroy(gameObject);
         }
         */
    }
}
