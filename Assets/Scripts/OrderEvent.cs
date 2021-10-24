using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OrderEvent : MonoBehaviour
{
    public GameObject Bubble;
    public TMP_Text BubbleText;

    private float timeActive = 7.0f;
    private float timeInactive = 15.0f;

    private bool isActive = false;

    private string[] orders = { "Can I have a beer please?" };
    private NPCMovement NPCMovement;
    public SpotBehavior spot;

    void Start()
    {
        ManageBubble(false);
        NPCMovement = GetComponent<NPCMovement>();
        spot = NPCMovement.destination.GetComponent<SpotBehavior>();
    }

    private void SetUpSpot()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive == true) {
            if (timeActive > 0)
                timeActive -= Time.deltaTime;
            else {
                timeActive = 7.0f;
                // timeInactive = 15.0f;
                ManageBubble(false);
                isActive = !isActive;
            }
        }

        if (spot && spot.isForOrder == true && spot.drinkSpot.isActive == false) {
            spot = null;
            GameObject.Find("NPC").GetComponent<NPCManagement>().FindFreeSpot(gameObject);
        }
    }

    public void TriggerText()
    {
        // ChooseText(Random.Range(0, 3));
        ChooseText(0);
        ManageBubble(true);
        isActive = true;
        spot = NPCMovement.destination.GetComponent<SpotBehavior>();
        spot.drinkSpot.ActivateDrinkSpot(gameObject.transform);
    }

    void ManageBubble(bool boolean)
    {
        Bubble.SetActive(boolean);
        BubbleText.enabled = boolean;
    }

    void ChooseText(int order)
    {
        BubbleText.text = orders[order];
    }
}
