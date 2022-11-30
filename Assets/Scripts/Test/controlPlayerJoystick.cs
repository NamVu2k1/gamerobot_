using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlPlayerJoystick : MonoBehaviour
{
    public MovementJoystick movementJoystick;
    [Range(0,500)]
    public float PlayerSpeed;
    private Rigidbody2D rb;
    float gocjoystick;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
      
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().angularVelocity = 0;
        if(GetComponent<Rigidbody2D>().rotation >180)
        {
            GetComponent<Rigidbody2D>().rotation = -360 + GetComponent<Rigidbody2D>().rotation;
        }
        if(GetComponent<Rigidbody2D>().rotation < -180)
        {
            GetComponent<Rigidbody2D>().rotation = 360 + GetComponent<Rigidbody2D>().rotation;
        }    
        if (movementJoystick.joystickVec.y != 0)
        {
            //rb.velocity= new Vector2(movementJoystick.joystickVec.x * PlayerSpeed, movementJoystick.joystickVec.y * PlayerSpeed);
            rb.velocity = transform.right * Time.fixedDeltaTime * PlayerSpeed;
            //var vertical = Input.GetAxis("Vertical") * Vector3.forward * Time.fixedDeltaTime * PlayerSpeed;
            if (movementJoystick.joystickVec.y > 0)
            {
                gocjoystick = Mathf.Acos(movementJoystick.joystickVec.x) * 180f / Mathf.PI;
            }
            else
            {
                gocjoystick = -Mathf.Acos(movementJoystick.joystickVec.x) * 180f / Mathf.PI;   
            }
            if (gocjoystick - GetComponent<Rigidbody2D>().rotation > 0  && gocjoystick - GetComponent<Rigidbody2D>().rotation < 180 || gocjoystick - GetComponent<Rigidbody2D>().rotation < -180) 
            {  
                GetComponent<Rigidbody2D>().rotation += 200f * Time.fixedDeltaTime;
            }
            if (gocjoystick - GetComponent<Rigidbody2D>().rotation < 0 && gocjoystick - GetComponent<Rigidbody2D>().rotation > -180 || gocjoystick - GetComponent<Rigidbody2D>().rotation > 180)
            {
                GetComponent<Rigidbody2D>().rotation -= 200f * Time.fixedDeltaTime;

            }
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }
    

}
