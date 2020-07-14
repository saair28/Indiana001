using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class BOSS : MonoBehaviour
{
    public int vida = 30;
    public float velo = 10f;
    public int ataq = 4;
    public bool ataqueOn = false;

    public float VisionRad;

    public float AttackRad;

    public Player player;

    public Transform player2;

    public float ContSpaw;

    Vector3 initialPosition;

    public GameObject SpawnEsca;

    public EnemyEscara spawnee;

    public float dist;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        player = Player.instance;

        spawnee = EnemyEscara.instance;

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


        ContSpaw = ContSpaw + 1 * Time.deltaTime;

        if (dist <= VisionRad && ContSpaw >= 8)
        {
            SpawnObject();
        }

        if (dist < AttackRad)
        {
            fixedSpeed = 0.0f;
            ataqueOn = true;

        }

        else if(dist > AttackRad)
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
            vida = vida - 5;
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            player.GetComponent<Health>().RestarVida(ataq);
        }

        if (collision.gameObject.CompareTag("Araña"))
        {

        }
    }

    public void SpawnObject()
    {
        Instantiate(spawnee, SpawnEsca.transform.position , transform.rotation);

        ContSpaw = 0;
    }

    public void Movimiento()
    {

    }
}
