using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacaPresion : MonoBehaviour
{
    bool isclosed = false;

    public float x;

    public float y;

    public float z;

    public GameObject door;

    private void OnTriggerEnter(Collider other)
    {
        if (isclosed == false)
        {
           isclosed = true;

            door.transform.position -= new Vector3(x, y, z);
        }
     
    }
}

//0, 4.43f, 0