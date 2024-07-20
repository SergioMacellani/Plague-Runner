using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class die : MonoBehaviour
{
    public Player player;
    Transform MenuLenguage;
    void Start()
    {
        MenuLenguage = transform.GetChild(PlayerPrefs.GetInt("lenguage"));
    }

    // Update is called once per frame
    void Update()
    {
        if(player.die == true)
        {
            if (MenuLenguage.GetChild(1).gameObject.activeSelf)
            {
                Time.timeScale = 0;
            }
            MenuLenguage.GetChild(0).gameObject.SetActive(false);
            MenuLenguage.GetChild(4).gameObject.SetActive(false);
            MenuLenguage.GetChild(1).gameObject.SetActive(true);
        }
    }
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

}
