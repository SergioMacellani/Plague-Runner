using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicTime : MonoBehaviour
{
    public AudioClip music; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(this.GetComponent<playerTile>().startRun == true)
        {
            this.GetComponent<AudioSource>().clip = music;
            if(Time.timeScale == 1)
            {
                this.GetComponent<AudioSource>().pitch = 1;
                this.GetComponent<AudioSource>().volume = .7f;
            }
            else
            {
                this.GetComponent<AudioSource>().pitch = 0.8f;
                this.GetComponent<AudioSource>().volume = .45f;
            }
            if (!this.GetComponent<AudioSource>().isPlaying)
            {
                this.GetComponent<AudioSource>().Play();
            }
        }
    }
}
