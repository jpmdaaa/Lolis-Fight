using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealtScript : MonoBehaviour
{

    public float life = 100f;
    private Animator anim;
    private bool Died;
    public Slider life_Slider;


    private void Update()
    {
        life_Slider.value = life;
  
    }
    private void Awake()
    {
        anim = GetComponent<Animator>();
       
    }
     
    public void ApplyDamage(float damage,bool knockDown)
    {
        if (Died)
            return;
        
           
        life -= damage;

        if(life <=0f)
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            Died = true;
            anim.SetTrigger("Death");
        }

        

    }
}
