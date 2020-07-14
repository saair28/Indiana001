using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_and_Damage : MonoBehaviour
{
    //public int health = 15;
    //public Health health;
    public GameObject health;

    public bool invencible = false;

    public float tiempo_invencible = 1f;

    public float tiempo_frenado = 0.2f;

    public void RestarVida(int cantidad)
    {
        health.GetComponent<Health>().health = 15;
        
        if (!invencible && health.GetComponent<Health>().health > 0)
        {
            health.GetComponent<Health>().health -= cantidad;

            StartCoroutine(Invulnerable());

            StartCoroutine(FrenarVelocidad());
        }
    }

    IEnumerator Invulnerable()
    {
        invencible = true;
        yield return new WaitForSeconds(tiempo_invencible);
        invencible = false;
    }

    IEnumerator FrenarVelocidad()
    {
        var velocidadActual = GetComponent<PlayerControlle>().PlayerSpeed;
        GetComponent<PlayerControlle>().PlayerSpeed = 0;
        yield return new WaitForSeconds(tiempo_frenado);
        GetComponent<PlayerControlle>().PlayerSpeed = velocidadActual;
    }
 
}
