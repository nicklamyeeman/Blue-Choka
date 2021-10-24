using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotManagement : MonoBehaviour
{
    public List<GameObject> spots;
    public List<GameObject> orderSpots;
    public NPCManagement NPCManagement;

    void Awake()
    {
        Random.InitState(Random.Range(0, 99999));
        AssignSpots();
    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void AssignSpots()
    {
        // List<GameObject> NPCtmp = new List<GameObject>(NPCManagement.npc);
        List<GameObject> Spotstmp = new List<GameObject>(spots);
        int size = spots.Count;

        for (int i = 0; i < spots.Count; i++) {
            if (i == NPCManagement.npc.Count)
                break;
            int number = Random.Range(0, size);
            NPCManagement.npc[i].GetComponent<NPCMovement>().destination = Spotstmp[number];

            // NPCtmp.RemoveAt(number1);
            Spotstmp.RemoveAt(number);
            size--;
            // Debug.Log("Spots: " + number);
        }
    }

    public void MakeOrder()
    {
        int npcNb = Random.Range(0, NPCManagement.npc.Count);
        for (int i = 0; i < orderSpots.Count; i++) {
            SpotBehavior spotBehavior = orderSpots[i].GetComponent<SpotBehavior>();
            if (spotBehavior.isTaken == false) {
                // Debug.Log("Process Order");
                NPCMovement npc = NPCManagement.npc[npcNb].GetComponent<NPCMovement>();
                npc.destination.GetComponent<SpotBehavior>().isTaken = false;
                npc.destination = orderSpots[i];
                npc.HeadForDestintation();
                return;
            }
        }

    }

    public void SwitchSpotRandom()
    {
        int npcNb = Random.Range(0, NPCManagement.npc.Count);

        for (int i = 0; i < spots.Count; i++) {
            SpotBehavior spotBehavior = spots[i].GetComponent<SpotBehavior>();
            if (spotBehavior.isTaken == false && spotBehavior.group != NPCManagement.npc[npcNb].GetComponent<NPCMovement>().destination.GetComponent<SpotBehavior>().group &&
                NPCManagement.npc[npcNb].GetComponent<NPCMovement>().destination.GetComponent<SpotBehavior>().isForOrder == false) {
                NPCMovement npc = NPCManagement.npc[npcNb].GetComponent<NPCMovement>();
                npc.destination.GetComponent<SpotBehavior>().isTaken = false;
                npc.destination = spots[i];
                npc.HeadForDestintation();
                return;
            }
        }
    }

    public void SwitchSpot(GameObject npc)
    {
        for (int i = 0; i < spots.Count; i++) {
            SpotBehavior spotBehavior = spots[i].GetComponent<SpotBehavior>();
            if (spotBehavior.isTaken == false) {
                NPCMovement npcMovement = npc.GetComponent<NPCMovement>();
                npcMovement.destination.GetComponent<SpotBehavior>().isTaken = false;
                npcMovement.destination = spots[i];
                npcMovement.HeadForDestintation();
                return;
            }
        }
    }
}
