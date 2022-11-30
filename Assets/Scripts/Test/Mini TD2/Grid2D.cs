using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid2D : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int _width, _height;
    [SerializeField] GameObject _TilePrefab;
    public Transform _parent;

    void Start()
    {
        Grid2d();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Grid2d()
    {
        for(float x = 0; x < _width; x++)
        {
            for(float y = 0; y < _height; y++)
            {
                var spawnedTile = Instantiate(_TilePrefab, new Vector3(x - 5f, y - 4f,8 ), Quaternion.identity, _parent);
                spawnedTile.name = $"Tile {x} {y} ";
            }
        }
    }
}
