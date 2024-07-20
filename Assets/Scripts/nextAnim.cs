using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nextAnim : MonoBehaviour
{
    public bool scale;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localScale.x < 1.19f && scale)
        {
            transform.localScale = new Vector2(Mathf.Lerp(transform.localScale.x, 1.2f, .025f), Mathf.Lerp(transform.localScale.y, 1.2f, .025f));
        }
        else { scale = false; }
        if (transform.localScale.x > 0.91f & scale == false)
        {
            transform.localScale = new Vector2(Mathf.Lerp(transform.localScale.x, 0.9f, .025f), Mathf.Lerp(transform.localScale.y, 0.9f, .025f));
        }
        else { scale = true; }
    }
}
