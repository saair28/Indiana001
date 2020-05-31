using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObjects : MonoBehaviour
{
    public GameObject ObjectToPickUp;

    public GameObject PickedObject;

    public Transform interationZone;

    // Update is called once per frame
    void Update()
    {
        if (ObjectToPickUp != null && ObjectToPickUp.GetComponent<PickableObject>().agarrar == true && PickedObject == null)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                PickedObject = ObjectToPickUp;

                PickedObject.GetComponent<PickableObject>().agarrar = false;

                PickedObject.transform.SetParent(interationZone);

                PickedObject.transform.position = interationZone.position;

                PickedObject.GetComponent<Rigidbody>().useGravity = false;

                PickedObject.GetComponent<Rigidbody>().isKinematic = true;
            }
        }

        else if (PickedObject != null)
        {
            if (Input.GetKeyDown(KeyCode.E))
            { 

                PickedObject.GetComponent<PickableObject>().agarrar = true;

                PickedObject.transform.SetParent(null);

                PickedObject.GetComponent<Rigidbody>().useGravity = true;

                PickedObject.GetComponent<Rigidbody>().isKinematic = false;

                PickedObject = null;
            }
        }
    }
}
