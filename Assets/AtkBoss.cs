using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtkBoss : MonoBehaviour
{
    public GameObject Player12;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BossAttack()
    {
        Player12.GetComponent<ControllPlayer2>().PlayerHealth.size -= 0.1f;
    }
}
