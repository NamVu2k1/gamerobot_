using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallInitializer : MonoBehaviour
{

    [SerializeField]
    LayerMask VaCham;

   
    public float moveSpeed;
    Vector3 m_dir;
    Rigidbody2D m_rigid2D;

    Vector3 a;
    Vector3 b;
    private void Start()
    {


 
       m_dir = new Vector3(0.5f, 0.5f).normalized;
        m_rigid2D = GetComponent<Rigidbody2D>();
       m_rigid2D.velocity = m_dir;
       // m_rigid2D = GetComponent<Rigidbody2D>();
       //  m_rigid2D.velocity = new Vector2(0.5f, 0.5f);
    }
    private void FixedUpdate()
    {
        RaycastHit2D hits = Physics2D.BoxCast(transform.position, new Vector2(0.01f, 0.01f), 0f, Vector2.down, 0f, VaCham);
        // RaycastHit2D hits = Physics2D.CircleCast(transform.position,0.1f, Vector2.down, 0f, VaCham);
        // RaycastHit2D hits = Physics2D.CircleCast(transform.position, 0.01f, Vector2.down, 0f, VaCham);


        //////////////if ( hits)
        //////////////{
        //////////////    a = hits.transform.position;
        //////////////    if (b != a)
        //////////////    {
        //////////////        b = a;

        //////////////        if (transform.position.y - hits.transform.position.y > transform.position.x - hits.transform.position.x && transform.position.y - hits.transform.position.y > hits.transform.position.x - transform.position.x
        //////////////            || transform.position.y - hits.transform.position.y < transform.position.x - hits.transform.position.x && transform.position.y - hits.transform.position.y < hits.transform.position.x - transform.position.x)
        //////////////        {
        //////////////            m_dir = new Vector2(m_dir.x, -m_dir.y);
        //////////////        }
        //////////////        if (transform.position.y - hits.transform.position.y > hits.transform.position.x - transform.position.x && transform.position.y - hits.transform.position.y < transform.position.x - hits.transform.position.x
        //////////////            || transform.position.y - hits.transform.position.y < hits.transform.position.x - transform.position.x && transform.position.y - hits.transform.position.y > transform.position.x - hits.transform.position.x)
        //////////////        {
        //////////////            m_dir = new Vector2(-m_dir.x, m_dir.y);
        //////////////        }
        //////////////    }
        //////////////  //  Debug.Log(hits.transform.localPosition);

        //////////////}


        if (hits)
        {
            Vector2 _wallnormal = hits.normal;
            m_dir = Vector2.Reflect(m_dir, _wallnormal).normalized;

            m_rigid2D.velocity = m_dir* 3;
        }
        //transform.Translate(m_dir * moveSpeed * Time.fixedDeltaTime);
    }






    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("DoiTuong"))
    //    {

    //        Vector2 _wallnormal = collision.contacts[0].normal; 
    //        m_dir = Vector2.Reflect(m_dir, _wallnormal).normalized;
    //        // m_rigid2D.velocity = m_dir * moveSpeed;
           
    //    }
    //}

}
