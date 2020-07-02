using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Options : MonoBehaviour
{

    public GameObject menu;
    public GameObject options;
    public GameObject Controls_Info;
    public Toggle toggleFullScreen;
    public bool fullScreen;

    public GameObject Resolution;
    public GameObject Allbutons;
    public GameObject Sounds;
    public AudioSource audioSource;
    public Scrollbar scrollbar;
    
     PlayerControl p1;
    Player2Controller p2;
    TimerToBattle timer;
    SoundControl sounds_Game;

    void Start()
    {
        fullScreen = true;
       
    }

  
    void Update()
    {
        Screen.fullScreen = fullScreen;

        if (toggleFullScreen.isOn)
        {
            fullScreen = true;
          
        }

        else
        {
            fullScreen = false;
           
        }

        audioSource = (AudioSource)FindObjectOfType(typeof(AudioSource));
        setAudio();

        TestScene();



    }

    public void ReturnMenu()
    {
     

        if (SceneManager.GetActiveScene().name == "Menu")
        {
            menu.SetActive(true);
            options.SetActive(false);
        }
        else
        {
            options.SetActive(false);
            p1.pause = false;
            p2.pause = false;
            timer.stopTimer = false;
            sounds_Game.BattleMusic.GetComponent<AudioSource>().UnPause();
        }

    }

    public void SetResolution(int Resolution)
    {
        if(Resolution == 640)
        {
            Screen.SetResolution(640, 480, fullScreen);
        }

        if (Resolution == 800)
        {
            Screen.SetResolution(800, 600, fullScreen);
        }
        if (Resolution == 1280)
        {
            Screen.SetResolution(1280, 720, fullScreen);
        }

        if (Resolution == 1920)
        {
            Screen.SetResolution(1920, 1080, fullScreen);
        }
    }


    public void OPTResolution()
    {
        Resolution.SetActive(true);
        Allbutons.SetActive(false);
    }

    public void ControlsInfoActive()
    {
        Controls_Info.SetActive(true);
        Allbutons.SetActive(false);
    }

    public void Return()
    {
        
            Resolution.SetActive(false);
            Allbutons.SetActive(true);
            Sounds.SetActive(false);
            Controls_Info.SetActive(false);


    }

    public void SoundControl()
    {
        Resolution.SetActive(false);
        Allbutons.SetActive(false);
        Sounds.SetActive(true);
    }

    public void setAudio()
    {
        
        audioSource.volume = scrollbar.value;
        
    }

    public void TestScene()
    {

        if (SceneManager.GetActiveScene().name == "Game")
        {
            p1 = (PlayerControl)FindObjectOfType(typeof(PlayerControl));
            p2 = (Player2Controller)FindObjectOfType(typeof(Player2Controller));
            timer = (TimerToBattle)FindObjectOfType(typeof(TimerToBattle));
            sounds_Game = (SoundControl)FindObjectOfType(typeof(SoundControl));

            sounds_Game.audioSource.volume = scrollbar.value;
            sounds_Game.WinSound.GetComponent<AudioSource>().volume = scrollbar.value;
            sounds_Game.BattleMusic.GetComponent<AudioSource>().volume = scrollbar.value;

            if (gameObject.active)
            {
                p1.pause = true;
                p2.pause = true;
                timer.stopTimer = true;
                sounds_Game.BattleMusic.GetComponent<AudioSource>().Pause();
            }
          


        }
    }


}
