using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bookSkills : MonoBehaviour
{
    Text Title, Description, Title2, LvlDesc, NxtDesc, LvlText, LvlNum, UpPrice, UseBtt;
    Image RuneSelected;
    Slider BarLvl;
    runeType[] RunesArray;
    char runeSel;
    bool buy, use;
    int rSel = 0, runeLvl;
    void Start()
    {
        Title = transform.GetChild(4).GetChild(1).GetComponent<Text>();
        RuneSelected = transform.GetChild(4).GetChild(0).GetChild(0).GetComponent<Image>();
        Description = transform.GetChild(4).GetChild(2).GetComponent<Text>();
        UseBtt = transform.GetChild(4).GetChild(3).GetChild(0).GetChild(0).GetComponent<Text>();

        Title2 = transform.GetChild(5).GetChild(0).GetComponent<Text>();
        LvlDesc = transform.GetChild(5).GetChild(4).GetComponent<Text>();
        NxtDesc = transform.GetChild(5).GetChild(5).GetComponent<Text>();
        LvlText = transform.GetChild(5).GetChild(1).GetComponent<Text>();
        LvlNum = transform.GetChild(5).GetChild(3).GetComponent<Text>();
        BarLvl = transform.GetChild(5).GetChild(2).GetComponent<Slider>();
        UpPrice = transform.GetChild(5).GetChild(6).GetChild(1).GetComponent<Text>();

        RunesArray = new runeType[transform.GetChild(3).transform.childCount];

        for (int i = 0; i < transform.GetChild(3).transform.childCount; i++)
        {
            RunesArray[i] = transform.GetChild(3).transform.GetChild(i).GetComponent<runeType>();
        }

        RuneSelect(PlayerPrefs.GetInt("RuneUsed"));
        rSel = PlayerPrefs.GetInt("RuneUsed");
        runeLvl = (PlayerPrefs.GetInt(rSel + "Lvl"));

    }

    // Update is called once per frame
    void Update()
    {
        transform.GetChild(2).GetChild(1).GetComponent<Text>().text = PlayerPrefs.GetInt("runeSkin").ToString();
    }

    public void RuneSelect(int r)
    {
        runeLvl = (PlayerPrefs.GetInt(r + "Lvl"));
        Title.text = RunesArray[r].Name;
        Title2.text = Title.text;
        Description.text = RunesArray[r].Description;
        if(runeLvl == 0)
        {
            LvlDesc.text = "";
            BarLvl.value = 0;
        }
        else
        {
            float LvlF = runeLvl;
            LvlDesc.text = RunesArray[r].LvlDesc[runeLvl - 1];
            BarLvl.value = LvlF / (RunesArray[r].UpPrice.Length);
        }
        NxtDesc.text = "Nivel " + (runeLvl + 1) + ": " + RunesArray[r].LvlDesc[runeLvl];
        LvlText.text = "Nivel: " + runeLvl;
        LvlNum.text = runeLvl + "/" + (RunesArray[r].UpPrice.Length);
        if(runeLvl == RunesArray[r].UpPrice.Length)
        {
            UpPrice.transform.parent.gameObject.SetActive(false);
            transform.GetChild(5).GetChild(7).GetComponent<Button>().enabled = false;
            PlayServices.UnlockAchievment(PlagueRunner.achievement_dr_rime_pupil);
        }
        else
        {
            transform.GetChild(5).GetChild(7).GetComponent<Button>().enabled = true;
            UpPrice.transform.parent.gameObject.SetActive(true);
            UpPrice.text = RunesArray[r].UpPrice[runeLvl].ToString();
        }

        RuneSelected.sprite = RunesArray[r].GetComponent<Image>().sprite;

        if(r == PlayerPrefs.GetInt("RuneUsed"))
        {
            UseBtt.text = "EQUIPADO";
        }
        else
        {
            UseBtt.text = "EQUIPAR";
        }

        rSel = r;
    }

    public void RuneUse()
    {
        PlayerPrefs.SetInt(Title.text + "runeUse", 1);
        PlayerPrefs.SetInt("RuneUsed", rSel);
        UseBtt.text = "EQUIPADO";
    }

    public void Upgrade()
    {
        if (PlayerPrefs.GetInt("runeSkin") >= int.Parse(UpPrice.text) && runeLvl < RunesArray[rSel].UpPrice.Length)
        {
            PlayerPrefs.SetInt(rSel + "Lvl", runeLvl + 1);
            PlayerPrefs.SetInt("runeSkin", PlayerPrefs.GetInt("runeSkin") - int.Parse(UpPrice.text));
            runeLvl = (PlayerPrefs.GetInt(rSel + "Lvl"));
            RuneSelect(rSel);
        }
    }

    public void MoreRune()
    {
        PlayerPrefs.SetInt("runeSkin", PlayerPrefs.GetInt("runeSkin") +10);
        PlayerPrefs.SetInt("runeUp", PlayerPrefs.GetInt("runeUp") +10);
    }
}
