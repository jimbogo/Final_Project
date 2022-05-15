using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform groundcheck;
    public LayerMask groundMask;
    public float groundDistance = 0.4f;

    bool isGround;

    public float walk_speed = 8f;
    public float run_speed = 18f;

    Vector3 velocity;
    public float gravity =-19.6f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isGround = Physics.CheckSphere(groundcheck.position, groundDistance, groundMask);

        if(isGround && velocity.y < 0){
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 movement = transform.right * x + transform.forward * z;

        if(Input.GetKey(KeyCode.Space)){
            controller.Move(movement * run_speed * Time.deltaTime );
        }else{
            controller.Move(movement * walk_speed * Time.deltaTime );
        }
        

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
