using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CienPies : MonoBehaviour
{
    public GameObject Bicho;

    public float contador;

    public float Lim;

    public float Retard;

    public float Lim2;

    public int vida = 20;

    public Player player;

    public int ataq = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        player = Player.instance;

       contador = contador + 1 * Time.deltaTime;

       if (contador <= 0)
       {
         Bicho.SetActive(false);
       }

       if (contador >= Lim)
       {
         Bicho.SetActive(true);

         Retard = Retard + 1 * Time.deltaTime;

          if (Retard >= Lim2)
          {
              contador = -0.5f;

                Retard = 0;
          }

       }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bala"))
        {
            vida = vida - 5;
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            player.GetComponent<Health>().RestarVida(ataq);
        }
    }
}
