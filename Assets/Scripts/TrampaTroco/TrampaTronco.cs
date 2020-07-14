using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampaTronco : MonoBehaviour
{
    public GameObject Tope;
    public GameObject AccionadorTT;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (AccionadorTT.GetComponent<AccionadorTrampaTronco>().accionador == true && Tope.GetComponent<Tope>().TopeOn == false)
        {
            transform.Rotate(new Vector3(0f, 0f, 500f) * Time.deltaTime);
        }
        
    }
}
