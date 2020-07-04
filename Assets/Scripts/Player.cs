using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int ContadorDeEscarabajos;

    public static Player instance;

    public float speed = 1f;
    public float rotationSpeed;
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

    public GameObject arma;

    //private Camera mainCamera;

    public int Could = 1;

    public bool abrir = false;

    public int municion;

    public bool restarMuni;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        instance = this;

        /*
        mainCamera = FindObjectOfType<Camera>();
        */
        //CurrentWeapon = Weapons[0];

    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();

        restarEs = ObjetoEscarabajo.GetComponent<ObjetoEscarabajo>().restarEscara;

        Lento = telaraña.GetComponent<Telaraña>().lento;

        restarMuni = arma.GetComponent<Arma>().restarMuni;

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
            speed = 15f;
        }
        else
        {
            speed = 30f;
        }

        if (restarMuni == true)
        {
            municion = municion - 1;
        }
        else
        {

        }
    }

    void restarEscarabajo()
    {
        ContadorDeEscarabajos = ContadorDeEscarabajos - 15;

        restarEs = false;
    }

    void PlayerMovement()
    {
        float h = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float v = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        Vector3 playerMovement = new Vector3(h, 0f, v) * speed * Time.deltaTime;

        rb.MovePosition (playerMovement + transform.position);
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

        if (collision.gameObject.CompareTag("Municion"))
        {
            municion += 1;
        }
    }
}
