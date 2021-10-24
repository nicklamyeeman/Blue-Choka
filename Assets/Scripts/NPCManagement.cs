using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManagement : MonoBehaviour
{
    public List<GameObject> npc;
    public SpotManagement spotManagement;
    float timer;

    void Awake()
    {
        Random.InitState(Random.Range(0, 99999));
        timer = Random.Range(12, 15);
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ChangeSpot", 20f, 20f);
        InvokeRepeating("MakeTalking", 6f, 8f);
    }

    void Update()
    {
        if (timer > 0) {
            timer -= Time.deltaTime;
        } else {
            MakeOrder();
            timer = Random.Range(15, 20);
            // Debug.Log("Timer: " + timer);
        }
    }

    void MakeOrder()
    {
        print("MAKE ORDER");
        spotManagement.MakeOrder();
    }

    void ChangeSpot()
    {
        print("CHANGE SPOT");
        spotManagement.SwitchSpotRandom();
    }

    public void FindFreeSpot(GameObject npc)
    {
        spotManagement.SwitchSpot(npc);
    }

    void MakeTalking()
    {
        foreach (GameObject entity in npc) {
            NPCMovement move = entity.GetComponent<NPCMovement>();
            if (move.GetComponent<NPCBehavior>().IsTalking == true) {
                NPCAnimation anim = entity.GetComponent<NPCAnimation>();
                int issou = Random.Range(0, 2);
                if (issou == 0)
                    anim.SetTalking1();
                else if (issou == 1) {
                    anim.SetTalking2();
                }
            }
        }
    }
}
