using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform groundcheck;
    public LayerMask groundMask;
    public float groundDistance = 0.4f;

    private int GemCounter = 0;

    bool isGround;

    AudioSource[] arraysound;
    AudioSource footstep;
    AudioSource runstep;

    public float walk_speed = 8f;
    public float run_speed = 18f;

    Vector3 velocity;
    public float gravity =-19.6f;

    void Start()
    {
        arraysound = GetComponents<AudioSource>();
        footstep = arraysound[0];
        runstep = arraysound[1];
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

        if(Input.GetKey(KeyCode.LeftShift)){
            controller.Move(movement * run_speed * Time.deltaTime );
        }
        else{
            controller.Move(movement * walk_speed * Time.deltaTime );
        }

        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift) == false)
        {
            if (!footstep.isPlaying)
            {
                footstep.Play();
            }
            if (runstep.isPlaying)
            {
                runstep.Stop();
            }
            InvokeRepeating("ShakeCharacter", 0.1f, 0.5f);
            InvokeRepeating("ShakeCharacter2", 0.2f, 0.5f);
        }
        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
        {
            InvokeRepeating("ShakeCharacter", 0.01f, 0.05f);
            InvokeRepeating("ShakeCharacter2", 0.02f, 0.05f);
            if (footstep.isPlaying)
            {
                footstep.Stop();                
            }
            if (!runstep.isPlaying)
            {
                runstep.Play();
            }
        }
        else
        {
            CancelInvoke("ShakeCharacter");
            CancelInvoke("ShakeCharacter2");
            footstep.Stop();
            runstep.Stop();
        }
        

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    void ShakeCharacter()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            velocity.y = 3f;
        }
        else
        {
            velocity.y = 1f;
        }
    }
    void ShakeCharacter2()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            velocity.y = -5f;
        }
        else
        {
            velocity.y = -3f;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Gem")
        {
            GemCounter = GemCounter + 1;
            Debug.Log(GemCounter);
        }
    }
}
