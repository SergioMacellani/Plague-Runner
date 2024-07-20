using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseSpawner : MonoBehaviour
{
    public GameObject mouse;
    void Start()
    {
        if (Random.Range(0, 2) <= 1)
        {
            GameObject mouses = (GameObject)Instantiate(mouse);
            mouses.transform.position = this.transform.position;
            mouses.transform.parent = transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
