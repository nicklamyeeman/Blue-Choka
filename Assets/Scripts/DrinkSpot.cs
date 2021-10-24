using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkSpot : MonoBehaviour
{
    public GameObject drink;
    public bool isReady = false;
    private Vector3 npcTransform = Vector3.zero;
    public bool isActive = false;

    private void OnTriggerStay(Collider other)
    {
        if (isActive == true) {
            other.transform.parent.transform.position = Vector3.MoveTowards(other.transform.parent.transform.position, npcTransform, 2f * Time.deltaTime);
            if (other.transform.parent.transform.position == npcTransform) {
                isActive = false;
                npcTransform = Vector3.zero;
                Destroy(drink);
            }
        }
    }

    public void ActivateDrinkSpot(Transform newTransform)
    {
        isActive = true;
        npcTransform = new Vector3(newTransform.position.x, gameObject.transform.position.y, newTransform.position.z);
    }

    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.B)) {
            drink = Instantiate(drink, transform.position, transform.rotation);
        }
    }
}
