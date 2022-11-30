using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bot1Movement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    LayerMask player;
    public Transform Pos;
    void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {

        RaycastHit2D Hits = Physics2D.CircleCast(transform.position, 5f, Vector2.right, 0, player);

        if (Hits)
        {
            transform.position = Vector3.MoveTowards(transform.position,Pos.transform.position, 1.5f * Time.deltaTime);
            
            if (transform.position.x > Pos.transform.position.x)
            {
                Vector3 Scale = transform.localScale;
                Scale.x = -1;
                transform.localScale = Scale;
            }
            else
            {
                Vector3 Scale = transform.localScale;
                Scale.x = 1;
                transform.localScale = Scale;
            }
        }
        else
        {
           
        }
    }
}
