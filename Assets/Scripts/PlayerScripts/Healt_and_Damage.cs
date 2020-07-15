using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healt_and_Damage : MonoBehaviour
{
    public int vida = 15;

    public bool invencible = false;

    public float tiempo_invencible = 1f;

    public float tiempo_frenado = 0.2f;

    public void RestarVida(int cantidad)
    {
        if (!invencible && vida > 0)
        {
            vida -= cantidad;

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
