﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationDelegate : MonoBehaviour
{
    public GameObject left_Arm_Attack_Point, right_Arm_Attack_Point, left_Leg_Attack_Point, right_Leg_Attack_Point;

  
    void Left_Arm_Attak_Off()
    {
        if(left_Arm_Attack_Point.activeInHierarchy)
        {
            left_Arm_Attack_Point.SetActive(false);
        }
    }

    void Left_Arm_Attak_On()
    {
        left_Arm_Attack_Point.SetActive(true);
    }


    void Right_Arm_Attak_Off()
    {
        if (right_Arm_Attack_Point.activeInHierarchy)
        {
            right_Arm_Attack_Point.SetActive(false);
        }
    }


    void Right_Arm_Attak_On()
    {
        right_Arm_Attack_Point.SetActive(true);
    }


    void Left_Leg_Attak_Off()
    {
        if (left_Leg_Attack_Point.activeInHierarchy)
        {
            left_Leg_Attack_Point.SetActive(false);
        }
    }

    void Left_Leg_Attak_On()
    {
        left_Leg_Attack_Point.SetActive(true);
    }


    void Right_Leg_Attak_Off()
    {
        if (right_Leg_Attack_Point.activeInHierarchy)
        {
            right_Leg_Attack_Point.SetActive(false);
        }
    }

    void Right_Leg_Attak_On()
    {
        right_Leg_Attack_Point.SetActive(true);
    }


}
