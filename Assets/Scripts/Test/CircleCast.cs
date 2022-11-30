using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleCast : MonoBehaviour
{
    [SerializeField]
    LayerMask VaCham;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void FixedUpdate()
    {
        RaycastHit2D Hits = Physics2D.CircleCast(transform.position, 5f, Vector2.right, 10f, VaCham);
        if(Hits)
        {
            Debug.Log("Va cham:"+ Hits.transform.name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
