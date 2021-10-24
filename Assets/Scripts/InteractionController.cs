using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionController : MonoBehaviour
{
    public Transform spawnParent;
    public GameObject prefab;
    private GameObject go;
    public Vector3 spawnPoint;

    public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        SpawnPrefab();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeColor()
    {
        print("Value of the bar : " + slider.value); ;
        Color newColor = new Color(slider.value / 255, 255, 255, 255);

        go.GetComponent<Renderer>().material.SetColor("_Color", newColor);
    }

    public void RespawnPrefab()
    {
        if (go)
            Destroy(go);
        SpawnPrefab();
    }

    private void SpawnPrefab()
    {
        go = Instantiate(prefab, spawnParent);
        go.transform.localPosition = spawnPoint;
        ChangeColor();
    }
}
