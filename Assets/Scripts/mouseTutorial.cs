using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseTutorial : MonoBehaviour
{
    public Transform Player;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "PlayerKill")
        {
            Destroy(this.gameObject);
        }
        name = col.name;
    }
}
