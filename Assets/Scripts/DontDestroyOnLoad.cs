using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DontDestroyOnLoad : MonoBehaviour
{

    public GameObject GO_Option;
    
    
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
       
    }

    // Update is called once per frame
    void Update()
    {
        if((SceneManager.GetActiveScene().name == "Game" && Input.GetKeyDown(KeyCode.Escape)))
            {
            GO_Option.SetActive(true);
            }

    }
}
