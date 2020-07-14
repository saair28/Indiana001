using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnclaDeParte2 : MonoBehaviour
{
    public GameObject AccionadorPisoFalso;
    public GameObject tope;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (AccionadorPisoFalso.GetComponent<AccionadorPisoFalso>().trampaActiva == true && tope.GetComponent<TopeTrampaPisoFalso>().topeActive == false)
        {
            transform.Rotate(new Vector3(-500f, 0f, 0f) * Time.deltaTime);
        }
        if (tope.GetComponent<TopeTrampaPisoFalso>().topeActive == true)
        {
            transform.Rotate(new Vector3(0f, 0f, 0f) * Time.deltaTime);
        }
    }
}
