using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkills : MonoBehaviour
{
    int runeSelect;
    public BoxCollider Rune;
    void Start()
    {
        SkillsUp();
    }
    
    void Update()
    {
        
    }

    public void SkillsUp()
    {
        runeSelect = PlayerPrefs.GetInt("RuneUsed");

        PlayerPrefs.SetInt("Pilhagem", 0);
        PlayerPrefs.SetFloat("Life", 0);
        PlayerPrefs.SetInt("Infinidade", 0);
        Rune.size = new Vector3(.005f, .005f, .005f);
        PlayerPrefs.SetFloat("Maratonista", 0);

        //Pilhagem - 5
        if (runeSelect == 0)
        {
            int Lvl = PlayerPrefs.GetInt("0Lvl");

            if (Lvl == 1)
            {
                PlayerPrefs.SetInt("Pilhagem", 10);
            }
            else if (Lvl == 2)
            {
                PlayerPrefs.SetInt("Pilhagem", 15);
            }
            else if (Lvl == 3)
            {
                PlayerPrefs.SetInt("Pilhagem", 20);
            }
            else if (Lvl == 4)
            {
                PlayerPrefs.SetInt("Pilhagem", 30);
            }
            else if (Lvl == 5)
            {
                PlayerPrefs.SetInt("Pilhagem", 35);
            }
        }
        //Octopus - 3
        else if (runeSelect == 1)
        {
            int Lvl = PlayerPrefs.GetInt("1Lvl");

            if (Lvl == 1)
            {
                PlayerPrefs.SetFloat("Life", 1);
            }
            else if (Lvl == 2)
            {
                PlayerPrefs.SetFloat("Life", 2);
            }
            else if (Lvl == 3)
            {
                PlayerPrefs.SetFloat("Life", 3);
            }
        }
        //Infinidade - 5
        else if (runeSelect == 2)
        {
            int Lvl = PlayerPrefs.GetInt("2Lvl");

            if (Lvl == 1)
            {
                PlayerPrefs.SetInt("Infinidade", 2);
            }
            else if (Lvl == 2)
            {
                PlayerPrefs.SetInt("Infinidade", 3);
            }
            else if (Lvl == 3)
            {
                PlayerPrefs.SetInt("Infinidade", 4);
            }
            else if (Lvl == 4)
            {
                PlayerPrefs.SetInt("Infinidade", 5);
            }
            else if (Lvl == 5)
            {
                PlayerPrefs.SetInt("Infinidade", 6);
            }
        }
        //Ganancia - 5
        else if (runeSelect == 3)
        {
            int Lvl = PlayerPrefs.GetInt("3Lvl");

            if (Lvl == 1)
            {
                Rune.size = new Vector3(.0075f, .0075f, .0075f);
            }
            else if (Lvl == 2)
            {
                Rune.size = new Vector3(.01f, .01f, .01f);
            }
            else if (Lvl == 3)
            {
                Rune.size = new Vector3(.015f, .015f, .015f);
            }
            else if (Lvl == 4)
            {
                Rune.size = new Vector3(.0175f, .0175f, .0175f);
            }
            else if (Lvl == 5)
            {
                Rune.size = new Vector3(.02f, .02f, .02f);
            }
        }
        //Maratonista - 5
        else if (runeSelect == 4)
        {
            int Lvl = PlayerPrefs.GetInt("4Lvl");

            if (Lvl == 1)
            {
                PlayerPrefs.SetFloat("Maratonista", .2f);
            }
            else if (Lvl == 2)
            {
                PlayerPrefs.SetFloat("Maratonista", .4f);
            }
            else if (Lvl == 3)
            {
                PlayerPrefs.SetFloat("Maratonista", .6f);
            }
            else if (Lvl == 4)
            {
                PlayerPrefs.SetFloat("Maratonista", .8f);
            }
            else if (Lvl == 5)
            {
                PlayerPrefs.SetFloat("Maratonista", 1);
            }
        }
    }
}