using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartConfig : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetInt("blind", transform.GetChild(1).GetChild(0).GetComponent<optionsChange>().Select);
    }

    public void Done()
    {
        transform.parent.GetChild(2).gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
}
