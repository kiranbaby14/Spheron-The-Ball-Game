using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 moveVector;
    public Transform tr;
    

    private float speed = 11.0f;
    public float verticalVelocity = 0f;
    public float gravity = 12.0f;

    private float animationDuration = 3.0f;
    public bool isDead = false;
    private float startTime;
    public bool WhiteOb = false;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        startTime = Time.time;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (isDead)
            return;


        if (Time.time - startTime < animationDuration)
        {
            controller.Move(Vector3.forward * 0 * Time.deltaTime);
           
            return;
        }


        moveVector = Vector3.zero;

        if(controller.isGrounded)
        {
            verticalVelocity = -0.5f;
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;

        }

        //X=========================
        moveVector.x = Input.GetAxisRaw("Horizontal") * speed;
        if(Input.GetMouseButton(0))
        {
            if (Input.mousePosition.x > Screen.width / 2)
                moveVector.x = speed;
            else
                moveVector.x = -speed;

        }
        //Y===============================
        moveVector.y = verticalVelocity;
        //Z==============================
        moveVector.z = speed;


        controller.Move(moveVector * Time.deltaTime);
        if (tr.position.y < -9f)
        {
            Death();
        }
    }

    public void SetSpeed(float modifier)
    {
        speed = modifier;
    }

    //it is being called when player hits obstacles


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Obstacle"))
        {
            Death();
        }

    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag.Equals("WhiteObstacle"))
        {
            WhiteOb = true;

        }
            

    }


    public void Death()
    {
        isDead = true;
        GetComponent<Score> ().OnDeath();
    }
}
