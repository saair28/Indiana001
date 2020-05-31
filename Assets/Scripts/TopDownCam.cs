using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class TopDownCam : MonoBehaviour
{
    public Vector3 offset;
    private Transform target;
    [Range (0, 1)]public float LerpValue;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + offset, LerpValue);
    }
}
