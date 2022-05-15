using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashlight : MonoBehaviour
{
    public GameObject player;
    private Vector3 flash;
    public Light Flashlight;
    public float rotate_speed = 3f;
    public int lightcontrol = 6;

    // Start is called before the first frame update
    void Start()
    {
        player = Camera.main.gameObject;
        flash = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + flash;
        transform.rotation = Quaternion.Slerp(transform.rotation, player.transform.rotation, rotate_speed * Time.deltaTime);
        InvokeRepeating("FlashingLight", 1f, 2000f);
    }
    void LightOn()
    {
        Flashlight.enabled = true;
    }
    void LightOff()
    {
        Flashlight.enabled = false;
    }
    void RandNum()
    {
        lightcontrol = Random.Range(1, 30);
    }
    void FlashingLight()
    {
        InvokeRepeating("RandNum", 3f, 2000f);
        if (lightcontrol <= 3)
        {
            LightOff();
            Invoke("LightOn", 0.5f);
        }
        else
        {
            LightOn();
        }
    }
}
