using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class bulletparticle2 : MonoBehaviour
{
    public static bulletparticle2 Instance;
    // Start is called before the first frame update
    public ParticleSystem system;
    public Transform playerPos;
    Tilemap spawmTilemap;
    TilemapCollider2D colmap;
    float scaletilemap_sizestart;
    int levelItemRedpong;
    float startspeed;
    void Start()
    {
        levelItemRedpong = DataPlayer.GetlevelRedpong() ; 
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
        if(spawmTilemap == null)
        {
            return;
        }
        colmap = spawmTilemap.GetComponent<TilemapCollider2D>();
        triggers.AddCollider(spawmTilemap);
        scaletilemap_sizestart = spawmTilemap.transform.localScale.x;
        var mainModule = system.main;
        mainModule.startLifetime = 200f;
        startspeed = 35.2f * scaletilemap_sizestart;
        mainModule.startSpeed = startspeed;
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
        system.Emit(emitParams, 3 + levelItemRedpong);
    }
    // Update is called once per frame
    private void OnParticleTrigger()
    {
        List<ParticleSystem.Particle> enter = new List<ParticleSystem.Particle>();
        List<ParticleSystem.Particle> inside = new List<ParticleSystem.Particle>();
        //List<ParticleSystem.Particle> exit = new List<ParticleSystem.Particle>();
        int numEnter = system.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter,out var EnterData);
        int numInside = system.GetTriggerParticles(ParticleSystemTriggerEventType.Inside, inside, out var insideData);
        for (int i = 0; i < numInside; i++)
        {
            ParticleSystem.Particle p = inside[i];  
            if(insideData.GetCollider(i, 0) == system.trigger.GetCollider(2))
            {
                    
                var CellPosDefault = spawmTilemap.WorldToCell(p.position);
                if (spawmTilemap.GetColliderType(CellPosDefault) == Tile.ColliderType.Sprite)
                {
                    var CellPosCentered = spawmTilemap.GetCellCenterWorld(CellPosDefault);
                    // spawmTilemap.SetColliderType(CellPosDefault, Tile.ColliderType.None);
                    spawmTilemap.SetTile(CellPosDefault, null);
                    int ramdom = Random.Range(0, 700);
                    bulletparticle.Instance.RandomItem(ramdom, CellPosCentered);
                }
                   
            }   
        }
        for (int i = 0; i < numEnter; i++)
        {
            ParticleSystem.Particle p = enter[i];
            if (EnterData.GetCollider(i, 0) == system.trigger.GetCollider(0))
            {

                p.startLifetime = 0;
            }
            else if(EnterData.GetCollider(i, 0) == system.trigger.GetCollider(1))
            {
                var Vec = (enter[i].position - new Vector3(playerPos.transform.position.x, playerPos.transform.position.y - 0.2f, 0f)).normalized * startspeed;
                p.velocity = Vec;
                    
            }
            enter[i] = p;
        }
    
        system.SetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);
    }
    public void TriggerRedPong()
    {
        DoEmit();
    }
  
}
