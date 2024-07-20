using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class runeScript : MonoBehaviour
{
    float pos = 1;
    bool up;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles += new Vector3(0, 0, 60 * Time.deltaTime);
        if (pos <= 1.5f && up)
        {
            pos += .5f * Time.deltaTime;
            transform.position += new Vector3(0, .5f * Time.deltaTime, 0);
        }
        else { up = false; }
        if(pos >= 0.75f & up == false)
        {
            pos -= .5f * Time.deltaTime;
            transform.position -= new Vector3(0, .5f * Time.deltaTime, 0);
        }
        else { up = true; }

    }
}
