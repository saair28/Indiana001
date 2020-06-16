using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollWheel : MonoBehaviour
{
    public int SeleccionadaArma = 0;


   // Start is called before the first frame update
    void Start()
    {
        SeleccionArma();
    }

    // Update is called once per frame
    void Update()
    {

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