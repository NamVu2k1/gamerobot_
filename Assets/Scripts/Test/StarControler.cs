using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarControler : MonoBehaviour
{
    // Start is called before the first frame update
    Coroutine lastRouTine = null;
    Rigidbody2D rg;
    private GameObject ViTri;
    Vector3 randomvitri;

   
    void Start()
    {
        lastRouTine = StartCoroutine(Xoayban());
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, -0.7f * Time.deltaTime, 0);

    }
    private IEnumerator Xoayban()
    {
        while (true)
        {
          

            randomvitri = new Vector3(Random.Range(-2.8f, 2.8f), 5,0);
            Pow1(randomvitri);

            yield return new WaitForSeconds(Random.Range(0.4f,1f));
        }
    }
    public void Pow1(Vector3 ran)
    {
        GameObject Newrg = PoolManagerStar.Instance.SpawmPool1("While", ran, transform.rotation) ;

       
        //Dan1(Newrg);
     

    }
}
