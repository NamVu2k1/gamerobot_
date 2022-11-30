using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private int _width, _height;
    [SerializeField] private GameObject _TilePrefab;
    public Material Dissolve;
    //[SerializeField] private Camera cam;
    public Transform parent;
    private void Awake()
    {
        Dissolve.SetFloat("_Fade", 0);
    }
    void Start()
    {
        GenerateGrid();
    }

    // Update is called once per frame
   void GenerateGrid()
    {
        for(float x = 0; x < _width; x++)
        {
            for(float y=0; y < _height; y++)
            {
                var spawnedTile = Instantiate(_TilePrefab, new Vector3(x/2-1.5f, y/2), Quaternion.identity,parent);
                spawnedTile.name = $"Tile {x} {y} ";
            }
        }
       // cam.transform.position = new Vector3((float)_width/2 - 0.5f,(float)_height/2 -0.5f);
    }
}
