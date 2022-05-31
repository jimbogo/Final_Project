using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform groundcheck;
    public LayerMask groundMask;
    public float groundDistance = 0.4f;

    public Vector3 Player_initial_pos;
    public Quaternion Initial_Rotation;

    public GameObject Mon1;
    public Vector3 Mon1_Ini_Pos;
    public Quaternion Mon1_Rot;
    public GameObject Mon2;
    public Vector3 Mon2_Ini_Pos;
    public Quaternion Mon2_Rot;
    public GameObject Mon3;
    public Vector3 Mon3_Ini_Pos;
    public Quaternion Mon3_Rot;

    public GameObject MiniMap;
    
    public static int Player_Life = 6;
    public GameObject dead;
    public PlayableDirector deadAnimation;
    public GameObject Life;
    public PlayableDirector lifeAnimation;
    public GameObject X1;
    public GameObject X2;
    public GameObject X3;
    private float LastTime;

    private int GemCounter = 0;
    public Text count;

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
        count.text = "0";
        dead.SetActive(false);
        Life.SetActive(false);
        Player_initial_pos = this.transform.position;
        Initial_Rotation = this.transform.rotation;
        Mon1_Ini_Pos = Mon1.transform.position;
        Mon1_Rot = Mon1.transform.rotation;
        Mon2_Ini_Pos = Mon2.transform.position;
        Mon2_Rot = Mon2.transform.rotation;
        Mon3_Ini_Pos = Mon3.transform.position;
        Mon3_Rot = Mon3.transform.rotation;
        Debug.Log(Player_initial_pos);
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
            count.text = GemCounter.ToString();
        }
        if(other.gameObject.tag == "Monster")
        {
            Time.timeScale = 0f;
            PauseGame.GameIsPaused = true;

            Player_Life = Player_Life - 1; 

            dead.SetActive(true);
            MiniMap.SetActive(false);

            deadAnimation.Play();

            deadAnimation.stopped += DeadStopped;

            controller.enabled = false;
            controller.transform.position = Player_initial_pos;
            controller.enabled = true;

            Mon1.transform.SetPositionAndRotation(Mon1_Ini_Pos, Mon1_Rot);
            Mon2.transform.SetPositionAndRotation(Mon2_Ini_Pos, Mon2_Rot);
            Mon3.transform.SetPositionAndRotation(Mon3_Ini_Pos, Mon3_Rot);
        }
    }
    void DeadStopped(PlayableDirector director)
    {
        dead.SetActive(false);
        Life.SetActive(true);
        lifeAnimation.Play();
        
        lifeAnimation.stopped += LifeStopped;
    }
    void LifeStopped(PlayableDirector director)
    {
        Life.SetActive(false);
        MiniMap.SetActive(true);
        
        Time.timeScale = 1f;
        PauseGame.GameIsPaused = false;
    }
}
