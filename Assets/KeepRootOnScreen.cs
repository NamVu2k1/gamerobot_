using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepRootOnScreen : MonoBehaviour
{
    Vector2 screenBounds;
    public GameObject Robot;
    float RotbotWidth;
    float RotbotHeight;
    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        RotbotWidth = Robot.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        RotbotHeight = Robot.GetComponent<SpriteRenderer>().bounds.size.y / 2;
    }

    private void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * -1 + RotbotHeight, screenBounds.x - RotbotWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y * -1 + RotbotHeight, screenBounds.y - RotbotHeight);
        transform.position = viewPos;
    }
}
