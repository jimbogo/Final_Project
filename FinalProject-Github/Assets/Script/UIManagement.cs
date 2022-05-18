using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManagement : MonoBehaviour
{
    public void nextscene(){
        SceneManager.LoadScene(1);
    }
}
