using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinChange : MonoBehaviour
{
    public Material[] materials;
    public Transform Player;
    GameObject[] skinsModels;
    public Texture[] docTexture, dorimeTexture, ghostTexture, knightTexture;
    public Sprite[] docColors, dorimeColors, ghostColors, knightColors;

    public GameObject[] ColorOptions;

    Texture SetTextureDoc, SetTextureDori, SetTextureGhost, SetTextureKnight;
    GameObject SetSkin;
    int setSkinNum, setColorNum;

    public GameObject colorUI, scroll, groupColors;
    public int skinSelect = 0, colorSelect = 0;

    public bool skinBuy, colorBuy;

    public string colorSkin;
    public string skinSel;

    public float scrollPos;
    void Start()
    {

    }

    public void StartSkin()
    {
        colorUI = transform.GetChild(4).transform.GetChild(1).gameObject;
        scroll = transform.GetChild(4).transform.GetChild(1).transform.GetChild(1).gameObject;
        groupColors = transform.GetChild(4).transform.GetChild(1).transform.GetChild(0).transform.GetChild(0).gameObject;
        if (PlayerPrefs.GetInt("skinBuy0") == 0)
        {
            PlayerPrefs.SetInt("skinBuy0", 1);
            PlayerPrefs.SetInt("colorBuy00", 1);
        }

        skinSelect = PlayerPrefs.GetInt("skinSet");
        colorSelect = PlayerPrefs.GetInt("colorSet");
        skinBuy = (PlayerPrefs.GetInt("skinBuy" + skinSelect.ToString()) == 1) ? true : false;
        colorBuy = (PlayerPrefs.GetInt("colorBuy" + skinSelect.ToString() + colorSelect.ToString()) == 1) ? true : false;

        setColorNum = colorSelect;
        SetTextureDoc = docTexture[colorSelect];
        SetTextureDori = dorimeTexture[colorSelect];
        SetTextureGhost = ghostTexture[colorSelect];
        SetTextureKnight = knightTexture[colorSelect];

        skinsModels = new GameObject[Player.childCount];

        for (int i = 0; i < Player.childCount; i++)
        {
            skinsModels[i] = Player.GetChild(i).gameObject;
            skinsModels[i].SetActive(false);
        }

        ColorOptions = new GameObject[groupColors.transform.childCount];

        for (int i = 0; i < groupColors.transform.childCount; i++)
        {
            ColorOptions[i] = groupColors.transform.GetChild(i).gameObject;
        }

        scroll.GetComponent<Scrollbar>().value = 0f;

        skinsModels[skinSelect].SetActive(true);
        SetSkin = skinsModels[skinSelect];
        BuySkin();
        UpdateColorLocate();
        UpdateColorTexture();

        colorUI.SetActive(false);
        colorUI.transform.parent.transform.GetChild(0).gameObject.SetActive(true);
        UpdateColorLocate();
    }

    // Update is called once per frame
    void Update()
    {
        if (colorUI.activeSelf)
        {
            if (Input.GetMouseButton(0))
            {
                scrollPos = scroll.GetComponent<Scrollbar>().value;
            }
            else
            {
                scrollPos = scroll.GetComponent<Scrollbar>().value;

                if (scrollPos > 0 && scrollPos < .165f)
                {
                    scroll.GetComponent<Scrollbar>().value = Mathf.Lerp(scroll.GetComponent<Scrollbar>().value, 0, .25f);
                }
                else if (scrollPos < .33f && scrollPos > .165f)
                {
                    scroll.GetComponent<Scrollbar>().value = Mathf.Lerp(scroll.GetComponent<Scrollbar>().value, .33f, .25f);
                }
                else if (scrollPos > .33f && scrollPos < .495f)
                {
                    scroll.GetComponent<Scrollbar>().value = Mathf.Lerp(scroll.GetComponent<Scrollbar>().value, .33f, .25f);
                }
                else if (scrollPos < .66f && scrollPos > .495f)
                {
                    scroll.GetComponent<Scrollbar>().value = Mathf.Lerp(scroll.GetComponent<Scrollbar>().value, .66f, .25f);
                }
                else if (scrollPos > .66f && scrollPos < .825f)
                {
                    scroll.GetComponent<Scrollbar>().value = Mathf.Lerp(scroll.GetComponent<Scrollbar>().value, .66f, .25f);
                }
                else if (scrollPos < 1 && scrollPos > .825f)
                {
                    scroll.GetComponent<Scrollbar>().value = Mathf.Lerp(scroll.GetComponent<Scrollbar>().value, 1f, .25f);
                }

                if(scrollPos < .01)
                {
                    colorSelect = 0;
                    materials[0].mainTexture = docTexture[colorSelect];
                    materials[1].mainTexture = dorimeTexture[colorSelect];
                    materials[2].mainTexture = ghostTexture[colorSelect];
                    materials[3].mainTexture = knightTexture[colorSelect];
                    BuySkin();
                    if (colorBuy)
                    {
                        setColorNum = colorSelect;
                        SetTextureDoc = docTexture[colorSelect];
                        SetTextureDori = dorimeTexture[colorSelect];
                        SetTextureGhost = ghostTexture[colorSelect];
                        SetTextureKnight = knightTexture[colorSelect];
                        PlayerPrefs.SetInt("colorSet", colorSelect);
                    }
                }
                else if(scrollPos > 0.32f && scrollPos < 0.34f)
                {
                    colorSelect = 1;
                    materials[0].mainTexture = docTexture[colorSelect];
                    materials[1].mainTexture = dorimeTexture[colorSelect];
                    materials[2].mainTexture = ghostTexture[colorSelect];
                    materials[3].mainTexture = knightTexture[colorSelect];
                    BuySkin();
                    if (colorBuy)
                    {
                        setColorNum = colorSelect;
                        SetTextureDoc = docTexture[colorSelect];
                        SetTextureDori = dorimeTexture[colorSelect];
                        SetTextureGhost = ghostTexture[colorSelect];
                        SetTextureKnight = knightTexture[colorSelect];
                        PlayerPrefs.SetInt("colorSet", colorSelect);
                    }
                }
                else if (scrollPos > 0.65f && scrollPos < 0.67f)
                {
                    colorSelect = 2;
                    materials[0].mainTexture = docTexture[colorSelect];
                    materials[1].mainTexture = dorimeTexture[colorSelect];
                    materials[2].mainTexture = ghostTexture[colorSelect];
                    materials[3].mainTexture = knightTexture[colorSelect];
                    BuySkin();
                    if (colorBuy)
                    {
                        setColorNum = colorSelect;
                        SetTextureDoc = docTexture[colorSelect];
                        SetTextureDori = dorimeTexture[colorSelect];
                        SetTextureGhost = ghostTexture[colorSelect];
                        SetTextureKnight = knightTexture[colorSelect];
                        PlayerPrefs.SetInt("colorSet", colorSelect);
                    }
                }
                else if (scrollPos > 0.99f)
                {
                    colorSelect = 3;
                    materials[0].mainTexture = docTexture[colorSelect];
                    materials[1].mainTexture = dorimeTexture[colorSelect];
                    materials[2].mainTexture = ghostTexture[colorSelect];
                    materials[3].mainTexture = knightTexture[colorSelect];
                    BuySkin();
                    if (colorBuy)
                    {
                        setColorNum = colorSelect;
                        SetTextureDoc = docTexture[colorSelect];
                        SetTextureDori = dorimeTexture[colorSelect];
                        SetTextureGhost = ghostTexture[colorSelect];
                        SetTextureKnight = knightTexture[colorSelect];
                        PlayerPrefs.SetInt("colorSet", colorSelect);
                    }
                }
            }
            ColorOptions[1].transform.localScale = new Vector2(1 - Mathf.Abs(scrollPos - 0), 1 - Mathf.Abs(scrollPos - 0));
            ColorOptions[2].transform.localScale = new Vector2(1 - Mathf.Abs(scrollPos - .33f), 1 - Mathf.Abs(scrollPos - .33f));
            ColorOptions[3].transform.localScale = new Vector2(1 - Mathf.Abs(scrollPos - .66f), 1 - Mathf.Abs(scrollPos - .66f));
            ColorOptions[4].transform.localScale = new Vector2(1 - Mathf.Abs(scrollPos - 1), 1 - Mathf.Abs(scrollPos - 1));
        }
        transform.GetChild(6).GetChild(0).GetComponent<Text>().text = PlayerPrefs.GetInt("runeUp").ToString();
    }

    void UpdateSkin()
    {
        materials[0].mainTexture = docTexture[0];
        materials[1].mainTexture = dorimeTexture[0];
        materials[2].mainTexture = ghostTexture[0];
        materials[3].mainTexture = knightTexture[0];
    }

    public void NextSkin()
    {
        scroll.GetComponent<Scrollbar>().value = 0.05f;
        scrollPos = 0.05f;
        if (skinSelect < skinsModels.Length - 1)
        {
            skinsModels[skinSelect].SetActive(false);
            skinSelect++;
            skinsModels[skinSelect].SetActive(true);
        }
        else
        {
            skinsModels[skinSelect].SetActive(false);
            skinSelect = 0;
            skinsModels[skinSelect].SetActive(true);
        }
        colorUI.SetActive(false);
        colorUI.transform.parent.transform.GetChild(0).gameObject.SetActive(true);
        colorSelect = 0;
        UpdateSkin();
        BuySkin();

        if (skinBuy)
        {
            SetSkin = skinsModels[skinSelect];
            setSkinNum = skinSelect;
            setColorNum = 0;
            SetTextureDoc = docTexture[0];
            SetTextureDori = dorimeTexture[0];
            SetTextureGhost = ghostTexture[0];
            SetTextureKnight = knightTexture[0];
            PlayerPrefs.SetInt("skinSet", skinSelect);
            PlayerPrefs.SetInt("colorSet", colorSelect);
        }
    }
    public void BackSkin()
    {
        scroll.GetComponent<Scrollbar>().value = 0.05f;
        scrollPos = 0.05f;
        if (skinSelect > 0)
        {
            skinsModels[skinSelect].SetActive(false);
            skinSelect--;
            skinsModels[skinSelect].SetActive(true);
        }
        else
        {
            skinsModels[skinSelect].SetActive(false);
            skinSelect = skinsModels.Length - 1;
            skinsModels[skinSelect].SetActive(true);
        }
        colorUI.SetActive(false);
        colorUI.transform.parent.transform.GetChild(0).gameObject.SetActive(true);

        colorSelect = 0;
        UpdateSkin();
        BuySkin();

        if (skinBuy)
        {
            SetSkin = skinsModels[skinSelect];
            setSkinNum = skinSelect;
            setColorNum = 0;
            SetTextureDoc = docTexture[0];
            SetTextureDori = dorimeTexture[0];
            SetTextureGhost = ghostTexture[0];
            SetTextureKnight = knightTexture[0];
            PlayerPrefs.SetInt("skinSet", skinSelect);
            PlayerPrefs.SetInt("colorSet", colorSelect);
        }

    }

    public void ColorUI()
    {
        if (colorUI.activeSelf)
        {
            UpdateColorTexture();
            colorUI.SetActive(false);
            UpdateColorLocate();
        }
        else
        {
            UpdateColorTexture();
            colorUI.SetActive(true);
            UpdateColorLocate();
        }
    }

    public void ColorSet()
    {
        if (skinSelect == 0)
        {
            BuySkin();
            if (colorBuy)
            {
                setColorNum = colorSelect;
                SetTextureDoc = docTexture[colorSelect];
                SetTextureDori = dorimeTexture[0];
                SetTextureGhost = ghostTexture[0];
                SetTextureKnight = knightTexture[0];
                PlayerPrefs.SetInt("colorSet", colorSelect);
            }

        }
    }

    public void BuySkin()
    {
        colorSkin = "colorBuy" + skinSelect.ToString() + colorSelect.ToString();
        skinSel = "skinBuy" + skinSelect.ToString();

        colorBuy = (PlayerPrefs.GetInt(colorSkin) == 1) ? true : false;
        skinBuy = (PlayerPrefs.GetInt(skinSel) == 1) ? true : false;

        if (skinBuy == false)
        {
            transform.GetChild(5).gameObject.SetActive(true);
            transform.GetChild(4).gameObject.SetActive(false);
        }
        else
        {
            transform.GetChild(5).gameObject.SetActive(false);
            transform.GetChild(4).gameObject.SetActive(true);
            if (colorBuy == false)
            {
                transform.GetChild(4).GetChild(2).gameObject.SetActive(true);
            }
            else
            {
                transform.GetChild(4).GetChild(2).gameObject.SetActive(false);
            }
        }
    }

    public void backSkin()
    {
        for (int i = 0; i < skinsModels.Length; i++)
        {
            skinsModels[i].SetActive(false);
        }
        SetSkin.SetActive(true);
        materials[0].mainTexture = SetTextureDoc;
        materials[1].mainTexture = SetTextureDori;
        materials[2].mainTexture = SetTextureGhost;
        materials[3].mainTexture = SetTextureKnight;
        PlayerPrefs.SetInt("skinSet", setSkinNum);
        PlayerPrefs.SetInt("colorSet", setColorNum);
    }

    void UpdateColorTexture()
    {
        if (PlayerPrefs.GetInt("skinSet") == 0)
        {
            ColorOptions[1].GetComponent<Image>().sprite = docColors[0];
            ColorOptions[2].GetComponent<Image>().sprite = docColors[1];
            ColorOptions[3].GetComponent<Image>().sprite = docColors[2];
            ColorOptions[4].GetComponent<Image>().sprite = docColors[3];
        }
        else if (PlayerPrefs.GetInt("skinSet") == 1)
        {
            ColorOptions[1].GetComponent<Image>().sprite = dorimeColors[0];
            ColorOptions[2].GetComponent<Image>().sprite = dorimeColors[1];
            ColorOptions[3].GetComponent<Image>().sprite = dorimeColors[2];
            ColorOptions[4].GetComponent<Image>().sprite = dorimeColors[3];
        }
        else if (PlayerPrefs.GetInt("skinSet") == 2)
        {
            ColorOptions[1].GetComponent<Image>().sprite = ghostColors[0];
            ColorOptions[2].GetComponent<Image>().sprite = ghostColors[1];
            ColorOptions[3].GetComponent<Image>().sprite = ghostColors[2];
            ColorOptions[4].GetComponent<Image>().sprite = ghostColors[3];
        }
        else if (PlayerPrefs.GetInt("skinSet") == 3)
        {
            ColorOptions[1].GetComponent<Image>().sprite = knightColors[0];
            ColorOptions[2].GetComponent<Image>().sprite = knightColors[1];
            ColorOptions[3].GetComponent<Image>().sprite = knightColors[2];
            ColorOptions[4].GetComponent<Image>().sprite = knightColors[3];
        }
    }

    void UpdateColorLocate()
    {
        if (PlayerPrefs.GetInt("colorSet") == 0)
        {
            scroll.GetComponent<Scrollbar>().value = 0;
        }
        else if(PlayerPrefs.GetInt("colorSet") == 1)
        {
            scroll.GetComponent<Scrollbar>().value = .33f;
        }
        else if (PlayerPrefs.GetInt("colorSet") == 2)
        {
            scroll.GetComponent<Scrollbar>().value = .66f;
        }
        else if (PlayerPrefs.GetInt("colorSet") == 3)
        {
            scroll.GetComponent<Scrollbar>().value = 1;
        }
    }

    public void Buy(bool skin)
    {
        if (skin)
        {
            if(PlayerPrefs.GetInt("runeUp") >= 150)
            {
                PlayerPrefs.SetInt("runeUp", PlayerPrefs.GetInt("runeUp") - 150);
                PlayerPrefs.SetInt("skinBuy" + skinSelect.ToString(), 1);
                PlayerPrefs.SetInt("colorBuy" + skinSelect.ToString() + "0", 1);
                BuySkin();
                Player.parent.GetChild(7).GetComponent<AudioSource>().Play();

                SetSkin = skinsModels[skinSelect];
                setSkinNum = skinSelect;
                setColorNum = 0;
                SetTextureDoc = docTexture[0];
                SetTextureDori = dorimeTexture[0];
                SetTextureGhost = ghostTexture[0];
                SetTextureKnight = knightTexture[0];
                PlayerPrefs.SetInt("skinSet", skinSelect);
                PlayerPrefs.SetInt("colorSet", colorSelect);
            }
        }
        else
        {
            if (PlayerPrefs.GetInt("runeUp") >= 50)
            {
                PlayerPrefs.SetInt("runeUp", PlayerPrefs.GetInt("runeUp") - 50);
                PlayerPrefs.SetInt("colorBuy" + skinSelect.ToString() + colorSelect.ToString(), 1);
                Player.parent.GetChild(7).GetComponent<AudioSource>().Play();
            }
        }
    }
}