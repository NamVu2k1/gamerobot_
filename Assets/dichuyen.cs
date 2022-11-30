using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dichuyen : MonoBehaviour
{
    // Start is called before the first frame update
    public float duration = 1f;
    float rate = 0;
    float time = 0;
    public Vector3 StartPos;
    public Vector3 targetPos;
    [Header("Draw Curve")]
    public AnimationCurve moveCurve;
    void Start()
    {
        StartPos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        MoveObject(targetPos);
    }
    void MoveObject(Vector3 targetPos)
    {
        rate = 1 / duration;
        time += rate * Time.deltaTime;
        transform.localPosition = Vector3.Lerp(StartPos,targetPos,moveCurve.Evaluate(time));
    }
}
