using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using UnityEngine;

public class ColliderLash : MonoBehaviour
{
    public Transform point1;
    public bool whiplash = false;
    //public Vector3 ActualPosition;
    //public Vector3 origin;
    public Transform startLash;
    //public float timer1;
    public float timer2;
    //public GameObject player;
    public bool lash = true;
    public float iniciateWhiplash;
    public float whiplashTime;
    public bool getPoint1 = false;

    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.Find("Player");
        timer2 = 0f;
        
    }

    // Update is called once per frame
    void Update()
    {
        Whiplash();
        
        //origin = transform.position;
        //ActualPosition = transform.position;
        timer2 += Time.deltaTime;

    }

    void Whiplash ()
    {

        //lash = player.GetComponent<Player>().lash;
        if (lash == true)
        {
            if (Input.GetMouseButton(0) && Time.time > iniciateWhiplash)
            {
                iniciateWhiplash = Time.time + whiplashTime;
                //timer2 += Time.deltaTime / 2;
                //transform.position = Vector3.Lerp(ActualPosition, point1.transform.position, timer2);
                transform.position = Vector3.Lerp(startLash.position, point1.position, timer2);
            }
            /*
            if (getPoint1 == true)
            {
                timer2 += Time.deltaTime / 2;

                transform.position = Vector3.Lerp(ActualPosition, startLash.transform.position, timer2);
            }
            */
        }

        
 
    }
    public void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "targetDelLatigo")
        {
            //getPoint1 = true;
            transform.position = Vector3.Lerp(point1.position, startLash.position, timer2);
        }
    }
}
