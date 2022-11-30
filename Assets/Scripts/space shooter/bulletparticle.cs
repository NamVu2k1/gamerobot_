using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;

public class bulletparticle : MonoBehaviour
{
    // Start is called before the first frame update
    public static bulletparticle Instance;

    [SerializeField]
    private GameObject wallbot_obj;
    public Transform playerPos;
    public GameObject UiWin;
    

    
    ParticleSystem.Particle[] m_Particles;
    List<ParticleCollisionEvent> colEvents = new List<ParticleCollisionEvent>();
     ParticleSystem system;
    public ParticleSystem bulletparticle2;
    Tilemap spawmTilemap;
    TilemapCollider2D colmap;


    float time_ = 0;
    bool Winmap = false;
    bool OnGetParticle = false;
    float scaletilemap_sizestart;
    bool losing = true;
    float startspeed;
    void Start()
    {
        
        Instance = this;
        system = gameObject.GetComponent<ParticleSystem>();
        var tilemaps = FindObjectsOfType<Tilemap>();
        for(int i=0; i < tilemaps.Length; i++)
        {
            if(tilemaps[i].name == "Tilemap")
            {
                spawmTilemap = tilemaps[i];
            }
        }
        if(spawmTilemap == null)
        {
            return;
        }
        scaletilemap_sizestart = spawmTilemap.transform.localScale.x;

        colmap = spawmTilemap.GetComponent<TilemapCollider2D> ();
        var mainModule = system.main;
        mainModule.startLifetime = 200f;
        startspeed = 35.2f * scaletilemap_sizestart;
        mainModule.startSpeed = startspeed;
        mainModule.startSize = scaletilemap_sizestart*0.8f;



        //ainModule.duration = DataPlayer.GetATKSpeed();



       
        //system.Play();



    }
    private void Update()
    {
        // dieu kien thua
        if(OnGetParticle == true)
        {
            if (system.IsAlive() == false && bulletparticle2.IsAlive() == false)
            {
                Losing();

            }
        }

        
        if (colmap.shapeCount == 0 && Winmap == false)
        {
            Winmap = true;
            UiWin.SetActive(true);

            OnGetParticle = false;
        }
    }
    void  Losing()
    {
        if(losing == true)
        {
            losing = false;
            int inLevel = DataPlayer.GetLevelPlaying();
            sound.Instance.OnPlaySound(SoundType.lose);
            SceneManager.LoadScene("Scenes/maps/main");
            SceneManager.LoadScene($"Scenes/maps/map{inLevel}", LoadSceneMode.Additive);
        
        }
        
    }
    // bat dau game se ban ra 1 qua bong
    public void DoEmitPlay()
    {
        var shape_ = system.shape;
        shape_.position = new Vector3(playerPos.position.x, playerPos.position.y + 0.2f, 0);
        var emitParams = new ParticleSystem.EmitParams();
        emitParams.velocity = new Vector3(0, startspeed, 0);
        system.Emit(emitParams, 1);
        OnGetParticle = true;
    }
    void DoEmit(Vector3 vitri, Vector3 vantoc)
    {
        // Any parameters we assign in emitParams will override the current system's when we call Emit.
        // Here we will override the start color and size.
        var emitParams = new ParticleSystem.EmitParams();
        // tinh goc
        Vector3 normal = (vantoc + new Vector3(-vantoc.y, vantoc.x, 0)).normalized * startspeed;
        Vector3 normal2 = (vantoc + new Vector3(vantoc.y, -vantoc.x, 0)).normalized * startspeed;


        emitParams.velocity = normal;
        emitParams.position = vitri;
        system.Emit(emitParams, 1);
        var emitParams1 = emitParams;
        emitParams1.velocity = normal2;
        system.Emit(emitParams1, 1);

    }
    void DoEmit2()
    {
        // Any parameters we assign in emitParams will override the current system's when we call Emit.
        // Here we will override the start color and size.
        var shape_ = system.shape;
        shape_.position = new Vector3(playerPos.position.x, playerPos.position.y + 0.2f, 0);
        var emitParams = new ParticleSystem.EmitParams();
        //emitParams.startColor = Color.red;

       

        system.Emit(emitParams, 3);

        


    }

    void InitializeIfNeeded(ParticleSystem m_System)
    {
        if (m_System == null)
            m_System = GetComponent<ParticleSystem>();

        if (m_Particles == null || m_Particles.Length < m_System.main.maxParticles)
            m_Particles = new ParticleSystem.Particle[m_System.main.maxParticles];
    }


    
    
