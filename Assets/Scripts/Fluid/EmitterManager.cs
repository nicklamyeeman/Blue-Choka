using System.Collections;
using System.Collections.Generic;
using Obi;
using UnityEngine;

public class EmitterManager : MonoBehaviour
{
    int particleIndex = 0;

    ObiActor actor;
    ObiEmitter emitter;
    ObiEmitterShape disk;

    // Start is called before the first frame update
    void Start()
    {
        actor = GetComponent<ObiActor>();
        emitter = GetComponent<ObiEmitter>();
        disk = GetComponent<ObiEmitterShapeDisk>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            emitter.KillAll();
            actor.DeactivateParticle(0);
        } else if (Input.GetKeyDown(KeyCode.Z))
        {
            disk.enabled = !disk.enabled;
            actor.ActivateParticle(0);
        }

        for (int i = 0; i < actor.activeParticleCount; i += 1)
        {
        }

        //Debug.Log("Is particles active: " + actor.IsParticleActive(0));
        //Debug.Log("Indice: " + actor.particle);
        //Debug.Log("Solver indices: " + actor.activeParticleCount);
    }
}
