using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RamdonMap : MonoBehaviour
{
    private Camera mainCam;
    private Skybox sky;
    public GameObject[] maps;
    public int sortMap_Number;
    public Material[] skys_mat;
    public GameObject P1;
    public GameObject P2;
    public Transform[] startFase;

    void Start()
    {
        sortMap_Number = Random.Range(0, 100);
        mainCam = (Camera)FindObjectOfType(typeof(Camera));
        sky = mainCam.GetComponent<Skybox>();
        SortMap();
    }


    void SortMap()
    {
        if(sortMap_Number<50)
        {
            maps[0].SetActive(true);
            sky.material = skys_mat[0];
            P1.GetComponent<Transform>().position = startFase[0].position;
            P2.GetComponent<Transform>().position = startFase[1].position;
            mainCam.GetComponent<Transform>().position = new Vector3(-2.8f, 2.58f, -3.61f);

        }
        if (sortMap_Number > 50)
        {
            maps[1].SetActive(true);
            sky.material = skys_mat[1];
            P1.GetComponent<Transform>().position = startFase[2].position;
            P2.GetComponent<Transform>().position = startFase[3].position;
            mainCam.GetComponent<Transform>().position = new Vector3(-0.33f, 2.58f, -12.25f);

        }



    }

}
