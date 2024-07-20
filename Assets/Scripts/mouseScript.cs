using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseScript : MonoBehaviour
{
    Transform Player;
    float dist;
    int blood;

    void Start()
    {
        Player = transform.parent.parent.parent.parent.parent.GetComponent<tilesInfo>().Player;
    }

    // Update is called once per frame
    void Update()
    {
        dist = Mathf.Abs(transform.position.z - Player.position.z);
        if(dist <= 4 && PlayerPrefs.GetInt("ActiveInfinity") == 0)
        {
            if(PlayerPrefs.GetFloat("Life") == 0)
            {
                Player.parent.GetComponent<Player>().die = true;
            }
            else
            {
                PlayerPrefs.SetFloat("Life", PlayerPrefs.GetFloat("Life") - .5f);
            }

        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.tag == "PlayerKill")
        {
            Destroy(this.gameObject);
            PlayerPrefs.SetInt("attMouse", PlayerPrefs.GetInt("attMouse") + 1);
            blood = Random.Range(0, 100);
            if (blood <= (25 + PlayerPrefs.GetInt("Pilhagem")))
            {
                PlayerPrefs.SetInt("attBlood", PlayerPrefs.GetInt("attBlood") + 1);
                PlayerPrefs.SetInt("runeSkin", PlayerPrefs.GetInt("runeSkin") + 1);
            }
        }
        name = col.name;
    }
}
