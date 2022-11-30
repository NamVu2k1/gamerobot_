using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bulletHell : MonoBehaviour
{
    
    public Button x3;

    // Start is called before the first frame update
    public ParticleSystem system;
    ParticleSystem.Particle[] m_Particles ;
   

    ParticleSystem.Burst burst;
    public Material material;
    public LayerMask Vacham;

    


    private void Awake()
    {
       
        burst.count = 2;
       
 
 
    }
    private void Start()
    {
        // A simple particle material with no texture.
        Material particleMaterial = material;

        // Create a green Particle System.
        var go = new GameObject("Particle System"); 

        go.transform.Rotate(0, 0, 0); // Rotate so the system emits upwards.
        go.transform.parent = this.transform;
        go.transform.position = this.transform.position;
        system = go.AddComponent<ParticleSystem>();
        system.Stop();
        go.GetComponent<ParticleSystemRenderer>().material = particleMaterial;
        var mainModule = system.main;
        mainModule.duration = 200;
       // mainModule.startColor = Color.green;
        mainModule.startSize = 0.1f;
        mainModule.startLifetime = 200;
        mainModule.startSpeed = 3;
        mainModule.maxParticles = 4000;

        var emission = system.emission;
        emission.enabled = true;
        emission.rateOverTime = 0;
        emission.burstCount = 1;
        emission.SetBurst(0, burst);

        var forma = system.shape;
        forma.enabled = true;
        forma.shapeType = ParticleSystemShapeType.Circle;
       
        forma.arc = 90;
        forma.sprite = null;
        forma.radius = 0;
        forma.radiusThickness = 0;
        forma.arcMode = ParticleSystemShapeMultiModeValue.BurstSpread;
        var collision = system.collision;
        collision.enabled = true;
        collision.type = ParticleSystemCollisionType.World;
        collision.mode = ParticleSystemCollisionMode.Collision2D;
        collision.quality = ParticleSystemCollisionQuality.High;
        collision.collidesWith = Vacham;
        
        collision.maxCollisionShapes = 1000;
        collision.sendCollisionMessages = true;
        system.Play();
        x3.onClick.AddListener(delegate
        {
            InitializeIfNeeded(system);
            int num = system.GetParticles(m_Particles);
            for (int i = 0; i < num; i++)
            {
               // Debug.Log(m_Particles[i].position);
                DoEmit(m_Particles[i].position, m_Particles[i].velocity);

            }
        });
    }

    private void LateUpdate()
    {
       
    }
    void DoEmit(Vector3 vitri, Vector3 vantoc)
    {
        // Any parameters we assign in emitParams will override the current system's when we call Emit.
        // Here we will override the start color and size.
        var emitParams = new ParticleSystem.EmitParams();
        //emitParams.startColor = Color.red;
        emitParams.position = vitri;
        emitParams.velocity =new Vector3(-vantoc.y, vantoc.x, 0);      
        system.Emit(emitParams, 1);

        var emitParams1 = emitParams;
        emitParams1.velocity = new Vector3(vantoc.y, -vantoc.x, 0);
        system.Emit(emitParams1, 1);
      

    }

    void InitializeIfNeeded(ParticleSystem m_System)
    {
        if (m_System == null)
            m_System = GetComponent<ParticleSystem>();

        if (m_Particles == null || m_Particles.Length < m_System.main.maxParticles)
            m_Particles = new ParticleSystem.Particle[m_System.main.maxParticles];
    }
  
}
