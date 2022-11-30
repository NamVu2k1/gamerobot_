using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementplayer : MonoBehaviour
{
    // Start is called before the first frame update
    public float playerSpeed;
    Rigidbody2D rg;
    public static Vector3 Positon ;
    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    private void FixedUpdate()
    {
        Positon = transform.position;
        if(joystickControler.joystickVec.y != 0)
        {
            rg.velocity = new Vector2(joystickControler.joystickVec.x * playerSpeed * Time.fixedDeltaTime, joystickControler.joystickVec.y * playerSpeed* Time.fixedDeltaTime);
        }
        else
        {
            rg.velocity = Vector2.zero;
        }
    }
}
