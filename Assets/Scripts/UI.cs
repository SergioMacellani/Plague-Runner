using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public events EventScript;
    public GameObject Player;
    GameObject pauseMenu, MenuLenguage;
    bool isPause = false;
    public AnimatorScript anim;

    void Start()
    {
        Application.targetFrameRate = 61;
        MenuLenguage = transform.GetChild(PlayerPrefs.GetInt("lenguage")).gameObject;
        anim = Player.GetComponent<AnimatorScript>();
        if (!Player.GetComponent<runeGet>().benchmark)
        {
            pauseMenu = MenuLenguage.transform.GetChild(8).gameObject;
        }
        PlayerPrefs.SetInt("attBlood", 0);
        PlayerPrefs.SetInt("attMystic", 0);
        PlayerPrefs.SetInt("attMouse", 0);
        QualitySettings.vSyncCount = 0;
        if(PlayerPrefs.GetInt("reRun") == 1)
        {
            PlayerPrefs.SetInt("reRun", 0);
            anim.Run();
            EventScript.gameStart = true;
            EventScript.GameStart();
            MenuLenguage.transform.GetChild(0).gameObject.SetActive(false);
            MenuLenguage.transform.GetChild(4).gameObject.SetActive(true);
            Player.transform.parent.GetComponent<playerTile>().tileStart();
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Play()
    {
        if(transform.GetChild(0).gameObject.activeSelf)
        {
            EventScript.gameStart = true;
            EventScript.GameStart();
            anim.Run();

            if(PlayerPrefs.GetInt("firstTime") == 0)
            {
                PlayServices.UnlockAchievment(PlagueRunner.achievement_for_everything_if_you_have_the_first_time);
                PlayerPrefs.SetInt("firstTime", 1);
            }
        }
    }

    public void Skin(bool goTo)
    {
        if (goTo)
        {
            Player.transform.position = new Vector3(-2.742984f, -0.04994345f, -7.576542f);
            Player.transform.eulerAngles = new Vector3(0, 347.387f, 0);
        }
        else
        {
            Player.transform.position = new Vector3(0, 0, 0);
            Player.transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }

    public void PauseUI(bool pause)
    {
        if (pause)
        {
            pauseMenu.transform.GetChild(5).GetChild(0).GetComponent<Text>().text = PlayerPrefs.GetInt("attBlood").ToString();
            pauseMenu.transform.GetChild(6).GetChild(0).GetComponent<Text>().text = PlayerPrefs.GetInt("attMystic").ToString();
            pauseMenu.transform.GetChild(7).GetChild(0).GetComponent<Text>().text = PlayerPrefs.GetInt("attMouse").ToString();
            isPause = true;
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
            isPause = false;
        }
    }

    public void ReRun()
    {
        PlayerPrefs.SetInt("reRun", 1);
    }

    public void ShowLeaderboardUI()
    {
        PlayServices.ShowLeaderboard(PlagueRunner.leaderboard_plague_points);
    }

    public void ShowAchievmentsUI()
    {
        PlayServices.ShowAchievments();
    }
}
