using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Vachamcung : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Bat dau va cham");
        if(collision.transform.tag == "thung")
        {
            Destroy(collision.gameObject);
        }
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        //Debug.Log("Dang va cham");
    }
    void OnCollisionExit2D(Collision2D collision)
    {
       // Debug.Log("Ket thuc va cham");
    }
}
