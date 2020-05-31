using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : MonoBehaviour
{
    public Rigidbody BalaPrefab;

    public Transform Disparo;

    public float VelDis;

    public Rigidbody BalaPrefabInstanc;

    public float iniciarDisparo;

    public float tiempoDeDisparo;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time > iniciarDisparo)
        {

            iniciarDisparo = Time.time + tiempoDeDisparo;

            BalaPrefabInstanc = Instantiate(BalaPrefab, Disparo.position, Quaternion.identity) as Rigidbody;

            BalaPrefabInstanc.AddForce(Disparo.forward * 100 * VelDis);
        }
    }
}
