using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCast : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    LayerMask VaCham;
    void Start()
    {
        
    }

    // Update is called once per frame

    private void FixedUpdate()
    {
        RaycastHit2D hits = Physics2D.BoxCast(transform.position,new Vector2(10f,10f),0f, Vector2.down,10f, VaCham);
        Debug.Log(hits.normal);
        if (hits)
        {
            
            //Debug.Log(hits.normal);
           
        }

    }
    void Update()
    {
        
    }
}
