using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Input_data",menuName = "Input_data")]
public class InputData : ScriptableObject
{
    // Start is called before the first frame update

    public bool isPressed;
    public bool isHeld;
    public bool isReleased;
}
