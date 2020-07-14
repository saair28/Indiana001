using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnclaAtaqueMelee : MonoBehaviour
{
    //public GameObject Tope;
    public GameObject BossScript;
    public GameObject ColliderAtaqueScript;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (BossScript.GetComponent<Boss>().ataqueOn == true)
        { 
            if (ColliderAtaqueScript.GetComponent<ColliderAtaqueMelee>().ataqueRegresa == false) //&& Tope.GetComponent<Tope>().TopeOn == false)
            {
                transform.Rotate(new Vector3(0f, 0f, -50f) * Time.deltaTime);

            }
            if (ColliderAtaqueScript.GetComponent<ColliderAtaqueMelee>().ataqueRegresa == true)
            {
                transform.Rotate(new Vector3(0f, 0f, 50f) * Time.deltaTime);
            
            }

        }
        else if (BossScript.GetComponent<Boss>().ataqueOn == false)
        {
            transform.Rotate(new Vector3(0f, 0f, 0f));
        }
    }
}
