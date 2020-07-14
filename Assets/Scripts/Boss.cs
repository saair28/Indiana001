using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Boss : MonoBehaviour
{
    public int vida = 10;
    public float velo = 20f;
    public int ataq = 2;
    public bool ataqueOn = false;

    public float VisionRad;

    public float AttackRad;

    public GameObject player;

    public Transform player2;

    Vector3 initialPosition;

    public float dist;
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.LookAt(player2);

        if (vida <= 0)
        {
            Destroy(gameObject);
        }

        Movimiento();

        Vector3 target = initialPosition;

        dist = Vector3.Distance(player.transform.position, transform.position);

        if (dist < VisionRad) target = player.transform.position;

        float fixedSpeed = velo * Time.deltaTime;
        
        if (dist < AttackRad)
        {
            fixedSpeed = 0.0f;
            ataqueOn = true;

        }else if(dist > AttackRad)
        {
            ataqueOn = false;
            transform.position = Vector3.MoveTowards(transform.position, target, fixedSpeed);
        }

        transform.position = Vector3.MoveTowards(transform.position, target, fixedSpeed);

        Debug.DrawLine(transform.position, target, Color.red);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawWireSphere(transform.position, VisionRad);

        Gizmos.color = Color.yellow;

        Gizmos.DrawWireSphere(transform.position, AttackRad);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bala"))
        {
            vida = vida - 1;
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            player.GetComponent<Health>().RestarVida(ataq);
        }

        if (collision.gameObject.CompareTag("Araña"))
        {

        }
    }

    

    public void Movimiento()
    {

    }
}
