using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class events : MonoBehaviour
{
    public bool gameStart;
    public GameObject CamMenu, CamPlayer, Canvas;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameStart()
    {
        CamMenu.SetActive(false);
        CamPlayer.SetActive(true);
        Canvas.transform.GetChild(1).gameObject.SetActive(false);
    }
}
