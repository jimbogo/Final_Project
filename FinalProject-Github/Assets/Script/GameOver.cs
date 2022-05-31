using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerMovement.Player_Life == 5){
            SceneManager.LoadScene(3);
        }
       
    }


}
