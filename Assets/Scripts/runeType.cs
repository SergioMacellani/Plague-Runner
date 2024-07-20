using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class runeType : MonoBehaviour
{
    public string Name;
    [TextArea(3, 20)]
    public string Description;
    public int[] UpPrice;
    public string[] LvlDesc;
    public bool use;
    void Start()
    {
        use = (PlayerPrefs.GetInt(Name + "runeUse") == 1) ? true : false; ;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
