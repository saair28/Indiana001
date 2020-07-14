using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : MonoBehaviour
{
    public Rigidbody BalaPrefab;

    public Transform Disparo;

    public Player player;

    public float VelDis;

    public Rigidbody BalaPrefabInstanc;

    public float iniciarDisparo;

    public float tiempoDeDisparo;

    public int municion;

    public bool restarMuni = false;

    public float timer;

    // Update is called once per frame

    void Start()
    {
        //player = GameObject.Find("Player");
    }
    void Update()
    {
        player = Player.instance;

        municion = player.GetComponent<Player>().municion;

        if (Input.GetMouseButtonDown(0) && Time.time > iniciarDisparo && municion > 0)
        {

            iniciarDisparo = Time.time + tiempoDeDisparo;

            BalaPrefabInstanc = Instantiate(BalaPrefab, Disparo.position, Quaternion.identity) as Rigidbody;

            BalaPrefabInstanc.AddForce(Disparo.forward * 100 * VelDis);

            timer += Time.deltaTime;

            if (Input.GetMouseButtonDown(0))
            {
                 //&& timer > tiempoDeDisparo
                timer = 0;

                restarMuni = true;
            }

            else
            {
                restarMuni = false;
            }
        }
    }
}

