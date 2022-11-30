using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shaderPrefab : MonoBehaviour
{
    private Material dissolve;
    float fade = 0;
    void Start()
    {
        dissolve = GetComponent<SpriteRenderer>().material;

        // dissolve.SetColor("_Color", new Color(Random.Range(0,10), Random.Range(0, 10), Random.Range(0, 10), 20));


    }

    // Update is called once per frame
    void Update()
    {
        if (fade <= 1)
        {
            fade += Time.deltaTime / 3f;
            dissolve.SetFloat("_Fade", fade);

        }


    }

}
