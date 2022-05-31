using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    public AudioMixer MonsterMixer;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(GameIsPaused){
                Resume();
                
            }else{
                Pause();
                
            }
        }
    }

    public void Resume(){

        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        MonsterMixer.SetFloat("Monster",gamevolume);

    }

    void Pause(){

        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        Cursor.lockState = CursorLockMode.None;
        MonsterMixer.SetFloat("Monster",-40f);
    }

    public void BackToMenu(){

        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Restart(){

        SceneManager.LoadScene(2);
        Time.timeScale = 1f;
        GameIsPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public AudioMixer audioMixer;

    public void SetVolume (float volume){

        audioMixer.SetFloat("Volume", volume);
    }

    float gamevolume;

    public void SetGameVolume(float volume){
        gamevolume = volume;
    }

    public void SetMouseSensitive(float value){
        Mouselook.mouseSensitivity = value;
    }
}
