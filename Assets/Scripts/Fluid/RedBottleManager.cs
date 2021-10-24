using System.Collections;
using System.Collections.Generic;
using Obi;
using UnityEngine;

public class RedBottleManager : MonoBehaviour
{
    public float speed = 0.15f;
    [SerializeField] private Transform parent;
    public ObiEmitter emitter;

    // Start is called before the first frame update
    void Start()
    {
        parent = transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        if (emitter != null)
        {
            // Debug.Log("Bottle rotation x: " + transform.localEulerAngles.x + " | rotation z: " + transform.localEulerAngles.z);

            if ((parent.localEulerAngles.x > 90 && parent.localEulerAngles.x < 270) || (parent.localEulerAngles.z > 90 && parent.localEulerAngles.z < 270))
            {
                // Debug.Log("Pouring liquid");
                emitter.speed = speed;
            }
            else
            {
                emitter.speed = 0;
            }
        }
    }
}
