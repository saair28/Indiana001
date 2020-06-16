using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject spawnee;
    public bool stopSpawnig = false;
    public float spawnTime;
    public float spawnDelay;

    public float VisionRad;

    public GameObject player;

    Vector3 initialPosition;

    public bool Cerca = false;

    public int Detener = 0;

    public int Fin;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
    }

    private void Update()
    {
        if (Cerca == true)
        {
            InvokeRepeating("SpawnObject", spawnTime, spawnDelay);

            Detener += 1; 
        }

        Vector3 target = initialPosition;

        float dist = Vector3.Distance(player.transform.position, transform.position);

        if (dist < VisionRad) target = player.transform.position;

        if (dist >= 0f)
        {
            Cerca = true;
        }

        Debug.DrawLine(transform.position, target, Color.red);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawWireSphere(transform.position, VisionRad);
    }

    public void SpawnObject()
    {
        Instantiate(spawnee, transform.position, transform.rotation);
        if (Detener == Fin)
        {
            CancelInvoke("SpawnObject");
        }
    }
}
