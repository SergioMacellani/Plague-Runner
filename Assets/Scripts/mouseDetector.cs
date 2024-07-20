using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseDetector : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Enemy")
        {
            transform.parent.parent.GetChild(0).GetComponent<runeGet>().mouseBiome = true;
        }
        else
        {
            transform.parent.parent.GetChild(0).GetComponent<runeGet>().mouseBiome = false;
        }
    }
}
