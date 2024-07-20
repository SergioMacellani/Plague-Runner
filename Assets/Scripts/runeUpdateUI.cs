using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class runeUpdateUI : MonoBehaviour
{
    public char rune;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(rune == 'M')
        {
            transform.GetChild(0).GetComponent<Text>().text = PlayerPrefs.GetInt("runeUp").ToString();
        }
        else if (rune == 'B')
        {
            transform.GetChild(0).GetComponent<Text>().text = PlayerPrefs.GetInt("runeSkin").ToString();
        }
        else
        {
            transform.GetChild(0).GetComponent<Text>().text = PlayerPrefs.GetInt("runeMoney").ToString();
        }
    }
}
