using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Onmouse : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Scroll;
    public Transform _parent;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        var SpawnTile = Instantiate(Scroll, new Vector3(transform.position.x,transform.position.y,5f), Quaternion.identity, _parent);
    }
    private void OnMouseEnter()
    {
        Debug.Log("Enter");
    }
}
