using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesactiveGameObject : MonoBehaviour
{
    public float timer = 0.4f;

    void Start()
    {
        Invoke("DesactiveAfterTime", timer);
    }

   void DesactiveAfterTime()
    {
        Destroy(gameObject);
    }
}
