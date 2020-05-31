using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health;
    public int numOfHearts;

    public RawImage[] hearts;
    public Texture fullHeart;
    public Texture emptyHeart;

    public bool invencible = false;

    public float tiempo_invencible = 1f;

    public float tiempo_frenado = 0.2f;

    void Update()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if(health > numOfHearts)
            {
                health = numOfHearts;
            }
            if(i < health)
            {
                hearts[i].texture = fullHeart;
            } else
            {
                hearts[i].texture = emptyHeart;
            }

            if (i < numOfHearts)
            {
                hearts[i].enabled = true;

            } else
            {
                hearts[i].enabled = false; 
            }
        }
    }
    public void RestarVida(int cantidad)
    {
        if (!invencible && health > 0)
        {
            health -= cantidad;

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
        var velocidadActual = GetComponent<Player>().speed;
        GetComponent<Player>().speed = 0;
        yield return new WaitForSeconds(tiempo_frenado);
        GetComponent<Player>().speed = velocidadActual;
    }

}
