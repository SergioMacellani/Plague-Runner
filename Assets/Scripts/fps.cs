using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fps : MonoBehaviour
{
    public int frames;
    float deltatime;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        deltatime = 1 / Time.smoothDeltaTime;
        frames = (int)deltatime;

        if (PlayerPrefs.GetInt("fps") == 1)
        {
            if (Time.timeScale == 1)
            {
                this.GetComponent<Text>().text = "FPS: " + frames.ToString();
            }
        }
        else
        {
            this.GetComponent<Text>().text = "";
        }
    }
}
