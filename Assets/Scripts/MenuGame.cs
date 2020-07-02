using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuGame : MonoBehaviour
{
    public GameObject GO_MenuGame;
    public bool active;

    void Start()
    {
        active = false;
    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(!active)
            {
                GO_MenuGame.SetActive(true);
                active = true;

            }
        
            else if(active)
            {
                GO_MenuGame.SetActive(false);
                active = false;
            }
        }


    }


}
