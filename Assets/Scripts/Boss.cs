using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public EnemyEscara escarabajo;
    public int vida = 10;
    public float velo = 20f;
    public int ataq = 2;
    public bool ataqueOn = false;
    public bool Turno = false;
    public float turno = 0;
    public float fixedSpeed;

    public float VisionRad;

    public float AttackRad;

    public Player player;

    public Transform player2;

    Vector3 initialPosition;

    Rigidbody rb;

    public float dist;
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        player = Player.instance;

        escarabajo = EnemyEscara.instance;

        this.transform.LookAt(player2);

        if (vida <= 0)
        {
            Destroy(gameObject);
        }

        turno = turno + 1 * Time.deltaTime;

        if (turno == 10)
        {
            Turno = true;
        }
        else
        {
            Turno = false;
        }
        
        Movimiento();

        if (Turno == true)
        {
            if (dist < AttackRad)
            {
                fixedSpeed = 0.0f;
                ataqueOn = true;

            }
            else if (dist > AttackRad)
            {
                ataqueOn = false;
            }

           Spawner();
        }
       
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

    public void Spawner()
    {
        Instantiate(escarabajo, transform.position, transform.rotation);
    }

    public void Movimiento()
    {
        Vector3 target = initialPosition;

        dist = Vector3.Distance(player.transform.position, transform.position);

        if (dist < VisionRad) target = player.transform.position;

        fixedSpeed = velo * Time.deltaTime;

        rb.MovePosition(Vector3.MoveTowards(transform.position, target, fixedSpeed));

        Debug.DrawLine(transform.position, target, Color.red);
    }
}
