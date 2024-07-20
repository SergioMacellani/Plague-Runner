using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class optionsChange : MonoBehaviour
{
    public string[] Options;
    public int Select;
    void Start()
    {
        this.GetComponent<Text>().text = Options[Select];
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Text>().text = Options[Select];
    }

    public void NextBack(bool next)
    {
        if (next)
        {
            if(Select < Options.Length - 1)
            {
                Select++;
            }
            else
            {
                Select = 0;
            }
        }
        else
        {
            if (Select > 0)
            {
                Select--;
            }
            else
            {
                Select = Options.Length - 1;
            }
        }

        this.GetComponent<Text>().text = Options[Select];
    }

    public void IsUse(bool use)
    {
        if (!use)
        {
            transform.GetChild(0).GetComponent<Button>().interactable = false;
            transform.GetChild(1).GetComponent<Button>().interactable = false;
        }
        else
        {
            transform.GetChild(0).GetComponent<Button>().interactable = true;
            transform.GetChild(1).GetComponent<Button>().interactable = true;
        }
        this.GetComponent<Text>().text = Options[Select];
    }
}
