using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int health;
    public int numOfHearts;
    public int vida;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public bool invencible = false;

    public float tiempo_invencible = 1f;

    public float tiempo_frenado = 0.2f;

    void Update()
    {
        vida = health;

        for (int i = 0; i < hearts.Length; i++)
        {
            if(health > numOfHearts)
            {
                health = numOfHearts;
            }
            if(i < health)
            {
                hearts[i].sprite = fullHeart;
            } else
            {
                hearts[i].sprite = emptyHeart;
                //hearts[i].gameObject.SetActive(false);
            }

            if (i < numOfHearts)
            {
                hearts[i].enabled = true;

            } else
            {
                hearts[i].enabled = false; 
            }
        }
        if (vida == 0)
        {
            SceneManager.LoadScene("Game Over");
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
    public void CurarVida(int cantidad)
    {
        if (!invencible && health > 0 && health <= 5)
        {
            health += cantidad;

            StartCoroutine(Invulnerable());

            //StartCoroutine(FrenarVelocidad());
        }
    }

}
