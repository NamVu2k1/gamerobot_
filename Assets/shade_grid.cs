using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class shader_gird : MonoBehaviour
{
    // Start is called before the first frame update
    bool _setActive;
    private Material dissolve;
    float fade = 0;
    void Start()
    {
        dissolve = GetComponent<TilemapRenderer>().material;

        // dissolve.SetColor("_Color", new Color(Random.Range(0,10), Random.Range(0, 10), Random.Range(0, 10), 20));


    }

    // Update is called once per frame
    void Update()
    {
        if (fade <= 1 && _setActive)
        {
            fade += Time.deltaTime / 3f;
            dissolve.SetFloat("_Fade", fade);

        }
        else if (fade >= 0 && _setActive == false)
        {
            fade -= Time.deltaTime / 3f;
            dissolve.SetFloat("_Fade", fade);

        }

    }
    public void Shader_fade(bool setActive)
    {
        _setActive = setActive;
    }
}
