using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class spawner : MonoBehaviour
{
    // Start is called before the first frame update
    [System.Serializable]
    public class ShooterManager
    {
        public Image Box_shooter_img;
        public GameObject Box_shooter_obj;
        public int id;
    }
    public List<ShooterManager> _BoxManager;


    public Transform ParentPawnedTowers;
    int spawnID = -1;
    public Tilemap spawmTilemap;
    private void Update()
    {
        if(canSpawn())
        {
            DetectSpawnPoint();
        }
    }
    public void SelectTower(int id)// lay id tu click ben unity duoc gan voi image 
    {
        DeselectTower();
        spawnID = id;
        _BoxManager[spawnID].Box_shooter_img.color = Color.white;
    }
    public void DeselectTower()
    {
        spawnID = -1;
        foreach(var t in _BoxManager)
        {
            t.Box_shooter_img.color = new Color(0.5f, 0.5f, 0.5f);
        }
    }
    bool canSpawn() // check xem co duoc Instance gameobj 
    {
        if(spawnID == -1)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    void DetectSpawnPoint()
    {
        if(Input.GetMouseButtonDown(0))
        {
            var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // lay vi tri cua cell
            var CellPosDefault = spawmTilemap.WorldToCell(mousePos);
            // lay trong tam cua cell
            var CellPosCentered = spawmTilemap.GetCellCenterWorld(CellPosDefault);

            if (spawmTilemap.GetColliderType(CellPosDefault) == Tile.ColliderType.Sprite)// kiem tra xem cell co collider hay 0, neu co thi cho xuat hien tower
            {
                
                // tower xuat hien o tam cua cell   
                SpawnTower(CellPosCentered);
                Debug.Log(CellPosDefault);
                // tat collider cua cell xuat hien tower
                spawmTilemap.SetColliderType(CellPosDefault, Tile.ColliderType.None);
            }
          
            
        }
    }
    void SpawnTower(Vector3 CellPosCentered)
    {
        GameObject tower = Instantiate(_BoxManager[spawnID].Box_shooter_obj, CellPosCentered, Quaternion.identity,ParentPawnedTowers  );
        DeselectTower();
    }
}
