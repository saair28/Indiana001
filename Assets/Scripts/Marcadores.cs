using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Marcadores : MonoBehaviour
{
    public int balas;

    public int escarabajo;

    public bool escoger;

    public Text contador;

    public Player player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        player = Player.instance;

        balas = player.GetComponent<Player>().municion;

        escarabajo = player.GetComponent<Player>().ContadorDeEscarabajos;

        if (escoger == false)
        {
            contador.text = balas + ":x";
        }

        if (escoger == true)
        {
            contador.text = escarabajo + ":x";
        }


    }
}
