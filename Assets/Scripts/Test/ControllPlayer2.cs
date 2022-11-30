using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ControllPlayer2 : MonoBehaviour
{
    public float Speed;
    public float MaxSpeed = 3;
    public float JumpSpeed = 6;
    public float SpeedRun = 6;
    public float Roll = 10;
    public float CrouchSpeed = 1;
    int Chieu;
    private Animator ani;
    private Rigidbody2D rg;
    private bool Jumping;
    private bool ChamNen;
    private bool Crouch;
    bool Death = false;
    [SerializeField]
    LayerMask WhatIsGround;
    public Transform GroundCheck;
    public float GroundedRadius = .5f;

    public Scrollbar PlayerHealth;
    public float HP;
    public float HPMax = 1f;
    Collider2D test;
    // Start is called before the first frame update


    //public static ControllPlayer2 Instance;
   
    void Start()
    {
       
        PlayerHealth.size = 1f;
        ani = transform.GetChild(0).GetComponent<Animator>();
        rg = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        ChamNen = Physics2D.OverlapCircle(GroundCheck.position, GroundedRadius, WhatIsGround);
        if(ChamNen)
        {
            //Debug.Log("cham nen");
        }
        AddForce(Speed);
        if (ChamNen == true && Speed == 0)
        {
            ani.SetBool("Jumping", Jumping);
        }
        if (ChamNen == true && Speed == 3)
        {
            ani.SetFloat("SpeedFloat", Speed);
        }
        if (ChamNen == true && Speed == 6)
        {
            ani.SetFloat("SpeedFloat", Speed);  
        }
        if (Death == true )
        {
            Speed = 0;
        }
        if (PlayerHealth.size == 0f)
        {
            Speed = 0;
           // ani.SetTrigger("Death");
        }
    }
    public void PreviusUp_click()
    {
        Speed = 0;
        ani.SetFloat("SpeedFloat", Speed);
    }
    public void PreviusDown_click()
    {
        Speed = MaxSpeed;
        Chieu = -1;
        Vector3 Scale = this.transform.localScale;
        Scale.x = -1f;
        this.transform.localScale = Scale;
        if (Crouch == false)
        {
            Speed = MaxSpeed;
            if (ChamNen == true)
            {
                ani.SetFloat("SpeedFloat", Speed);
            }
        }
        else if (Crouch == true)
        {
            Speed = CrouchSpeed;
            ani.SetFloat("SpeedFloat", Speed);
        }
    }
    public void NextUp_click()
    {
        Speed = 0;
        ani.SetFloat("SpeedFloat", Speed);
    }
    public void NextDown_click()
    {
    
        Chieu = 1;
        Vector3 Scale = this.transform.localScale;
        Scale.x = 1f;
        this.transform.localScale = Scale;
        if (Crouch == false)
        {
            Speed = MaxSpeed;
            if (ChamNen == true)
            {
                ani.SetFloat("SpeedFloat", Speed);
            }
        }
        else if(Crouch == true)
        {
            Speed = CrouchSpeed;
            ani.SetFloat("SpeedFloat", Speed);
        }
    }
    public void RunUp_click()
    {
        Speed = 0;
        ani.SetFloat("SpeedFloat", Speed);
    }
    public void RunDown_click()
    {
        Speed = SpeedRun;
        if (ChamNen == true)
        {
            ani.SetFloat("SpeedFloat", Speed);
        }
    }
    public void JumpUp_click()
    {
        Jumping = false;
    }
    public void JumpDown_click() 
    {
        rg.velocity = new Vector3(rg.velocity.x, SpeedRun, 0);
        Jumping = true;
        ani.SetBool("Jumping",Jumping);
    } 
    public void RollUp_click()
    {
        Speed = 0;
        ani.SetFloat("SpeedFloat", Speed);
    }
    public void RollDown_click()
    {
        Speed = transform.localScale.x * Roll * Chieu;
        rg.velocity = new Vector3(Speed, rg.velocity.y, 0);
        ani.SetFloat("SpeedFloat", Speed);
    }
    public void CrouchUp_click()
    {
        Crouch = false;
        ani.SetBool("Crouch", Crouch);
    }
    public void CrouchDown_click()
    {
        Crouch = true;
        ani.SetBool("Crouch", Crouch);
    }
    private void OnCollisionEnter2D(Collision2D collision)  
    {   
    }
    public void AddForce(float Speed)
    {
        rg.velocity = new Vector3(Speed * Chieu, rg.velocity.y, 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Death")
        {
            Death = true;
            ani.SetTrigger("Death");
            PlayerHealth.size -= 0.1f;
        }
    }
}
