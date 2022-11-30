using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vachammem : MonoBehaviour
{
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
        Debug.Log("bat dau va cham");
        if(collision.tag == "thung")
        {
            Destroy(collision.gameObject, 2f);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("dang va cham");
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("ket thuc va cham");
    }
}
