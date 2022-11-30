using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class testtile : MonoBehaviour
{
    // Start is called before the first frame update
    //List<ParticleCollisionEvent> colEvents = new List<ParticleCollisionEvent>();
    //public ParticleSystem system;


  
    //public Tilemap spawmTilemap;

    void Start()
    {
      
    }
    //void OnParticleCollision(GameObject other)// SU LI LOGIC CHO TILE 
    //{
        
    //    int envent = system.GetCollisionEvents(other, colEvents);
    //    Debug.Log(colEvents[0].intersection);
    //    bool truonghop2 = false;
    //    // lay vi tri cua cell
    //    var CellPosDefault = spawmTilemap.WorldToCell(colEvents[0].intersection);
    //    // lay trong tam cua cell
    //    var CellPosCentered = spawmTilemap.GetCellCenterWorld(CellPosDefault);

    //    // xac dinh 4 diem
    //    Vector3[] diem = new Vector3[4];
    //    diem[0] = spawmTilemap.GetCellCenterWorld(spawmTilemap.WorldToCell(new Vector3(CellPosCentered.x + 0.1f, CellPosCentered.y, 0))); float d1 = Vector3.Distance(diem[0], colEvents[0].intersection);
    //    diem[1] = spawmTilemap.GetCellCenterWorld(spawmTilemap.WorldToCell(new Vector3(CellPosCentered.x - 0.1f, CellPosCentered.y, 0))); float d2 = Vector3.Distance(diem[1], colEvents[0].intersection);
    //    diem[2] = spawmTilemap.GetCellCenterWorld(spawmTilemap.WorldToCell(new Vector3(CellPosCentered.x, CellPosCentered.y + 0.1f, 0))); float d3 = Vector3.Distance(diem[2], colEvents[0].intersection);
    //    diem[3] = spawmTilemap.GetCellCenterWorld(spawmTilemap.WorldToCell(new Vector3(CellPosCentered.x, CellPosCentered.y - 0.1f, 0))); float d4 = Vector3.Distance(diem[3], colEvents[0].intersection);
    //    float[] Distance = new float[4] { d1, d2, d3, d4 };
    //    float[] DistanceFake = Distance;

    //    for (int i = 0; i < 4; i++)
    //    {
    //        for (int j = i + 1; j < 4; j++)
    //        {
    //            if (DistanceFake[i] > DistanceFake[j])
    //            {
    //                float a = DistanceFake[i];
    //                DistanceFake[i] = DistanceFake[j];
    //                DistanceFake[j] = a;
    //                Vector3 vec = diem[i];
    //                diem[i] = diem[j];
    //                diem[j] = vec;
    //            }
    //        }
    //    }
    //    if (spawmTilemap.GetColliderType(spawmTilemap.WorldToCell(diem[0])) == Tile.ColliderType.Sprite)
    //    {
    //        spawmTilemap.SetColliderType(spawmTilemap.WorldToCell(diem[0]), Tile.ColliderType.None);
    //        spawmTilemap.SetTile(spawmTilemap.WorldToCell(diem[0]), null);
    //    }
    //    else
    //    {
    //        if (spawmTilemap.GetColliderType(spawmTilemap.WorldToCell(diem[1])) == Tile.ColliderType.Sprite)
    //        {
    //            spawmTilemap.SetColliderType(spawmTilemap.WorldToCell(diem[1]), Tile.ColliderType.None);
    //            spawmTilemap.SetTile(spawmTilemap.WorldToCell(diem[1]), null);
    //        }
    //        else
    //        {
    //            truonghop2 = true;
    //        }

    //    }
    //    // TRƯỜNG HỢP 2
    //    if (truonghop2 == true)
    //    {
    //        Vector3[] diemth2 = new Vector3[4];
    //        diemth2[0] = spawmTilemap.GetCellCenterWorld(spawmTilemap.WorldToCell(new Vector3(CellPosCentered.x + 0.1f, CellPosCentered.y + 0.1f, 0))); float d1th2 = Vector3.Distance(diemth2[0], colEvents[0].intersection);
    //        diemth2[1] = spawmTilemap.GetCellCenterWorld(spawmTilemap.WorldToCell(new Vector3(CellPosCentered.x + 0.1f, CellPosCentered.y - 0.1f, 0))); float d2th2 = Vector3.Distance(diemth2[1], colEvents[0].intersection);
    //        diemth2[2] = spawmTilemap.GetCellCenterWorld(spawmTilemap.WorldToCell(new Vector3(CellPosCentered.x - 0.1f, CellPosCentered.y + 0.1f, 0))); float d3th2 = Vector3.Distance(diemth2[2], colEvents[0].intersection);
    //        diemth2[3] = spawmTilemap.GetCellCenterWorld(spawmTilemap.WorldToCell(new Vector3(CellPosCentered.x - 0.1f, CellPosCentered.y - 0.1f, 0))); float d4th2 = Vector3.Distance(diemth2[3], colEvents[0].intersection);
    //        float[] Distanceth2 = new float[4] { d1th2, d2th2, d3th2, d4th2 };
    //        float[] DistanceFaketh2 = Distanceth2;
    //        for (int i = 0; i < 4; i++)
    //        {
    //            for (int j = i + 1; j < 4; j++)
    //            {
    //                if (DistanceFaketh2[i] > DistanceFaketh2[j])
    //                {

    //                    float a = DistanceFaketh2[i];
    //                    DistanceFaketh2[i] = DistanceFaketh2[j];
    //                    DistanceFaketh2[j] = a;
    //                    Vector3 vec = diemth2[i];
    //                    diemth2[i] = diemth2[j];
    //                    diemth2[j] = vec;
    //                }
    //            }
    //        }
    //        if (spawmTilemap.GetColliderType(spawmTilemap.WorldToCell(diemth2[0])) == Tile.ColliderType.Sprite)
    //        {
    //            spawmTilemap.SetColliderType(spawmTilemap.WorldToCell(diemth2[0]), Tile.ColliderType.None);
    //            spawmTilemap.SetTile(spawmTilemap.WorldToCell(diemth2[0]), null);
    //        }
    //    }

    //}
}
