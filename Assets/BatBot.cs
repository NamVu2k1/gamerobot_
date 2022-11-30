using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatBot : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    LayerMask player;
    public Transform vitri1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        RaycastHit2D Hits = Physics2D.CircleCast(transform.position,5f, Vector2.right, 0, player);
        if (Hits)
        {
            transform.position = Vector3.MoveTowards(transform.position, vitri1.transform.position, 2 * Time.deltaTime);
            //Debug.Log("Va cham:" + Hits.transform.name);
        }
    }
}
