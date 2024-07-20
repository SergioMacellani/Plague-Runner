using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mouseUpdate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Text>().text = PlayerPrefs.GetInt("attMouse").ToString();
        transform.GetChild(0).GetComponent<Text>().text = this.GetComponent<Text>().text;
    }
}
