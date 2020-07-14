using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollWheel : MonoBehaviour
{
    public int SeleccionadaArma = 0;

    public GameObject Arma;

    public GameObject Escarabajo;

    public GameObject Mano;

    public GameObject Latigo;

    public GameObject ContarEs;

    public GameObject ContarBa;

    public static ScrollWheel instance;

    public bool manos = false;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        SeleccionArma();
        Arma.SetActive(false);
        Mano.SetActive(false);
        Escarabajo.SetActive(false);
        Latigo.SetActive(false);
        ContarBa.SetActive(false);
        ContarEs.SetActive(false);
        manos = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (SeleccionadaArma == 0)
        {
            Arma.SetActive(true);
            Latigo.SetActive(false);
            Escarabajo.SetActive(false);
            ContarBa.SetActive(true);
            ContarEs.SetActive(false);
            Mano.SetActive(false);
            manos = false;
        }
        if (SeleccionadaArma == 1)
        {
            Latigo.SetActive(true);
            Arma.SetActive(false);
            Escarabajo.SetActive(false);
            ContarBa.SetActive(false);
            ContarEs.SetActive(false);
            Mano.SetActive(false);
            manos = false;
        }
        if (SeleccionadaArma == 2)
        {
            Escarabajo.SetActive(true);
            Latigo.SetActive(false);
            Arma.SetActive(false);
            ContarEs.SetActive(true);
            ContarBa.SetActive(false);
            Mano.SetActive(false);
            manos = false;
        }
        if (SeleccionadaArma == 3)
        {
            Arma.SetActive(false);
            Mano.SetActive(true);
            Escarabajo.SetActive(false);
            Latigo.SetActive(false);
            ContarBa.SetActive(false);
            ContarEs.SetActive(false);
            manos = true;
        }

        int previusSeleccionadaArma = SeleccionadaArma;    

        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (SeleccionadaArma >= transform.childCount - 1)
            {
                SeleccionadaArma = 0;
            }
            else
            {
                SeleccionadaArma++;
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (SeleccionadaArma <= 0)
            {
                SeleccionadaArma = transform.childCount - 1;
            }
            else
            {
                SeleccionadaArma--;
            }
        }

        /*
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SeleccionadaArma = 0;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2)
        {
            SeleccionadaArma = 1;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 3)
        {
            SeleccionadaArma = 2;
        }
        */

        if (previusSeleccionadaArma != SeleccionadaArma)
        {
            SeleccionArma();
        }
    }

    void SeleccionArma()
    {
        //int i = 0;

        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);

            if (i == SeleccionadaArma)
            {
                transform.GetChild(i).gameObject.SetActive(true);
            }
        }
    }
}