using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeSceneLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {   
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(0);
    }


}
