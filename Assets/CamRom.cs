using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRom : MonoBehaviour
{
    public GameObject VirtualCamera;
    public GameObject VirtualCamera2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "DoiTuong")
        {
            VirtualCamera.SetActive(true);
            VirtualCamera2.SetActive(false);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "DoiTuong")
        {
            VirtualCamera.SetActive(false);
            VirtualCamera2.SetActive(true);
        }
    }
}
