using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int ContadorDeEscarabajos;

    public float speed = 1f;
    Vector3 velocity; 
    //public float rotationSpeed;
    public float rotX;
    public float rotY;
    public float rotZ;
    Rigidbody rb;

    public float timer = 2f;

    public float CuentaAtras = 1f;

    public bool isJump = false;
    public bool Lento;

    public float jumpForce = 5.0f;

    public float weaponNumber;
    public bool restarEs = false;

    public GameObject ObjetoEscarabajo;

    public GameObject telaraña;

    //private Camera mainCamera;

    public int Could = 1;

    public bool abrir = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        /*
        mainCamera = FindObjectOfType<Camera>();
        */
        //CurrentWeapon = Weapons[0];

    }
    /*
    void RotatePlayer()
    {
        Vector3 vec = transform.eulerAngles;
        vec.y += Input.GetAxis("Horizontal") * Time.deltaTime * 360;
        transform.eulerAngles = vec;
    }
    */
    // Update is called once per frame
    void Update()
    {
        //RotatePlayer();
        PlayerMovement();

        restarEs = ObjetoEscarabajo.GetComponent<ObjetoEscarabajo>().restarEscara;

        Lento = telaraña.GetComponent<Telaraña>().lento;

        /*
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;
        if(groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);

            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }
        */

        jump();
        ChangeWeapon();

        if (restarEs == true)
        {
            restarEscarabajo();
        }

        if (Lento == true)
        {
            speed = 5f;
        }
        else
        {
            speed = 10f;
        }
    }

    void restarEscarabajo()
    {
        ContadorDeEscarabajos = ContadorDeEscarabajos - 15;

        restarEs = false;
    }

    void PlayerMovement()
    {
        velocity = Vector3.zero;
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 playerMovement = new Vector3(h, 0f, v) * speed * Time.deltaTime;
        transform.Translate(playerMovement, Space.Self);
       


    }

    void jump()
    {
        isJump = Input.GetMouseButtonDown(1);

        if (isJump && Could == 1)
        {
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);

            Could += 1;

            CuentaAtras = 1;
        }

        if (Could > 1)
        {
            CuentaAtras += 1 * Time.deltaTime;
            
            if (CuentaAtras >= 2)
            {
                Could = 1;
            }
        }
    }
    void ChangeWeapon()
    {/*
        if (Input.GetAxis("Mouse ScrollWheel")) { }
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                weaponNumber = (weaponNumber + 1);
            }
           
            if (Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                weaponNumber = (weaponNumber - 1);
            } 
        }
        */
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Escarabajo"))
        {
            ContadorDeEscarabajos += 1;
        }

        if (collision.gameObject.CompareTag("Cofre"))
        {
            abrir = true;
        }
        else
        {
            abrir = false;
        }
    }
}