    public void RandomItem(int ramdom, Vector3 Pos)
    {
        if(Time.timeSinceLevelLoad  - time_ > 6f )
        {
            time_ = Time.timeSinceLevelLoad;
            if (ramdom <= 400 && ramdom >200)
            {
                spawn.Instance.SpawmPool1("x3", Pos, transform.rotation);
            }
            if (ramdom > 400 && ramdom<= 600)
            {
                spawn.Instance.SpawmPool1("+3", Pos, transform.rotation);
            }
            if(ramdom >100 && ramdom <= 200)
            {
                spawn.Instance.SpawmPool1("wallbotitem", Pos, transform.rotation);
            }
            if(ramdom <= 100)
            {
                spawn.Instance.SpawmPool1("redpong", Pos, transform.rotation);  
            }
            if(ramdom > 600)
            {
                spawn.Instance.SpawmPool1("gun", Pos, transform.rotation);
            }
        }
        else
        {
            if (ramdom <=1)
            {
                spawn.Instance.SpawmPool1("x3", Pos, transform.rotation);

            }
            if (ramdom  > 1 && ramdom <= 3 )
            {
                spawn.Instance.SpawmPool1("+3", Pos, transform.rotation);
            }
            if(ramdom == 4)
            {
                spawn.Instance.SpawmPool1("wallbotitem", Pos,transform.rotation);
            }
            if(ramdom == 5  )
            {
                spawn.Instance.SpawmPool1("redpong", Pos, transform.rotation);
            }
            if(ramdom == 6 )
            {
                spawn.Instance.SpawmPool1("gun", Pos, transform.rotation);
            }
        }
       
    }
    public void Triggerx3()
    {

        InitializeIfNeeded(system);
        int num = system.GetParticles(m_Particles);
        for (int i = 0; i < num; i++)
        {

            DoEmit(m_Particles[i].position, m_Particles[i].velocity);

        }
    }
    public void Triggeradd3()
    {
        DoEmit2();
    }

    public void wallbot_on()
    {
        if (wallbot_obj.activeSelf == false)
        {
            wallbot_obj.SetActive(true);
        }
        else
        {
            wallbot.Instance.timeUpdate();
        }
        
    }
    //SỬ LÍ LOGIC CHO TILE BẰNG 2 TRƯỜNG HỢP
    private void OnParticleTrigger()
    {

        List<ParticleSystem.Particle> enter = new List<ParticleSystem.Particle>();
      
        //List<ParticleSystem.Particle> exit = new List<ParticleSystem.Particle>();
        int numEnter = system.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter,out var EnterData);
        //int numInside = system.GetTriggerParticles(ParticleSystemTriggerEventType.Inside,inside, out var insideData);
        //for (int i = 0; i < numInside; i++)
        //{
        //    ParticleSystem.Particle p = inside[i];
        //    if (insideData.GetColliderCount(i) == 1)
        //    {
        //        if (insideData.GetCollider(i, 0) == system.trigger.GetCollider(0))
        //        { }
        //        else
        //        {
        //            p.startLifetime = 0;
        //        }
                   
