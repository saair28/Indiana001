using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlle : MonoBehaviour
{
    public float MoveHorizontal;
    public float MoveVertical;
    private Vector3 playerInput;

    private CharacterController player;

    public float PlayerSpeed;
    private Vector3 playerMove;
    public float gravity = 9.8f;
    public float fallVel;

    public Camera MainCam;
    private Vector3 Camforward;
    private Vector3 CamRight;
    public float jumpForce;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveHorizontal = Input.GetAxis("Horizontal");
        MoveVertical = Input.GetAxis("Vertical");

        playerInput = new Vector3(MoveHorizontal, 0, MoveVertical);
        playerInput = Vector3.ClampMagnitude(playerInput, 1);

        CamDirection();

        playerMove = playerInput.x * CamRight + playerInput.z * Camforward;

        playerMove = playerMove * PlayerSpeed;

        player.transform.LookAt(player.transform.position + playerMove);

        SetGravity();

        PlayerSkills();

        player.Move(playerMove * Time.deltaTime);

        Debug.Log(player.isGrounded);
    }

    void CamDirection()
    {
        Camforward = MainCam.transform.forward;

        CamRight = MainCam.transform.right;

        CamRight.y = 0;
        Camforward.y = 0;

        Camforward = Camforward.normalized;

        CamRight = CamRight.normalized;
    }

    //Funcion para las habilidades
    void PlayerSkills()
    {
        if(player.isGrounded && Input.GetButtonDown("Jump"))
        {
            fallVel = jumpForce;
            playerMove.y = fallVel;
        }
    }

    void SetGravity()
    {
        if (player.isGrounded)
        {
            fallVel = -gravity * Time.deltaTime;

            playerMove.y = fallVel;
        }
        else
        {
            fallVel -= gravity * Time.deltaTime;

            playerMove.y = fallVel;
        }
    }
}
