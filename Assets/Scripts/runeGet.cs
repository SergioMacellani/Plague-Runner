using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class runeGet : MonoBehaviour
{
    Player player;
    public bool benchmark, mouseBiome = false;
    public Transform inGame;
    RaycastHit raypoint;
    public LayerMask mouse;
    void Start()
    {
        player = transform.parent.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if(mouseBiome)
        {
            inGame.GetChild(2).gameObject.SetActive(false);
            inGame.GetChild(3).gameObject.SetActive(true);
            inGame.GetChild(4).gameObject.SetActive(true);
        }
        else
        {
            inGame.GetChild(2).gameObject.SetActive(true);
            inGame.GetChild(3).gameObject.SetActive(false);
            inGame.GetChild(4).gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider col)
    {
        if (benchmark == false)
        {
            if (col.tag == "rune")
            {
                Destroy(col.gameObject);
                PlayerPrefs.SetInt("runeUp", PlayerPrefs.GetInt("runeUp") + 1);
                PlayerPrefs.SetInt("attMystic", PlayerPrefs.GetInt("attMystic") + 1);
                this.GetComponent<AudioSource>().Play();
            }

            if (col.tag == "obj" && PlayerPrefs.GetInt("ActiveInfinity") == 0)
            {
                if (PlayerPrefs.GetFloat("Life") == 0)
                {
                    player.die = true;
                }
                else
                {
                    PlayerPrefs.SetFloat("Life", PlayerPrefs.GetFloat("Life") - .5f);
                }
            }
        }
    }
}
