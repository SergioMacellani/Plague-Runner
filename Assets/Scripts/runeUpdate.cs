using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class runeUpdate : MonoBehaviour
{
    Text runeUp, runeSkin, runeMoney;

    void Start()
    {
        if(this.gameObject.name == "runesCtt")
        {
            runeUp = transform.GetChild(0).GetComponent<Text>();
            runeSkin = transform.GetChild(1).GetComponent<Text>();

            runeUp.text = PlayerPrefs.GetInt("attBlood").ToString();
            runeSkin.text = PlayerPrefs.GetInt("attMystic").ToString();
        }
        else
        {
            runeUp = transform.GetChild(0).GetChild(0).GetComponent<Text>();
            runeSkin = transform.GetChild(1).GetChild(0).GetComponent<Text>();
            runeMoney = transform.GetChild(2).GetChild(0).GetComponent<Text>();

            runeUp.text = PlayerPrefs.GetInt("runeUp").ToString();
            runeSkin.text = PlayerPrefs.GetInt("runeSkin").ToString();
            runeMoney.text = PlayerPrefs.GetInt("runeMoney").ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.activeSelf)
        {
            if (this.gameObject.name == "runesCtt")
            {
                runeUp.text = PlayerPrefs.GetInt("attBlood").ToString();
                runeSkin.text = PlayerPrefs.GetInt("attMystic").ToString();
            }
            else
            {
                runeUp.text = PlayerPrefs.GetInt("runeUp").ToString();
                runeSkin.text = PlayerPrefs.GetInt("runeSkin").ToString();
                runeMoney.text = PlayerPrefs.GetInt("runeMoney").ToString();
            }
        }
    }
}
