using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderLash : MonoBehaviour
{
    public Transform startMarker;
    public Transform endMarker;

    public float speed = 1.0f;
    public float journeyLength = 1.0f;
    private float startTime;
    public bool loop = false;
    public bool lashActivated = false;
<<<<<<< HEAD
=======
    public GameObject ArañaE;
>>>>>>> 85608a254ca7af437019b320dbee05cd63f89e81

    // Start is called before the first frame update
    void Start()
    {
      
        
    }

    // Update is called once per frame
    void Update()
    {
        if (lashActivated == true)
        {
            if (!loop)
            {
                float distCovered = (Time.time - startTime) * speed;
                transform.position = Vector3.Lerp(startMarker.position, endMarker.position, distCovered / journeyLength);
            }

            if (Input.GetMouseButton(0))
                if (loop)
                {
                    float distCovered = Mathf.PingPong(Time.time - startTime, journeyLength / speed);
                    transform.position = Vector3.Lerp(startMarker.position, endMarker.position, distCovered / journeyLength);
                }

        }
        
    }

<<<<<<< HEAD


    
=======
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag ("Araña"))
        {
            ArañaE.GetComponent<ArañaE>().vida = ArañaE.GetComponent<ArañaE>().vida  - 2;
        }
    }



>>>>>>> 85608a254ca7af437019b320dbee05cd63f89e81
}
