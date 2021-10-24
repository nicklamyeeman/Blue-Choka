using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JukeboxManager : MonoBehaviour
{
    AudioSource audioSource;

    bool isPlaying = false;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.time = Random.Range(0.0f, 3600.0f);
        audioSource.Play();
        isPlaying = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && isPlaying == true) {
            audioSource.Pause();
            isPlaying = false;
        }
        else if (Input.GetKeyDown(KeyCode.Return) && isPlaying == false) {
            audioSource.Play();
            isPlaying = true;
        }
    }
}
