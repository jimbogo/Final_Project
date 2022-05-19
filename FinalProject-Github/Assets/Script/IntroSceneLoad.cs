using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroSceneLoad : MonoBehaviour
{
    void OnEnable(){
        SceneManager.LoadScene(2);
    }
}
