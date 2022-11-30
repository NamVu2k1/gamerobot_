using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneBot : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    LayerMask player;
    public Transform vitri1;
    bool Run;
    Animator Ani;
    bool Direction;
    void Start()
    {
        Ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    private void FixedUpdate()
    {
        RaycastHit2D Hits = Physics2D.CircleCast(transform.position, 5f, Vector2.right, 0, player);

        if (Hits)
        {
            transform.position = Vector3.MoveTowards(transform.position, vitri1.transform.position, 1.5f * Time.deltaTime);
            Run = true;
            Ani.SetBool("Run", Run);
            if (transform.position.x > vitri1.position.x)
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
            Run = false;
            Ani.SetBool("Run", Run);
        }
        
    }
}
