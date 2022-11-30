using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pooling : MonoBehaviour
{
    // Start is called before the first frame update



    private void FixedUpdate()
    {
        spawn.Instance.SpawmPool1("+3", new Vector3(0,0,0), transform.rotation);
    }
}
