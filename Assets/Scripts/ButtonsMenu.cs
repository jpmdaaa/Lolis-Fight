using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class ButtonsMenu : MonoBehaviour
{

    // Use this for initialization

   
    public GameObject GO_Menu;
    public GameObject GO_Options;


    private void Awake()
    {
        DontDestroyOnLoad(GO_Options);
    }

    public void Playgame()
    {
        SceneManager.LoadScene("Game");
    }

    public void Options()
    {
        GO_Menu.SetActive(false);
      
        GO_Options.SetActive(true);
    }

}
