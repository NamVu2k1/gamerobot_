using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevelgame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            //Debug.Log(SceneManager.GetAllScenes().Length);
        }
    }
}
