using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightOptions : MonoBehaviour
{
    public Light[] lights;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //30 Im, 60 Auto, Bx Not
    }

    public void Lights(int lightMode)
    {
        if(lightMode == 0)

        {
            lights[0].renderMode = LightRenderMode.ForcePixel;
            lights[1].renderMode = LightRenderMode.ForcePixel;
            lights[2].renderMode = LightRenderMode.ForcePixel;
            lights[3].renderMode = LightRenderMode.ForcePixel;
        }
        else if (lightMode == 1)
        {
            lights[0].renderMode = LightRenderMode.Auto;
            lights[1].renderMode = LightRenderMode.Auto;
            lights[2].renderMode = LightRenderMode.Auto;
            lights[3].renderMode = LightRenderMode.Auto;
        }
        else if(lightMode == 2)
        {
            lights[0].renderMode = LightRenderMode.ForceVertex;
            lights[1].renderMode = LightRenderMode.ForceVertex;
            lights[2].renderMode = LightRenderMode.ForceVertex;
            lights[3].renderMode = LightRenderMode.ForceVertex;
        }
    }
}
