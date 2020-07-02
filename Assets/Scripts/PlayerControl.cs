using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ComboState
{
    None,
    Punch1,
    Punch2,
    Punch3,
    Kick1,
    Kick2
}

public class PlayerControl : MonoBehaviour
{
    [Header ("Components")]
    private Transform tr;
    private Rigidbody rb;
    private Animator animator;
    public bool pause;
    [Header("Variables moviment")]
    public float speed;
    public float gravity=8;
    public float Jumpforce;
    private bool canJump;
    [Header("Combat")]
    public bool activeTimertoReset;

    private float default_combo_timer = 0.4f;
    private float current_combo_timer;
    private ComboState current_combo_state;

    private TimerToBattle timer;


    void Start()
    {
        tr = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        timer = (TimerToBattle)FindObjectOfType(typeof(TimerToBattle));
        
        current_combo_timer = default_combo_timer;
        current_combo_state = ComboState.None;

    


    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<HealtScript>().life <= 0 || timer.timer < 3.4 || timer.Timer_battle <= 0 || pause)
            return;
        DetectMovement();
         RotatePlayer();
        ComboAttacks();
        ResetComboState();


    }

    void DetectMovement()
    {

        if(Input.GetAxisRaw("Horizontal")!=0)
        {
            rb.velocity = new Vector3(Input.GetAxisRaw("Horizontal") * (speed), rb.velocity.y, rb.velocity.z);

        }

        animator.SetBool("Movement",true);
    
        if(rb.velocity.x==0)
        {
            animator.SetBool("Movement", false);
        }

        /*
        if(Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector3(rb.velocity.x - speed , rb.velocity.y, rb.velocity.z);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector3(rb.velocity.x + speed, rb.velocity.y, rb.velocity.z);
        }
        */


        if (Input.GetKeyDown(KeyCode.UpArrow) && canJump)
        {
            animator.SetTrigger("Jump");
            rb.AddForce(0, Jumpforce, 0,ForceMode.Impulse);
        }
        

    }

    void RotatePlayer()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.rotation = Quaternion.Euler(0f,Mathf.Abs(90f),0f);
        }

        else if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.rotation = Quaternion.Euler(0f, -Mathf.Abs(90f), 0f);
        }
       

    }


    void ComboAttacks()
    {
        if(Input.GetKeyDown(KeyCode.Keypad1))
        {
            if (current_combo_state == ComboState.Punch3 || current_combo_state == ComboState.Kick1 || current_combo_state == ComboState.Kick2)
                return;

            current_combo_state++;
            activeTimertoReset = true;
            current_combo_timer = default_combo_timer;

            if(current_combo_state==ComboState.Punch1)
            {
                animator.SetTrigger("Punch1");
            }

            if (current_combo_state == ComboState.Punch2)
            {
                animator.SetTrigger("Punch2");
            }

            if (current_combo_state == ComboState.Punch3)
            {
                animator.SetTrigger("Punch3");
            }

        }
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            if (current_combo_state == ComboState.Kick2 || current_combo_state == ComboState.Punch3)
                return;

            if(current_combo_state==ComboState.None || current_combo_state== ComboState.Punch1 || current_combo_state== ComboState.Punch2)
            {
                current_combo_state = ComboState.Kick1;
            }

            else if(current_combo_state==ComboState.Kick1)
            {
                current_combo_state++;
            }

           
            activeTimertoReset = true;
            current_combo_timer = default_combo_timer;

            if (current_combo_state == ComboState.Kick1)
            {
                animator.SetTrigger("Kick1");
            }

            if (current_combo_state == ComboState.Kick2)
            {
                animator.SetTrigger("Kick2");
            }

           

          
        }
    }


    void ResetComboState()
    {
        if(activeTimertoReset)
        {
            current_combo_timer -= Time.deltaTime;

            //reset combo 
            if(current_combo_timer<=0f)
            {
                current_combo_state = ComboState.None;

                activeTimertoReset = false;
                current_combo_timer = default_combo_timer;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag== "Ground")
        {
            canJump = true;
            animator.SetBool("IsGround", true);
           
            
        }

        if(collision.gameObject.tag== "End")
        {
            gameObject.GetComponent<HealtScript>().life = 0;
        }
    }

    private void OnCollisionExit(Collision collision)
    {

        if (collision.gameObject.tag == "Ground")
        {
            canJump = false;
            animator.SetBool("IsGround", false);
            
          
        }
    }

}
