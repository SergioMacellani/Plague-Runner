using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pointsUpdate : MonoBehaviour
{
    Text pointsUp, pointsDw, mounts, distanceRunDw, distanceRunUp;
    int points, mystic, blood, mouse, distance;
    int pM = 2, pR = 3, pointCount = 0;
    public float pD = 1, pB = 4;
    void Start()
    {
        pointsDw = transform.GetChild(1).GetComponent<Text>();
        pointsUp = pointsDw.transform.GetChild(0).GetComponent<Text>();
        mounts = transform.GetChild(2).GetComponent<Text>();
        distanceRunDw = transform.GetChild(3).GetComponent<Text>();
        distanceRunUp = distanceRunDw.transform.GetChild(0).GetComponent<Text>();
        mystic = PlayerPrefs.GetInt("attMystic");
        blood = PlayerPrefs.GetInt("attBlood");
        mouse = PlayerPrefs.GetInt("attMouse");
        distance = PlayerPrefs.GetInt("Distance");

        pD += PlayerPrefs.GetFloat("Maratonista");
        pB -= PlayerPrefs.GetFloat("Maratonista");

        if(mouse == 100)
        {
            PlayServices.UnlockAchievment(PlagueRunner.achievement_mousdred);
        }

        points = (int)(((distance/10) * pD + mystic * pM + blood * pB + mouse * pR) / 10) * 100;

        distanceRunDw.text = "VOCÊ CORREU: " + distance + "m";
        distanceRunUp.text = distanceRunDw.text;

        if (PlayerPrefs.GetInt("MaxPoint") < points)
        {
            PlayerPrefs.SetInt("MaxPoint", points);
            transform.GetChild(4).gameObject.SetActive(true);
        }

        mounts.text =
        "Ratos Eliminados: " + mouse +
        "\nMystic Runes: " + mystic +
        "\nBlood Runes: " + blood;

        PlayerPrefs.SetInt("Distance", 0);

        if(points > PlayServices.GetPlayerScore(PlagueRunner.leaderboard_plague_points))
        {
            PlayServices.PostScore((long)points, PlagueRunner.leaderboard_plague_points);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (pointCount < points)
        {
            if(points <= 300)
            {
                pointCount += 5;
            }
            else if(points <= 1000)
            {
                pointCount += 10;
            }
            else if(points <= 2500)
            {
                pointCount += 20;
            }
            else if(points <= 5000)
            {
                pointCount += 40;
            }
            else if(points <= 10000)
            {
                pointCount += 80;
            }
            else if (points <= 20000)
            {
                pointCount += 160;
            }
            else
            {
                pointCount += 250;
            }

        }
        else { pointCount = points; }

        pointsDw.text = pointCount.ToString();
        pointsUp.text = pointsDw.text;
    }
}