        //    }
        //    else if (insideData.GetColliderCount(i) == 2)
        //    {
        //        //p.startLifetime =  0;
        //    }
        //    inside[i] = p;
        //}
        for (int i = 0; i < numEnter; i++)
        {
           
            ParticleSystem.Particle p = enter[i];
            if (EnterData.GetColliderCount(i) == 1)
            {
                if (EnterData.GetCollider(i, 0) == system.trigger.GetCollider(0))
                {
                    sound.Instance.OnPlaySound(SoundType.pong);
                    var Vec = (enter[i].position - new Vector3(playerPos.transform.position.x, playerPos.transform.position.y - 0.2f, 0f)).normalized * startspeed;
                    p.velocity = Vec;
                    
                }
                else
                {
                    p.startLifetime = 0;
                }

                enter[i] = p;
            }
        }
        //for (int i = 0; i < numExit; i++)
        //{
        //    ParticleSystem.Particle p = exit[i];
        //    var Vec = (enter[i].position - new Vector3(playerPos.transform.position.x, playerPos.transform.position.y - 0.2f, 0f)).normalized * 3;
        //    p.velocity = Vec;
        //    exit[i] = p;
        //}
        //system.SetTriggerParticles(ParticleSystemTriggerEventType.Inside, inside);
        system.SetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);
        
        //system.SetTriggerParticles(ParticleSystemTriggerEventType.Exit, exit);
    }


    void OnParticleCollision(GameObject other)// SU LI LOGIC CHO TILE 
    {
        //sử lý va chạm với player


        sound.Instance.OnPlaySound(SoundType.pong);
        //su ly va cham voi tilemapcollider
        if (other.name == "Tilemap")
        {
          
            int envent = system.GetCollisionEvents(other, colEvents);
            // colEvents chứa giữ liệu va chạm của các particle với tile collider trong từng frame 
            for (int en = 0; en < envent; en++)
            {
                int ramdom = Random.Range(0, 700);
                bool truonghop2 = false;
                // lay vi tri cua cell
                var intersection = colEvents[en].intersection;
                var CellPosDefault = spawmTilemap.WorldToCell(intersection);
                
                // lay trong tam cua cell
                var CellPosCentered = spawmTilemap.GetCellCenterWorld(CellPosDefault);

                // xac dinh 4 diem
                Vector3[] diem = new Vector3[4];
                diem[0] = spawmTilemap.GetCellCenterWorld(spawmTilemap.WorldToCell(new Vector3(CellPosCentered.x + scaletilemap_sizestart, CellPosCentered.y, 0))); float d1 = Vector3.Distance(diem[0], intersection);
                diem[1] = spawmTilemap.GetCellCenterWorld(spawmTilemap.WorldToCell(new Vector3(CellPosCentered.x - scaletilemap_sizestart, CellPosCentered.y, 0))); float d2 = Vector3.Distance(diem[1], intersection);
                diem[2] = spawmTilemap.GetCellCenterWorld(spawmTilemap.WorldToCell(new Vector3(CellPosCentered.x, CellPosCentered.y + scaletilemap_sizestart, 0))); float d3 = Vector3.Distance(diem[2], intersection);
                diem[3] = spawmTilemap.GetCellCenterWorld(spawmTilemap.WorldToCell(new Vector3(CellPosCentered.x, CellPosCentered.y - scaletilemap_sizestart, 0))); float d4 = Vector3.Distance(diem[3], intersection);
                float[] Distance = new float[4] { d1, d2, d3, d4 };
                float[] DistanceFake = Distance;

                for (int i = 0; i < 4; i++)
                {
                    for (int j = i + 1; j < 4; j++)
                    {
                        if (DistanceFake[i] > DistanceFake[j])
                        {
                            float a = DistanceFake[i];
                            DistanceFake[i] = DistanceFake[j];
                            DistanceFake[j] = a;
                            Vector3 vec = diem[i];
                            diem[i] = diem[j];
                            diem[j] = vec;
                        }
                    }
                }
                if (spawmTilemap.GetColliderType(spawmTilemap.WorldToCell(diem[0])) == Tile.ColliderType.Sprite)
                {
                    //spawmTilemap.SetColliderType(spawmTilemap.WorldToCell(diem[0]), Tile.ColliderType.None);
                    spawmTilemap.SetTile(spawmTilemap.WorldToCell(diem[0]), null);
                    RandomItem(ramdom, diem[0]);
                }
                else
                {
                    if (spawmTilemap.GetColliderType(spawmTilemap.WorldToCell(diem[1])) == Tile.ColliderType.Sprite)
                    {
                        //spawmTilemap.SetColliderType(spawmTilemap.WorldToCell(diem[1]), Tile.ColliderType.None);
                        spawmTilemap.SetTile(spawmTilemap.WorldToCell(diem[1]), null);
                        RandomItem(ramdom, diem[1]);
                    }
                    else
                    {
                        truonghop2 = true;
                    }

                }
                // TRƯỜNG HỢP 2
                if (truonghop2 == true)
                {
                    Vector3[] diemth2 = new Vector3[4];
                    diemth2[0] = spawmTilemap.GetCellCenterWorld(spawmTilemap.WorldToCell(new Vector3(CellPosCentered.x + scaletilemap_sizestart, CellPosCentered.y + scaletilemap_sizestart, 0))); float d1th2 = Vector3.Distance(diemth2[0], intersection);
                    diemth2[1] = spawmTilemap.GetCellCenterWorld(spawmTilemap.WorldToCell(new Vector3(CellPosCentered.x + scaletilemap_sizestart, CellPosCentered.y - scaletilemap_sizestart, 0))); float d2th2 = Vector3.Distance(diemth2[1], intersection);
                    diemth2[2] = spawmTilemap.GetCellCenterWorld(spawmTilemap.WorldToCell(new Vector3(CellPosCentered.x - scaletilemap_sizestart, CellPosCentered.y + scaletilemap_sizestart, 0))); float d3th2 = Vector3.Distance(diemth2[2], intersection);
                    diemth2[3] = spawmTilemap.GetCellCenterWorld(spawmTilemap.WorldToCell(new Vector3(CellPosCentered.x - scaletilemap_sizestart, CellPosCentered.y - scaletilemap_sizestart, 0))); float d4th2 = Vector3.Distance(diemth2[3], intersection);
                    float[] Distanceth2 = new float[4] { d1th2, d2th2, d3th2, d4th2 };
                    float[] DistanceFaketh2 = Distanceth2;
                    for (int i = 0; i < 4; i++)
                    {
                        for (int j = i + 1; j < 4; j++)
                        {
                            if (DistanceFaketh2[i] > DistanceFaketh2[j])
                            {

                                float a = DistanceFaketh2[i];
                                DistanceFaketh2[i] = DistanceFaketh2[j];
                                DistanceFaketh2[j] = a;
                                Vector3 vec = diemth2[i];
                                diemth2[i] = diemth2[j];
                                diemth2[j] = vec;
                            }
                        }
                    }
                    if (spawmTilemap.GetColliderType(spawmTilemap.WorldToCell(diemth2[0])) == Tile.ColliderType.Sprite)
                    {
                       // spawmTilemap.SetColliderType(spawmTilemap.WorldToCell(diemth2[0]), Tile.ColliderType.None);
                        spawmTilemap.SetTile(spawmTilemap.WorldToCell(diemth2[0]), null);
                        RandomItem(ramdom, diemth2[0]);

                    }
                }
            }

        }

    }

}
