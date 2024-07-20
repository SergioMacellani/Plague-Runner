using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shop : MonoBehaviour
{
    char rune = 'M';
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shop(bool goTo)
    {
        if (goTo)
        {
            if (rune == 'M') 
            {
                transform.GetChild(6).gameObject.SetActive(false);
                transform.GetChild(7).gameObject.SetActive(true);
                rune = 'B';
            }else if(rune == 'B')
            {
                transform.GetChild(7).gameObject.SetActive(false);
                transform.GetChild(8).gameObject.SetActive(true);
                rune = 'G';
            }
            else
            {
                transform.GetChild(8).gameObject.SetActive(false);
                transform.GetChild(6).gameObject.SetActive(true);
                rune = 'M';
            }
        }
        else
        {
            if (rune == 'M')
            {
                transform.GetChild(6).gameObject.SetActive(false);
                transform.GetChild(8).gameObject.SetActive(true);
                rune = 'G';
            }
            else if (rune == 'B')
            {
                transform.GetChild(7).gameObject.SetActive(false);
                transform.GetChild(6).gameObject.SetActive(true);
                rune = 'M';
            }
            else
            {
                transform.GetChild(8).gameObject.SetActive(false);
                transform.GetChild(7).gameObject.SetActive(true);
                rune = 'B';
            }
        }
    }
}
