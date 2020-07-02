using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackUniversal : MonoBehaviour
{
    public LayerMask collosionLayer;
    public float radius = 1f;
    public float damage = 2f;
    public float force = 50f;

    public GameObject hit_FX_Prefab;
    private SoundControl soundControl;
    public AttackUniversal[] other_Points;
        
    // Update is called once per frame
    void Update()
    {
        DetectCollision();
    }
    private void Start()
    {
        soundControl = (SoundControl)FindObjectOfType(typeof(SoundControl));
    }


    void DetectCollision()
    {


        Collider[] hit = Physics.OverlapSphere(transform.position, radius, collosionLayer);
        if(hit.Length>0)
        {
            
            if (hit[0].GetComponent<HealtScript>().life <= 0)
                return;
            Vector3 hitFX_Pos = hit[0].transform.position;
            hitFX_Pos.y += 1.5f;
            soundControl.PlayHitSound();

            if (hit[0].transform.forward.x > 0)
            {
                hitFX_Pos.x += 0.2f;
                
                for(int i=0;i<4;i++)
                {
                    other_Points[i].force += 10;
                    
                }
                    
                hit[0].GetComponent<Rigidbody>().AddForce(-force , hit[0].GetComponent<Transform>().position.y, hit[0].GetComponent<Transform>().position.z);
                hit[0].GetComponent<Animator>().SetTrigger("TakeHit");
            }
            else if (hit[0].transform.forward.x < 0)
            {
                hitFX_Pos.x -= 0.2f;

                for (int i = 0; i < 4; i++)
                {
                    other_Points[i].force +=10;
                    
                }

                hit[0].GetComponent<Rigidbody>().AddForce(force, hit[0].GetComponent<Transform>().position.y, hit[0].GetComponent<Transform>().position.z);
            
                hit[0].GetComponent<Animator>().SetTrigger("TakeHit");
            }


        


            Instantiate(hit_FX_Prefab, hitFX_Pos, Quaternion.identity);
            hit[0].GetComponent<HealtScript>().ApplyDamage(damage, true);
          
        }

        gameObject.SetActive(false);
    }

}
