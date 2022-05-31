using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lifeControl : MonoBehaviour
{
    public GameObject X1;
    public GameObject X2;
    public GameObject X3;
    // Start is called before the first frame update
    void Start()
    {
        X1.SetActive(false);
        X2.SetActive(false);
        X3.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerMovement.Player_Life == 3)
        {
            X1.SetActive(false);
            X2.SetActive(false);
            X3.SetActive(false);
        }else if(PlayerMovement.Player_Life == 2)
        {
            X1.SetActive(true);
            X2.SetActive(false);
            X3.SetActive(false);
        }else if(PlayerMovement.Player_Life == 1)
        {
            X1.SetActive(true);
            X2.SetActive(true);
            X3.SetActive(false);
        }else if(PlayerMovement.Player_Life == 0)
        {
            X1.SetActive(true);
            X2.SetActive(true);
            X3.SetActive(true);

        }

    }
}
