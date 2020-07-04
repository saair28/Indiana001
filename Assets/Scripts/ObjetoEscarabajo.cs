using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoEscarabajo : MonoBehaviour
{
    public int Contador;

    public int vida;

    public int escarabajo;

    public GameObject Player;

    public bool restarEscara = false;

    public bool curar = false;

    public int Could = 1;

    public int CuentaAtras = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Contador = Player.GetComponent<Player>().ContadorDeEscarabajos;

        vida = Player.GetComponent<Health>().health;

        if (Input.GetMouseButtonUp(0) && Contador >= 15)
        {
            curar = true;
            Player.GetComponent<Health>().CurarVida(1);


            restarEscara = true;
        }

        if (restarEscara && Could == 1)
        {
            Could += 1;

            CuentaAtras = 1;
        }

        if (Could > 1)
        {
            CuentaAtras += 1 ;

            if (CuentaAtras >= 3)
            {
                Could = 1;

                restarEscara = false;
            }
        }

    }
}
