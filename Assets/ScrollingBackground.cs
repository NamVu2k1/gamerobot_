using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    Vector2 parallaxEffecMultiplier;
    public Transform cameraTransform;
    private Vector3 lastCameraPosition; 
    void Start()
    {
        //cameraTransform = Camera.main.transform;
        lastCameraPosition = cameraTransform.position;
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;
        transform.position += new Vector3(deltaMovement.x * parallaxEffecMultiplier.x, deltaMovement.y * parallaxEffecMultiplier.y);
        lastCameraPosition = cameraTransform.position;
    }
}
