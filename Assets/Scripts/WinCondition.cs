using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCondition : MonoBehaviour
{

    private GameObject Player1;
    private GameObject Player2;
    private HealtScript healtP1;
    private HealtScript healtP2;
    public GameObject player1_Win_msg;
    public GameObject player2_Win_msg;
    private TimerToBattle timer;
    private SoundControl soundControl;
    public GameObject PlayAgain_Obj;
    private bool finish;
    // Start is called before the first frame update
    void Start()
    {
        Player1 = GameObject.FindGameObjectWithTag("Player1");
        Player2 = GameObject.FindGameObjectWithTag("Player2");
        healtP1 = Player1.GetComponent<HealtScript>();
        healtP2 = Player2.GetComponent<HealtScript>();
        timer = (TimerToBattle)FindObjectOfType(typeof(TimerToBattle));
        soundControl = (SoundControl)FindObjectOfType(typeof(SoundControl));

    }

    // Update is called once per frame
    void Update()
    {
        TestWin();
        if(finish)
        {
            PlayAgain_Obj.SetActive(true);
            
        }
    }

    void TestWin()
    {
        if (finish)
            return;
       if (healtP2.life <= 0)
        {
            Player1Win();
            Player1.GetComponent<Animator>().SetTrigger("Victory");
            soundControl.PlayWinSound();
            Player1.GetComponent<Rigidbody>().Sleep();
        }

        if (healtP1.life<=0)
        {
            Player2Win();
            Player2.GetComponent<Animator>().SetTrigger("Victory");
            soundControl.PlayWinSound();
            Player2.GetComponent<Rigidbody>().Sleep();
        }


        if(timer.Timer_battle<=0)
        {
            if(healtP1.life>healtP2.life)
            {
                Player1Win();
            }

            if(healtP2.life> healtP1.life)
            {
                Player2Win();
            }
        }
    }

    void Player1Win()
    {
       player1_Win_msg.SetActive(true);
        timer.stopTimer = true;
        finish = true;

    }

    void Player2Win()
    {
        player2_Win_msg.SetActive(true);
         timer.stopTimer = true;
        finish = true;

    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(0);

    }

    

}
