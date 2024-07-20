using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class responsiveSkills : MonoBehaviour
{
    float x, y, z;
    void Start()
    {
        x = Screen.width;
        y = Screen.height;
        z = x / y;
        if (x / y <= .5f)
        {
            this.GetComponent<Camera>().fieldOfView = 93;
        }
        else
        {
            this.GetComponent<Camera>().fieldOfView = 87;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
