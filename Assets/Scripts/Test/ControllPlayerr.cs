using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ControllPlayerr : MonoBehaviour
{
    // Start is called before the first frame update
    private bool ChamNen;
    private bool jumpdouble;
    private bool jump;
    private bool Crouch;
    private bool Death = false;
    private Animator ani;
    private Rigidbody2D rg;
    public float Speed;
    public float MaxSpeed = 3;
    public float JumpSpeed = 6;
    public float SpeedRun = 6;
    public float Roll = 10;
    public float CrouchSpeed = 1;
    void Start()
    {
        ani = GetComponent<Animator>();
        rg = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        AddForce(Speed);
        if(ChamNen == true && Speed == 0)
        {
            ani.SetInteger("Status", 0);
        }
        if (ChamNen == true && (Speed == 3 || Speed == -3))
        {
            ani.SetInteger("Status", 2);
        }
        if(jump == true && ChamNen == true)
        {
            ani.SetInteger("Status", 3);
            rg.velocity = new Vector3(rg.velocity.x, JumpSpeed, 0);
            ChamNen = false;
        }
        if(ChamNen == true && (Speed == 6|| Speed == -6))
        {
            ani.SetInteger("Status", 1);
        }
        if(Death == true)
        {
            ani.SetInteger("Status", 5);
            Speed = 0;
        }
    }
    public void PreviusUp_click()
    {
        Speed = 0;
        ani.SetInteger("Status", 0);
    }
    public void PreviusDown_click()
    {
        Vector3 Scale = this.transform.localScale;
        Scale.x = -1f;
        this.transform.localScale = Scale;
        if (Crouch == false)
        {
            Speed = -MaxSpeed;
            if (ChamNen == true)
            {
                ani.SetInteger("Status", 2);
            }
        }
        else if (Crouch == true)
        {
            Speed = -CrouchSpeed;
            ani.SetInteger("Status", 2);
        }
    }
    public void NextUp_click()
    {
        Speed = 0;
        ani.SetInteger("Status", 0);
    }
    public void NextDown_click()
    {
        Vector3 Scale = this.transform.localScale;
        Scale.x = 1f;
        this.transform.localScale = Scale;
        if (Crouch == false)
        {
            Speed = MaxSpeed;
            if (ChamNen == true)
            {
                ani.SetInteger("Status", 2);
            }
        }
        else if (Crouch == true)
        {
            Speed = CrouchSpeed;
            ani.SetInteger("Status", 2);
        }
    }
    public void JumpUp_click()
    {
        jump = false;
    }
    public void JumpDown_click()
    {
        if (jumpdouble == true)
        {
            rg.velocity = new Vector3(rg.velocity.x, JumpSpeed, 0);
            ani.SetInteger("Status", 3);
            jumpdouble = false;
        }
        if (ChamNen == true)
        {
            rg.velocity = new Vector3(rg.velocity.x, JumpSpeed, 0);
            ani.SetInteger("Status", 3);
            ChamNen = false;
            jumpdouble = true;
        }
        jump = true;
    }
    public void RunUp_click()
    {
        Speed = 0;
    }
    public void RunDown_click()
    {
        Speed = SpeedRun * this.transform.localScale.x;
        rg.velocity = new Vector3(Speed, rg.velocity.y, 0);
        if(ChamNen == true)
        {
            ani.SetInteger("Status", 1);
        }   
    }
    public void RollUp_()
    {
        Speed = 0;
        ani.SetInteger("Status", 0);
    }
    public void RollDown_click()
    {
        Speed = Roll * this.transform.localScale.x;
        rg.velocity = new Vector3(Speed, rg.velocity.y, 0);
        ani.SetInteger("Status", 4);
    }
    public void CrouchUp_click()
    {
        ani.SetBool("StatusCrouch", false);
        Crouch = false;
    }
    public void CrouchDown_click()
    {  
        ani.SetBool("StatusCrouch", true);  
        Crouch = true;
    }
    public void AddForce(float Speed)
    {
        rg.velocity = new Vector3(Speed, rg.velocity.y, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Nen")
        {
            ChamNen = true;
            jumpdouble = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Death")
        {
            Death = true;
        }
    }
}