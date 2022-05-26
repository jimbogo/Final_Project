using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class UIManagement : MonoBehaviour
{

    public void nextscene(){

        SceneManager.LoadScene(1);
    }

    public void QuitGame(){
        
        Application.Quit();
    }

    public void SetMouseSensitive(float val){
        Mouselook.mouseSensitivity = val;
    }


    public AudioMixer audioMixer;

    public void SetVolume (float volume){

        audioMixer.SetFloat("Volume", volume);
    }
}
