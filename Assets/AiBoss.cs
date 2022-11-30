using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiBoss : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator ani;
    private Rigidbody2D rg;
    public GameObject Boss1;
    public Transform Player1;
  
    //public Transform GioiHan;
    bool direct = true;
    bool canFlip = true;
    bool attack = false;
    public Transform vitri1;
    public Transform vitri2;
    
    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
        ani = transform.GetChild(0).GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        ChieuBoss(); 
        if (canFlip)
        {
            attack = false;
      
            if (direct == true)
            {
                transform.position = Vector3.MoveTowards(transform.position, vitri1.transform.position, 2 * Time.deltaTime);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, vitri2.transform.position, 2 * Time.deltaTime);
            }
        }
        else
        {
            if(Player1.transform.position.x - transform.position.x >= 2.5f || transform.position.x - Player1.transform.position.x >= 2.5f)
            {
                attack = false;
                transform.position = Vector3.MoveTowards(transform.position, Player1.transform.position, 2 * Time.deltaTime);
            }
            else
            {
                attack = true;
            }
        }
        ani.SetBool("Attack", attack);
    }
    void ChieuBoss()
    {
        if(transform.position.x == vitri1.transform.position.x)
        {
            flip();  
        }
        else if(transform.position.x == vitri2.transform.position.x)
        {
            flip();
        }
    }
    void flip()
    {
        if(!canFlip)
        {
            return;
        }
        direct = !direct;
        Vector3 Scale1 = transform.localScale;
        Scale1.x *= -1f;
        transform.localScale = Scale1;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "DoiTuong")
        {
            if(direct && collision.transform.position.x  < transform.position.x)
            {
                flip(); 
            }
            else if(!direct && collision.transform.position.x > transform.position.x)
            {
                flip();
            }
            canFlip = false;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "DoiTuong")
        {
        }
    }
    private void OnTriggerExit2D(Collider2D collision)  
    {
        if (collision.tag == "DoiTuong")
        {
            canFlip = true;
            rg.velocity = new Vector3(0, rg.velocity.y, 0);
            if(transform.position.x > vitri1.transform.position.x)
            {
                flip();   
            }
            else if(transform.position.x < vitri2.transform.position.x)
            {
                flip();
            }
        }
    }
   
        
}
