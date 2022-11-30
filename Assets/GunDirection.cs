using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunDirection : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Joystick;
    public GameObject joystickBG;
    public Vector2 JoystickVec;
    private Vector2 JoystickTouchPos;
    private Vector2 JoystickOriginalPos;
    void Start()
    {
        JoystickOriginalPos = joystickBG.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
