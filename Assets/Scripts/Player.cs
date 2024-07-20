using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [Range(0, 500)]
    public float velIn = 5;
    [Range(0, 100)]
    public float jumpFor = 10.65f;
    float vel;
    public bool die, water, jump = false;
    public float jumpF;
    public float t;
    public Shader[] shaders;
    public events EventScript;
    public GameObject PlayerChar;
    GameObject[] skinsModels;
    public Material[] skinMat;
    public SkinChange skin;
    AnimatorScript anim;

    void Start()
    {
        Time.timeScale = 1;
        skinsModels = new GameObject[transform.GetChild(0).childCount];
        PlayerChar = transform.GetChild(0).gameObject;
        anim = transform.GetChild(0).GetComponent<AnimatorScript>();

        for (int i = 0; i < transform.GetChild(0).childCount; i++)
        {
            skinsModels[i] = transform.GetChild(0).GetChild(i).gameObject;
            skinsModels[i].SetActive(false);
        }
        skinsModels[PlayerPrefs.GetInt("skinSet")].SetActive(true);
        if(PlayerPrefs.GetInt("skinSet") == 0)
        {
            skinMat[0].mainTexture = skin.docTexture[PlayerPrefs.GetInt("colorSet")];
        }
        else if (PlayerPrefs.GetInt("skinSet") == 1)
        {
            skinMat[1].mainTexture = skin.dorimeTexture[PlayerPrefs.GetInt("colorSet")];
        }
        else if (PlayerPrefs.GetInt("skinSet") == 2)
        {
            skinMat[2].mainTexture = skin.ghostTexture[PlayerPrefs.GetInt("colorSet")];
        }
        else if (PlayerPrefs.GetInt("skinSet") == 3)
        {
            skinMat[3].mainTexture = skin.knightTexture[PlayerPrefs.GetInt("colorSet")];
        }
    }

    // Update is called once per frame
    void Update()
    {
        jumpF = jumpFor * Time.deltaTime;
        if (die == false && EventScript.gameStart)
        {
            if (Input.GetKeyDown(KeyCode.Space) && PlayerChar.transform.position.y <= 0 && jump == false && die == false)
            {
                jump = true;
                transform.GetChild(8).GetComponent<AudioSource>().Play();
            }
            if (jump && PlayerChar.transform.position.y < 6)
            {
                PlayerChar.transform.position += new Vector3(0, jumpF, 0);
                anim.Jump();
            }
            else { jump = false; anim.AJump(); }
        }
        if (die)
        {
            anim.Die();
        }

        if(PlayerPrefs.GetInt("ActiveInfinity") == 1 && skinMat[PlayerPrefs.GetInt("skinSet")].shader == shaders[1])
        {
            skinMat[PlayerPrefs.GetInt("skinSet")].shader = shaders[0];
        }
        else if(skinMat[PlayerPrefs.GetInt("skinSet")].shader == shaders[0])
        {
            skinMat[PlayerPrefs.GetInt("skinSet")].shader = shaders[1];
        }
    }

    public void Jump()
    {
        if (PlayerChar.transform.position.y <= 0 && jump == false && die == false)
        {
            jump = true;
            transform.GetChild(8).GetComponent<AudioSource>().Play();
        }
    }

}
