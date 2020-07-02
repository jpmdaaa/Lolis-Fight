using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerToBattle : MonoBehaviour
{

    public GameObject[] Images;
    public float timer;
    public float Timer_battle;
    public Text timer_TXT;
    public bool stopTimer;
    // Start is called before the first frame update
    void Start()
    {
        Images[0].SetActive(true);
     
    }

    // Update is called once per frame
    void Update()
    {
        timeToBattle();
        if(timer>=3.5)
        {
            Timertext();
        }
       

    }

    private void Timertext()
    {
        if(Timer_battle>0 && !stopTimer)
        {
            Timer_battle = Timer_battle - Time.deltaTime;
        }
       
        timer_TXT.text = Timer_battle.ToString("0");


    }

    private void timeToBattle()
    {
        if (timer < 3.5)
        {
            timer = Time.timeSinceLevelLoad;

        }
        else
            return;

        if (timer >= 1)
        {
            Images[0].SetActive(false);
            Images[1].SetActive(true);
        }
        if (timer >= 2)
        {
            Images[1].SetActive(false);
            Images[2].SetActive(true);
        }
        if (timer >= 3)
        {
            Images[2].SetActive(false);
            Images[3].SetActive(true);
        }
        if (timer >= 3.4)
        {
            Images[3].SetActive(false);

        }
    }

}
