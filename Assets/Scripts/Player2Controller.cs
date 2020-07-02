using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ComboState2
{
    None,
    Punch1,
    Punch2,
    Punch3,
    Kick1,
    Kick2
}

public class Player2Controller : MonoBehaviour
{
    [Header("Components")]
    private Transform tr;
    private Rigidbody rb;
    private Animator animator;
    public bool pause;
    [Header("Variables moviment")]
    public float speed;
    public float gravity = 8;
    public float Jumpforce;
    private bool canJump;
    [Header("Combat")]
    public bool activeTimertoReset;

    private float default_combo_timer = 0.4f;
    private float current_combo_timer;
    private ComboState2 current_combo_state;

    private TimerToBattle timer;



    void Start()
    {
        tr = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        timer = (TimerToBattle)FindObjectOfType(typeof(TimerToBattle));
       
        current_combo_timer = default_combo_timer;
        current_combo_state = ComboState2.None;
        

    }

    // Update is called once per frame
    void Update()
    {

      

        if (gameObject.GetComponent<HealtScript>().life <= 0 || timer.timer<3.4 || timer.Timer_battle<=0 ||pause)
            return;
        DetectMovement();
        RotatePlayer();
        ComboAttacks();
        ResetComboState();
        
        


    }

    void DetectMovement()
    {
        animator.SetBool("Movement", true);

        if (rb.velocity.x == 0)
        {
            animator.SetBool("Movement", false);
        }


        if(Input.GetKey(KeyCode.D))
        {
            rb.velocity= new Vector3 (1 *speed, rb.velocity.y, rb.velocity.z);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector3( -1 * speed, rb.velocity.y, rb.velocity.z);
        }
  

        if (Input.GetKeyDown(KeyCode.W) && canJump)
        {
            animator.SetTrigger("Jump");
            rb.AddForce(0, Jumpforce, 0, ForceMode.Impulse);
        }


    }

    void RotatePlayer()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.rotation = Quaternion.Euler(0f, Mathf.Abs(90f), 0f);
        }

        else if (Input.GetKeyDown(KeyCode.A))
        {
            transform.rotation = Quaternion.Euler(0f, -Mathf.Abs(90f), 0f);
        }


    }


    void ComboAttacks()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            if (current_combo_state == ComboState2.Punch3 || current_combo_state == ComboState2.Kick1 || current_combo_state == ComboState2.Kick2)
                return;

            current_combo_state++;
            activeTimertoReset = true;
            current_combo_timer = default_combo_timer;

            if (current_combo_state == ComboState2.Punch1)
            {
                animator.SetTrigger("Punch1");
            }

            if (current_combo_state == ComboState2.Punch2)
            {
                animator.SetTrigger("Punch2");
            }

            if (current_combo_state == ComboState2.Punch3)
            {
                animator.SetTrigger("Punch3");
            }

        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            if (current_combo_state == ComboState2.Kick2 || current_combo_state == ComboState2.Punch3)
                return;

            if (current_combo_state == ComboState2.None || current_combo_state == ComboState2.Punch1 || current_combo_state == ComboState2.Punch2)
            {
                current_combo_state = ComboState2.Kick1;
            }

            else if (current_combo_state == ComboState2.Kick1)
            {
                current_combo_state++;
            }


            activeTimertoReset = true;
            current_combo_timer = default_combo_timer;

            if (current_combo_state == ComboState2.Kick1)
            {
                animator.SetTrigger("Kick1");
            }

            if (current_combo_state == ComboState2.Kick2)
            {
                animator.SetTrigger("Kick2");
            }






        }
    }


    void ResetComboState()
    {
        if (activeTimertoReset)
        {
            current_combo_timer -= Time.deltaTime;

            //reset combo 
            if (current_combo_timer <= 0f)
            {
                current_combo_state = ComboState2.None;

                activeTimertoReset = false;
                current_combo_timer = default_combo_timer;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            canJump = true;
            animator.SetBool("IsGround", true);
            gameObject.GetComponent<CapsuleCollider>().height = 1.6f;
         
        }


        if (collision.gameObject.tag == "End")
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
            gameObject.GetComponent<CapsuleCollider>().height = 0.9f;

        }
    }

}
