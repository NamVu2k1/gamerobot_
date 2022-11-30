using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class bulletparticle3 : MonoBehaviour
{
    // Start is called before the first frame update
    public static bulletparticle3 Instance;
    // Start is called before the first frame update
    public ParticleSystem system;
    public Transform playerPos;
    Tilemap spawmTilemap;
    TilemapCollider2D colmap;
    float scaletilemap_sizestart;
    int levelGunbullet;
   
    void Start()
    {
        levelGunbullet = DataPlayer.GetlevelGunbullet();
        Instance = this;
        var triggers = system.trigger;
        system = gameObject.GetComponent<ParticleSystem>();
        var tilemaps = FindObjectsOfType<Tilemap>();
        for (int i = 0; i < tilemaps.Length; i++)
        {
            if (tilemaps[i].name == "Tilemap")
            {
                spawmTilemap = tilemaps[i];
            }
        }
        if (spawmTilemap == null)
        {
            return;
        }
        colmap = spawmTilemap.GetComponent<TilemapCollider2D>();
        triggers.AddCollider(spawmTilemap);
        scaletilemap_sizestart = spawmTilemap.transform.localScale.x;
        var mainModule = system.main;
       
        mainModule.startSpeed = 35.2f * scaletilemap_sizestart;
        mainModule.startSize = scaletilemap_sizestart * 0.8f;
        

    }
    void DoEmit()
    {
        var shape_ = system.shape;
        shape_.position = new Vector3(playerPos.position.x, playerPos.position.y + 0.2f, 0);
        // Any parameters we assign in emitParams will override the current system's when we call Emit.
        // Here we will override the start color and size.
        var emitParams = new ParticleSystem.EmitParams();
        //emitParams.startColor = Color.red;
        system.Emit(emitParams,1);
        soundtriggeritem.Instance.OnPlaySound(SoundTypeItem.gun);

    }
     IEnumerator Ban()
    {
        int Dem = 0;
        while (Dem < levelGunbullet + 5)
        {
            DoEmit();
            yield return new WaitForSeconds(0.5f);          
            Dem++;
        }
    }
    // Update is called once per frame
    private void OnParticleTrigger()
    {
        

     
        List<ParticleSystem.Particle> inside = new List<ParticleSystem.Particle>();
        int numInside = system.GetTriggerParticles(ParticleSystemTriggerEventType.Inside, inside, out var insideData);
        for (int i = 0; i < numInside; i++)
        {
            ParticleSystem.Particle p = inside[i];
           
                if (insideData.GetCollider(i, 0) == system.trigger.GetCollider(0))
                {
                    var CellPosDefault = spawmTilemap.WorldToCell(p.position);
                    var CellPosCentered = spawmTilemap.GetCellCenterWorld(CellPosDefault);
            
                        //spawmTilemap.SetColliderType(CellPosDefault, Tile.ColliderType.None);
                        spawmTilemap.SetTile(CellPosDefault, null);
                        int ramdom = Random.Range(0, 700);
                        bulletparticle.Instance.RandomItem(ramdom, CellPosCentered);
                }
                  
        }
       
    }
    public void TriggerGun()
    {
        StartCoroutine(Ban());
     
    }
}
